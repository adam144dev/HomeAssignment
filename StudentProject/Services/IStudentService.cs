using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudentProject.Dtos;

namespace StudentProject.Services
{
    public interface IStudentService
    {
        Task InitAsync();
        Task<List<ProjectGroupsStudentsDto>> GetProjectsAsync(Guid studentId);
        Task<List<StudentGroupsDto>> GetAllStudentsWithGroups();
    }
}
