using DeltaFit.Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DeltaFit.Api.Abstractions;

[Route("api/[controller]/")]
[ApiController]
public class ApiController : ControllerBase
{
    protected IActionResult HandleFailure(Result result) =>
           result switch
           {
               { IsSuccess: true } => throw new InvalidOperationException(),
               IValidationResult validationResult =>
               BadRequest(
                   CreateProblemDetails(
                       "Validation Error",
                       StatusCodes.Status400BadRequest,
                       result.Error,
                       validationResult.Errors)),
               _ => BadRequest(
                   CreateProblemDetails("Bad Request",
                       StatusCodes.Status400BadRequest,
                       result.Error))
           };

    private static ProblemDetails CreateProblemDetails(
        string title,
        int status,
        Error error,
        Error[]? errors = null) =>
        new()
        {
            Title = title,
            Type = error.Code,
            Detail = error.Message,
            Status = status,
            Extensions = { { nameof(errors), errors } }
        };
}