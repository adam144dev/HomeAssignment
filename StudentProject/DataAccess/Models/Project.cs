using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentProject.DataAccess.Models
{
    public class Project
    {
        [Key]
        public Guid ProjectId { get; set; }

        [Required]
        public string ProjectName { get; set; }

        public virtual IList<Group> Groups { get; set; }
    }
}
