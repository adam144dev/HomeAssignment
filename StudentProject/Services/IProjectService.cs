using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudentProject.Dtos;

namespace StudentProject.Services
{
    public interface IProjectService
    {
        Task InitAsync();

        Task<Guid?> AddGroupForProjectAsync(Guid projectId, string groupName);
        Task<List<ProjectGroupsStudentsDto>> GetAllProjectsGroupsStudentsAsync();
        Task<bool> AddStudentToGroupAsync(Guid groupId, Guid studentId);
    }
}
