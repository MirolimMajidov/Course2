using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using OpenTelemetry.Trace;

namespace BankManagementSystem.API.Middlewares;


/// <summary>
/// Action filter middleware to handle the action and result of the controller to add the tracing span.
/// </summary>
public sealed class ActionAndResultHandler : ActionFilterAttribute
{
    private readonly Tracer _tracer;

    private const string ValidationFailedMessage = "Validation Failed";
    private const int ModelValidationStatusCode = (int)HttpStatusCode.UnprocessableEntity;

    /// <summary>
    /// Constructor to create the action and result handler middleware.
    /// </summary>
    /// <param name="environment">The environment to get service full name</param>
    /// <param name="tracerProvider">The tracer provider to create a telemetry span. It may be null, if the open telemetry is not registered.</param>
    public ActionAndResultHandler(IHostEnvironment environment,
        TracerProvider tracerProvider = null)
    {
        _tracer = tracerProvider?.GetTracer(environment.ApplicationName);
    }

    private string _actionFullName;

    private string GetActionFullName(FilterContext context)
    {
        if (string.IsNullOrWhiteSpace(_actionFullName))
        {
            var controllerActionDescriptor = (ControllerActionDescriptor)context.ActionDescriptor;
            _actionFullName = $"{controllerActionDescriptor.ControllerName}.{controllerActionDescriptor.ActionName}";
        }

        return _actionFullName;
    }

    /// <summary>
    /// Executing action of the controller to create the tracing span for executing an action.
    /// </summary>
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var actionFullName = GetActionFullName(context);

        using var actionSpan = _tracer?.StartActiveSpan($"Handler: {actionFullName} action");

        await base.OnActionExecutionAsync(context, next);
    }

    /// <summary>
    /// Executing the result of the controller to create the tracing span for executing a result.
    /// </summary>
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        var actionFullName = GetActionFullName(context);
        using var resultSpan = _tracer?.StartActiveSpan($"Handler: {actionFullName} result");

        await base.OnResultExecutionAsync(context, next);
    }
}