using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Core.Features.Students.Commands.Models;
using School.Core.Features.Students.Queries.Models;

namespace School.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController(IMediator mediator) : ControllerBase
    {
        #region fields
        private readonly IMediator _mediator = mediator;
        #endregion

        #region Actions
        [HttpGet("all")]
        public async Task<IActionResult> GetStudentList()
        {
            var response = await _mediator.Send(new GetStudentListQuery());
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var response = await _mediator.Send(new GetStudentByIdQuery(id));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(AddStudentCommand studentCommand)
        {
            var response = await _mediator.Send(studentCommand);
            return Ok(response);
        }
        #endregion
    }
}
