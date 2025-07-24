using System.Net;
using AuthService.Exceptions;

namespace AuthService.Middlewares;

public class GlobalExceptionMiddleware(RequestDelegate next)
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
            object messageInfo;
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
            
            await httpContext.Response.WriteAsJsonAsync<dynamic>(messageInfo);
        }
    }
}