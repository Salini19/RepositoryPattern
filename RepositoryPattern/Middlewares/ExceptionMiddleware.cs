using RepositoryPattern.Models;

namespace RepositoryPattern.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {

                await HandleException(context, ex);
            }
        }
        private static Task HandleException(HttpContext context, Exception ex)
        {
            var statuscode = StatusCodes.Status404NotFound;
            var errorresponse = new ErrorResponse
            {
                statuscode = statuscode,
                message = ex.Message,
            };
            context.Response.StatusCode = statuscode;
            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(errorresponse.ToString());
        }
    }
}
