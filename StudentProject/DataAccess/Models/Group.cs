using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentProject.DataAccess.Models
{
    public class Group
    {
        [Key]
        public Guid GroupId { get; set; }

        [Required]
        public string GroupName { get; set; }

        public Project Project { get; set; }

        public virtual IList<StudentGroup> StudentGroups { get; set; }
    }
}
