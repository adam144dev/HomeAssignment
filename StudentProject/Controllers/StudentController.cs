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
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("Init")]
        public async Task<string> InitAsync()
        {
            await _studentService.InitAsync();
            return "Done";
        }

        [HttpGet("List")]
        public async Task<List<StudentGroupsDto>> ListAsync()
        {
            return await _studentService.GetAllStudentsWithGroups();
        }

        [HttpGet("GetProjects")]
        public async Task<List<ProjectGroupsStudentsDto>> GetProjectsAsync([Required][FromQuery] Guid id)
        {
            return await _studentService.GetProjectsAsync(id);
        }
    }
}