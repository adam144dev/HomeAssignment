using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentProject.Dtos;
using StudentProject.Services;

namespace StudentProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("Init")]
        public async Task<string> InitAsync()
        {
            await _projectService.InitAsync();
            return "Done";
        }

        [HttpGet("List")]
        public async Task<List<ProjectGroupsStudentsDto>> ListAsync()
        {
            return await _projectService.GetAllProjectsGroupsStudentsAsync();
        }

        [HttpGet("AddStudentToGroup")]
        public async Task<bool> AddStudentToGroupAsync([Required][FromQuery] Guid groupId, [Required][FromQuery] Guid studentId)
        {
            return await _projectService.AddStudentToGroupAsync(groupId, studentId);
        }

        [HttpGet("CreateGroup")]
        public async Task<Guid?> CreateGroupAsync([Required][FromQuery] Guid projectId, [Required][FromQuery] string groupName)
        {
            return await _projectService.AddGroupForProjectAsync(projectId, groupName);
        }
    }
}