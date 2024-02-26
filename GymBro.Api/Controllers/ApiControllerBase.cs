using GymBro.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymBro.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiControllerBase: ControllerBase
    {
        private ISender _mediator = null!;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        protected IActionResult HandleFailuer(Result result) => result switch
        {
            { IsSuccess: true } => throw new InvalidOperationException(),
            IValidationResult validationResult => BadRequest(CreateProblemDetails("Validation Error", StatusCodes.Status400BadRequest,
                result.Error, validationResult.Errors)),
            _ => BadRequest(CreateProblemDetails("Bad Request", StatusCodes.Status400BadRequest, result.Error))
        };

        private static ProblemDetails CreateProblemDetails(string title,int status,Error error, Error[]? errors=null)=>new ProblemDetails()
        {
            Title = title,
            Status = status,
            Type = error.Code,
            Detail = error.Message,
            Extensions = { { nameof(errors), errors } }
        };
    }
}
