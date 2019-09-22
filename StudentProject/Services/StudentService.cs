using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentProject.DataAccess;
using StudentProject.Dtos;

namespace StudentProject.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly StudentProjectDbContext _dbContext;

        public StudentService(IMapper mapper, StudentProjectDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task InitAsync()
        {
            await _dbContext.Database.ExecuteSqlCommandAsync("DELETE FROM Students");
            await _dbContext.Database.ExecuteSqlCommandAsync("DELETE FROM Groups");
            await _dbContext.Database.ExecuteSqlCommandAsync("DELETE FROM Projects");

            await _dbContext.Students.AddRangeAsync(SeedData.Students);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<ProjectGroupsStudentsDto>> GetProjectsAsync(Guid studentId)
        {
            var projects = await _dbContext.Projects
                .AsNoTracking()
                .Include(p => p.Groups)
                    .ThenInclude(sg => sg.StudentGroups)
                    .ThenInclude(sg => sg.Student)
                .Where(p => p.Groups.SelectMany(g => g.StudentGroups).Any(sg => sg.StudentId == studentId))
                .ToListAsync();

            return _mapper.Map<List<ProjectGroupsStudentsDto>>(projects);
        }

        public async Task<List<StudentGroupsDto>> GetAllStudentsWithGroups()
        {
            var students = await _dbContext.Students
                .AsNoTracking()
                .Include(s => s.StudentGroups)
                    .ThenInclude(sg => sg.Group)
                .ToListAsync();

            return _mapper.Map<List<StudentGroupsDto>>(students);
        }
    }
}
