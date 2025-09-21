namespace MovieDirector.API.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation("Incoming request: {method} {url} at {time}",
                context.Request.Method,
                context.Request.Path,
                DateTime.Now);

            await _next(context);

            _logger.LogInformation("Response status: {statusCode}", context.Response.StatusCode);
        }
    }

}
