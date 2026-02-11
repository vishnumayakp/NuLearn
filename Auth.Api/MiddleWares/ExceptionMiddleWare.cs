
namespace Auth.Api.MiddleWares
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex); 
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";

            var response = new ApiResponse<string>
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = exception.Message,
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
