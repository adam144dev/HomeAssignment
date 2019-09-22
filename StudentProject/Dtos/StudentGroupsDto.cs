using System.Collections.Generic;

namespace StudentProject.Dtos
{
    public class StudentGroupsDto : StudentDto
    {
        public IList<GroupDto> StudentGroups { get; set; }
    }
}
