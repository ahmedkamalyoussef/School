using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Core.Bases;
using System.Net;
namespace School.Api.BaseResponse
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppControllerBase : ControllerBase
    {
        private IMediator _mediatorInstance;
        protected IMediator _mediator => _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();
        #region Actions
        public ObjectResult NewResult<T>(Response<T> response)
        {
            return response.StatusCode switch
            {
                HttpStatusCode.OK => new OkObjectResult(response),
                HttpStatusCode.Created => new CreatedResult(string.Empty, response),
                HttpStatusCode.Unauthorized => new UnauthorizedObjectResult(response),
                HttpStatusCode.BadRequest => new BadRequestObjectResult(response),
                HttpStatusCode.NotFound => new NotFoundObjectResult(response),
                HttpStatusCode.Accepted => new AcceptedResult(string.Empty, response),
                HttpStatusCode.UnprocessableEntity => new UnprocessableEntityObjectResult(response),
                _ => new BadRequestObjectResult(response),
            };
        }
        #endregion
    }
}
