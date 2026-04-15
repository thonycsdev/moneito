using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MoneiroService.Exceptions;
public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        logger.LogError(exception, "An Exception Occurred!");

        int status;
        string title;

        switch (exception)
        {
            case NotFoundException notFound:
                status = StatusCodes.Status404NotFound;
                title = $"{notFound.ResourceName} not found";
                break;
            case ConflictException conflict:
                status = StatusCodes.Status409Conflict;
                title = $"{conflict.ResourceName} already exists";
                break;
            case UnauthorizedAccessException:
                status = StatusCodes.Status401Unauthorized;
                title = "Unauthorized";
                break;
            default:
                status = StatusCodes.Status500InternalServerError;
                title = "An unexpected error occurred";
                break;
        }

        httpContext.Response.StatusCode = status;
        await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Status = status,
            Title = title,
            Detail = exception.Message
        }, cancellationToken);

        return true;
    }
}