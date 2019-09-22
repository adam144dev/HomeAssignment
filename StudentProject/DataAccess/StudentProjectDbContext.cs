using Microsoft.EntityFrameworkCore;
using StudentProject.DataAccess.Models;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace StudentProject.DataAccess
{
    public class StudentProjectDbContext : DbContext
    {
        public StudentProjectDbContext() {}
        public StudentProjectDbContext(DbContextOptions<StudentProjectDbContext> options) : base(options) {}

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Group> Groups { get; set; }

        public virtual DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasIndex(x => x.StudentId);

            modelBuilder.Entity<Project>()
                .HasIndex(x => x.ProjectId);

            modelBuilder.Entity<Group>()
                .HasIndex(x => x.GroupId);
 
            modelBuilder.Entity<StudentGroup>()
                .HasKey(x => new {x.StudentId, x.GroupId });
        }
    }
}
