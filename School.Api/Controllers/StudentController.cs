using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Api.BaseResponse;
using School.Core.Features.Students.Commands.Models;
using School.Core.Features.Students.Queries.Models;

namespace School.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : AppControllerBase
    {
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
            return NewResult(await _mediator.Send(new GetStudentByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(AddStudentCommand studentCommand)
        {
             
            return NewResult(await _mediator.Send(studentCommand));
        }
        #endregion
    }
}
