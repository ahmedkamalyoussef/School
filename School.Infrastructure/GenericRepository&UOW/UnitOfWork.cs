using School.Data.Entities;
using School.Domain.IGenericRepository_IUOW;
using School.Infrastructure.Data;

namespace School.Infrastructure.GenericRepository_UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        #region fields
        private readonly ApplicationDBContext _context;

        public IGenericRepository<Student> Students { get; set; }
        public IGenericRepository<StudentSubject> StudentSubjects { get; set; }
        public IGenericRepository<Department> Departments { get; set; }
        public IGenericRepository<DepartmetSubject> DepartmentSubjects { get; set; }
        public IGenericRepository<Subject> Subjects { get; set; }


        #endregion
        #region ctor
        public UnitOfWork(ApplicationDBContext context)
        { 
            _context = context;
            Students = new GenericRepository<Student>(_context);
            StudentSubjects=new GenericRepository<StudentSubject>(_context);
            Departments = new GenericRepository<Department>(_context);
            DepartmentSubjects=new GenericRepository<DepartmetSubject>(_context);
            Subjects = new GenericRepository<Subject>(_context);
        }
        #endregion
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
