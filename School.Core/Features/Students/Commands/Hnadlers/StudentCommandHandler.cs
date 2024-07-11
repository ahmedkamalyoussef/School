using AutoMapper;
using MediatR;
using School.Core.Bases;
using School.Core.Features.Students.Commands.Models;
using School.Data.Entities;
using School.Domain.Consts;
using School.Services.Abstracts;

namespace School.Core.Features.Students.Commands.Hnadlers
{
    public class StudentCommandHandler(IStudentService studentService,IMapper mapper) : ResponseHandler, IRequestHandler<AddStudentCommand, Response<string>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IStudentService _studentService =studentService;
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var student =_mapper.Map<Student>(request);
            var result = await _studentService.AddStudentAsync(student);
            if (result == ErrorType.Success) return Created("added successfuly");
            else if (result == ErrorType.AlreadyExist) return UnprocessableEntity<string>();
            return BadRequest<string>();
        }
    }
}
