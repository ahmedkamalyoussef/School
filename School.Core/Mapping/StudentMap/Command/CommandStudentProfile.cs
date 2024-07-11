using School.Core.Features.Students.Commands.Models;
using School.Data.Entities;

namespace School.Core.Mapping.StudentMap
{
    public partial class StudentProfile
    {
        public void AddStudent()
        {
            CreateMap<AddStudentCommand, Student>()
                   .ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.DepartmentId));
        }
    }
}
