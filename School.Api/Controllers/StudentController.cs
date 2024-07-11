using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Core.Features.Students.Queries.Models;

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
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
        #endregion
    }
}
