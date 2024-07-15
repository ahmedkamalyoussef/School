using System.Diagnostics;

namespace School.Api.MIddleWare
{
    public class PerformanceMiddleware(ILogger<PerformanceMiddleware> logger, RequestDelegate next)
    {
        private readonly ILogger<PerformanceMiddleware> _logger = logger;
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            const int performanceTimeLog = 500;
            var sw = new Stopwatch();
            sw.Start();
            await _next(context);
            sw.Stop();
            if (sw.ElapsedMilliseconds > performanceTimeLog)
            {

                _logger.LogWarning("request {method} {path} took about {elapsed} ms",
                context.Request?.Method,
                context.Request.Path.Value,
                sw.ElapsedMilliseconds);
            }

        }
    }
}
