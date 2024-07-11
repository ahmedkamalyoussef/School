using School.Data.Entities;
using School.Domain.Consts;
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
        public async Task<ErrorType> AddStudentAsync(Student student)
        {
            var existingStudent = await _unitOfWork.Students.FindFirstAsync(s => s.Name == student.Name);
            if (existingStudent != null)
                return ErrorType.AlreadyExist;
            await _unitOfWork.Students.AddAsync(student);
            return await _unitOfWork.SaveChangesAsync() > 0 ? ErrorType.Success : ErrorType.Failed;
        }
        #endregion
    }
}
