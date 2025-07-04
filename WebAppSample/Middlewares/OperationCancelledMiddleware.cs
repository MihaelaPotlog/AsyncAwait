namespace WebAppSample.Middlewares;

class OperationCancelledMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<OperationCancelledMiddleware> _logger;

    public OperationCancelledMiddleware(
        RequestDelegate next,
        ILogger<OperationCancelledMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (OperationCanceledException ex)
        {
            _logger.LogError(ex, "Request cancelled!");
            context.Response.StatusCode = 409;
        }
    }
}