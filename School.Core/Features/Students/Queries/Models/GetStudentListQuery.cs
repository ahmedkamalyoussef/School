using MediatR;
using School.Core.Bases;
using School.Core.Features.Students.Queries.Response;

namespace School.Core.Features.Students.Queries.Models
{
    public class GetStudentListQuery:IRequest<Response<List<GetStudentListResponse>>>
    {
    }
}
