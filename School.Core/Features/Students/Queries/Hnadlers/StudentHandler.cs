using MediatR;
using School.Core.Features.Students.Queries.Models;
using School.Data.Entities;
using School.Services.Abstracts;

namespace School.Core.Features.Students.Queries.Hnadlers
{
    public class StudentHandler(IStudentService studentService) : IRequestHandler<GetStudentListQuery, List<Student>>
    {
        #region fields
        private readonly IStudentService _studentService = studentService;
        #endregion
        #region handlers
        public async Task<List<Student>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            return await _studentService.GetStudentsAsync();
        }
        #endregion
    }
}
