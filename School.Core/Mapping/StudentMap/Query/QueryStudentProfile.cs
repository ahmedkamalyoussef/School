using School.Core.Features.Students.Queries.Response;
using School.Data.Entities;

namespace School.Core.Mapping.StudentMap
{
    public partial class StudentProfile
    {
        public void GetStudents()
        {
            CreateMap<Student,GetStudentListResponse >()
                   .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DName));
        }
        public void GetStudent()
        {
            CreateMap<Student, GetStudenByIdResponse>()
                   .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DName));
        }
    }
}
