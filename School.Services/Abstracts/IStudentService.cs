using School.Data.Entities;
using School.Domain.Consts;

namespace School.Services.Abstracts
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task<bool> IsExist(string name, int? id = null);
        Task<ErrorType> AddStudentAsync(Student student);
        Task<bool> EditAsync(Student student);
        Task<ErrorType> DeleteAsync(int id);

    }
}
