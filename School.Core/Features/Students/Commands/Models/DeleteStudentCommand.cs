using MediatR;
using School.Core.Bases;

namespace School.Core.Features.Students.Commands.Models
{
    public class DeleteStudentCommand(int id) : IRequest<Response<string>>
    {
        public int Id { get; set; } = id;
    }
}
