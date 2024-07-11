using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.Domain.IGenericRepository_IUOW;
using School.Services.Abstracts;

namespace School.Services.Implementaions
{
    public class StudentService(IUnitOfWork unitOfWork) : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _unitOfWork.Students.GetTableNoTracking(includes: [s=>s.Department]).ToListAsync();
        }
    }
}
