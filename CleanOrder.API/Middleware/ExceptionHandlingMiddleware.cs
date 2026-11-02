namespace CleanOrder.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {

        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext context)
        {

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = ex is InvalidOperationException
                ? StatusCodes.Status400BadRequest
                : StatusCodes.Status500InternalServerError;


                context.Response.ContentType = "text/plain";

                await context.Response.WriteAsync(
                    context.Response.StatusCode == 500
                        ? "An unexpected error occurred."
                        : ex.Message);
            }

        }




    }
}
