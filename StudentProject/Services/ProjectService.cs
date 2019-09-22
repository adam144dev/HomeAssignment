using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentProject.DataAccess;
using StudentProject.DataAccess.Models;
using StudentProject.Dtos;

namespace StudentProject.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IMapper _mapper;
        private readonly StudentProjectDbContext _dbContext;

        public ProjectService(IMapper mapper, StudentProjectDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task InitAsync()
        {
            await _dbContext.Database.ExecuteSqlCommandAsync("DELETE FROM Students");
            await _dbContext.Database.ExecuteSqlCommandAsync("DELETE FROM Groups");
            await _dbContext.Database.ExecuteSqlCommandAsync("DELETE FROM Projects");

            await _dbContext.Projects.AddRangeAsync(SeedData.Projects);
            await _dbContext.Groups.AddRangeAsync(SeedData.Groups);
            await _dbContext.AddRangeAsync(SeedData.StudentGroups);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<ProjectGroupsStudentsDto>> GetAllProjectsGroupsStudentsAsync()
        {
            var projects = await _dbContext.Projects
                .AsNoTracking()
                .Include(p => p.Groups)
                    .ThenInclude(sg => sg.StudentGroups)
                    .ThenInclude(sg => sg.Student)
                .ToListAsync();

            return _mapper.Map<List<ProjectGroupsStudentsDto>>(projects);
        }

        public async Task<Guid?> AddGroupForProjectAsync(Guid projectId, string groupName)
        {
            var project = await _dbContext.Projects.SingleOrDefaultAsync(p => p.ProjectId == projectId);
            if (project == null)
                return null;

            var group = new Group { GroupId = Guid.NewGuid(), GroupName = groupName, Project = project };

            await _dbContext.Groups.AddAsync(group);
            await _dbContext.SaveChangesAsync();

            return group.GroupId;
        }

        public async Task<bool> AddStudentToGroupAsync(Guid groupId, Guid studentId)
        {
            var group = await _dbContext.Groups
                .Include(g => g.Project)
                .Include(g => g.StudentGroups)
                .SingleOrDefaultAsync(g => g.GroupId == groupId);
            if (group == null)
                return false;

            var student = await _dbContext.Students
                .Include(s => s.StudentGroups)
                    .ThenInclude(sg => sg.Group)
                    .ThenInclude(g => g.Project)
                .SingleOrDefaultAsync(s => s.StudentId == studentId);
            if (student == null)
                return false;

            var projectId = group.Project.ProjectId;
            var alreadyInProject = student.StudentGroups
                .Select(sg => sg.Group)
                .Any(g => g.Project.ProjectId == projectId);
            if (alreadyInProject)
                return false;

            group.StudentGroups.Add(new StudentGroup { Student = student, Group = group });
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
