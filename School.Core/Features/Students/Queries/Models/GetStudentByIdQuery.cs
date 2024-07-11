using MediatR;
using School.Core.Bases;
using School.Core.Features.Students.Queries.Response;

namespace School.Core.Features.Students.Queries.Models
{
    public class GetStudentByIdQuery(int id) : IRequest<Response<GetStudenByIdResponse>>
    {
        public int Id { get; set; } = id;
    }
}
