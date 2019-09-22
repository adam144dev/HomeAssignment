using System;
using System.Collections.Generic;

namespace StudentProject.Dtos
{
    public class ProjectGroupsStudentsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<GroupStudentsDto> Groups { get; set; }
    }
}
