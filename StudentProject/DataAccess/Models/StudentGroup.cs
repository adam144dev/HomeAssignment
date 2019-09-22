﻿using System;

namespace StudentProject.DataAccess.Models
{
    public class StudentGroup
    {
        public Guid StudentId { get; set; }
        public Student Student { get; set; }

        public Guid GroupId { get; set; }
        public Group Group { get; set; }
    }
}