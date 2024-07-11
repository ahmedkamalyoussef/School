using School.Data.Entities;
using School.Domain.IGenericRepository_IUOW;
using School.Services.Abstracts;

namespace School.Services.Implementaions
{
    public class StudentService(IUnitOfWork unitOfWork) : IStudentService
    {
        #region fields
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        #endregion
        #region methods
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _unitOfWork.Students.FindFirstAsync(s => s.StudID == id, includes: [s => s.Department]);
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            var result = await _unitOfWork.Students.GetAllAsNoTrackingAsync(includes: [s=>s.Department]);
            return result.ToList();
        }
        #endregion
    }
}
