using Microsoft.EntityFrameworkCore;
using School.Data.Entities;

namespace School.Infrastructure.Data
{
    public class ApplicationDBContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<DepartmetSubject> DepartmetSubjects { get; set; }
    }
}
