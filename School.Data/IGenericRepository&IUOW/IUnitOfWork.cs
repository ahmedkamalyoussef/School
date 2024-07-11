using School.Data.Entities;

namespace School.Domain.IGenericRepository_IUOW
{
    public interface IUnitOfWork
    {
        IGenericRepository<Student> Students { get; set; }
        IGenericRepository<StudentSubject> StudentSubjects { get; set; }
        IGenericRepository<Department> Departments { get; set; }
        IGenericRepository<DepartmetSubject> DepartmentSubjects { get; set; }
        IGenericRepository<Subject> Subjects { get; set; }


        Task<int> SaveChangesAsync();
    }
}
