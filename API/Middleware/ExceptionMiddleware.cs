using System.Net;
using System.Text.Json;
using API.Errors;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next , ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _env= env;
            _logger = logger;

        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType ="application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = _env.IsDevelopment()
                 ? new ApiExceptions((int)HttpStatusCode.InternalServerError,ex.Message,ex.StackTrace.ToString())
                 : new ApiExceptions((int)HttpStatusCode.InternalServerError,ex.Message);

                 var options =  new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};

                 var json = JsonSerializer.Serialize(response,options);

                 await context.Response.WriteAsync(json);
            }
        }

    }
}