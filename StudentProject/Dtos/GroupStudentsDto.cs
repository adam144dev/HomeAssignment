using System.Collections.Generic;

namespace StudentProject.Dtos
{
    public class GroupStudentsDto : GroupDto
    {
        public IList<StudentDto> Students { get; set; }
    }
}
