using School.Data.Entities;

namespace School.Services.Abstracts
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
    }
}
