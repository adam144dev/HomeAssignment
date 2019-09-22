using System;
using System.Collections.Generic;
using StudentProject.DataAccess.Models;

namespace StudentProject.DataAccess
{
    internal static class SeedData
    {
        public static List<Student> Students = new List<Student>
        {
            new Student { StudentId = new Guid("919ee137-adc8-4999-929b-0008d5c76c66"), FirstName = "FirstName1", LastName = "LastName1" },
            new Student { StudentId = new Guid("82171932-15b4-426a-843d-7fcdfaaed587"), FirstName = "FirstName2", LastName = "LastName2" },
            new Student { StudentId = new Guid("c9174d44-4362-4274-8136-d235e41d789e"), FirstName = "FirstName3", LastName = "LastName3" },
            new Student { StudentId = new Guid("e7a25333-eca1-4aac-b993-2380b3bcb98f"), FirstName = "FirstName4", LastName = "LastName4" },
            new Student { StudentId = new Guid("d1b995f0-b99c-4f74-92aa-e6ca98b1e4e3"), FirstName = "FirstName5", LastName = "LastName5" },
            new Student { StudentId = new Guid("854e3f00-e829-4923-9cd8-90dae3c047a5"), FirstName = "FirstName6", LastName = "LastName6" }
        };

        public static List<Project> Projects = new List<Project>
        {
            new Project { ProjectId = new Guid("ebcc09c3-6c31-43c5-ae81-2442988d8212"), ProjectName = "Project1" },
            new Project { ProjectId = new Guid("05e97d88-8320-4caf-8be8-441b1953619a"), ProjectName = "Project2" }
        };

        public static List<Group> Groups = new List<Group>
        {
            new Group { GroupId = new Guid("1fa9f17b-c1e0-471a-b4dc-a8f3031d8ae7"), GroupName = "Group1", Project = Projects[0] },
            new Group { GroupId = new Guid("d6e9c204-4c38-4a8c-a52b-5f012bfb3b35"), GroupName = "Group2", Project = Projects[0] },
            new Group { GroupId = new Guid("947b88d5-e616-4508-9469-f733cc4d82c2"), GroupName = "Group3", Project = Projects[0] },
            new Group { GroupId = new Guid("aeb391d0-87fc-4487-a88b-b8c24f8c300b"), GroupName = "Group4", Project = Projects[1] },
            new Group { GroupId = new Guid("3f1201f3-8d2b-4be3-a175-ec8d4f94dfc1"), GroupName = "Group5", Project = Projects[1] },
            new Group { GroupId = new Guid("484eaa8a-d57c-4fc5-a082-6e6e2939d8ca"), GroupName = "Group6", Project = Projects[1] }
        };

        public static List<StudentGroup> StudentGroups = new List<StudentGroup>
        {
            new StudentGroup { Student = Students[0], Group = Groups[0] },
            new StudentGroup { Student = Students[1], Group = Groups[1] },
            new StudentGroup { Student = Students[2], Group = Groups[2] },
            new StudentGroup { Student = Students[3], Group = Groups[3] },
            new StudentGroup { Student = Students[4], Group = Groups[4] },
            new StudentGroup { Student = Students[5], Group = Groups[5] }
        };
    }
}
