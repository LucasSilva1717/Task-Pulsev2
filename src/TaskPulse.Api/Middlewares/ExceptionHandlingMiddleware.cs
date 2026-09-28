using System.Text.Json;
using FluentValidation;
using TaskPulse.Domain.Exceptions;

namespace TaskPulse.Api.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro não tratado durante a requisição.");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var statusCode = StatusCodes.Status500InternalServerError;
        var responseMessage = new Dictionary<string, object>
        {
            ["error"] = "Erro interno no servidor."
        };

        switch (exception)
        {
            case ValidationException validationException:
                statusCode = StatusCodes.Status400BadRequest;
                var errors = validationException.Errors
                    .GroupBy(e => e.PropertyName)
                    .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());
                
                responseMessage["error"] = "Erro de validação.";
                responseMessage["details"] = errors;
                break;

            case DomainException domainException:
                statusCode = StatusCodes.Status400BadRequest;
                responseMessage["error"] = domainException.Message;
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        var json = JsonSerializer.Serialize(responseMessage);
        await context.Response.WriteAsync(json);
    }
}