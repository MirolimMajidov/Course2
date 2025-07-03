using System.Net;
using BankManagementSystem.API.Exceptions;

namespace BankManagementSystem.API.Middlewares;

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
            logger.LogWarning("test1");
            logger.LogInformation("test1");
            logger.LogDebug("test1");
            logger.LogTrace("test1");
            
            await httpContext.Response.WriteAsJsonAsync<dynamic>(messageInfo);
        }
    }
}