using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentProject.DataAccess.Models
{
    public class Student
    {
        [Key]
        public Guid StudentId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public virtual IList<StudentGroup> StudentGroups { get; set; }
    }
}
