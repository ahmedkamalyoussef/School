using AutoMapper;
using MediatR;
using School.Core.Bases;
using School.Core.Features.Students.Commands.Models;
using School.Data.Entities;
using School.Domain.Consts;
using School.Services.Abstracts;

namespace School.Core.Features.Students.Commands.Hnadlers
{
    public class StudentCommandHandler(IStudentService studentService, IMapper mapper) : ResponseHandler
        , IRequestHandler<AddStudentCommand, Response<string>>
        , IRequestHandler<EditStudentCommand, Response<string>>
        , IRequestHandler<DeleteStudentCommand, Response<string>>

    {
        private readonly IMapper _mapper = mapper;
        private readonly IStudentService _studentService = studentService;
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<Student>(request);
            var result = await _studentService.AddStudentAsync(student);
            if (result == ErrorType.Success) return Created("added successfuly");
            else if (result == ErrorType.AlreadyExist) return UnprocessableEntity<string>();
            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.StudID);
            if (student == null) return NotFound<string>();

            _mapper.Map(request, student);
            if (await _studentService.EditAsync(student)) return Success("edited successfuly");
            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            ErrorType result = await _studentService.DeleteAsync(request.Id);
            if (result == ErrorType.Success) return Deleted<string>();
            if (result == ErrorType.NotFound) return NotFound<string>();
            return BadRequest<string>("failed to delete");
        }
    }
}
