using System.Net;
using BankManagementSystem.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace BankManagementSystem.Presentation.Middlewares;

public class GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (BadRequestException ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            
            await httpContext.Response.WriteAsJsonAsync(ex.Message);
        }
        catch (Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            object messageInfo = null;
#if DEBUG
            messageInfo = new
            {
                errorMessage = ex.Message,
                stackTrace = ex.StackTrace
            };
#else
                messageInfo = new
                {
                    errorMessage = "Internal server error",
                    stackTrace = ""
                };
#endif
            
            logger.LogError("An error occurred: {Message}", ex.Message);
            
            await httpContext.Response.WriteAsJsonAsync<dynamic>(messageInfo);
        }
    }
}