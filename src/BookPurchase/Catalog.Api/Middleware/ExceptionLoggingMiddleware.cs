namespace Catalog.Api.Middleware;

public class ExceptionLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionLoggingMiddleware> _logger;

    public ExceptionLoggingMiddleware(RequestDelegate next, ILogger<ExceptionLoggingMiddleware> logger)
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
            _logger.LogError(ex, "Unhandled exception caught in middleware!");

            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";

            var response = new
            {
                message = ex.Message,
                stackTrace = ex.StackTrace
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
