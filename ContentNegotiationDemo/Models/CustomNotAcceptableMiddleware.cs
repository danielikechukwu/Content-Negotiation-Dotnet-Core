using System.Text.Json;

namespace ContentNegotiationDemo.Models
{
    public class CustomNotAcceptableMiddleware
    {
        // Defining a field to store the next middleware in the pipeline
        private readonly RequestDelegate _next;
        // Constructor that takes in the next middleware in the pipeline
        public CustomNotAcceptableMiddleware(RequestDelegate next)
        {
            // Assigning the injected middleware to the private field
            _next = next;
        }

        // Middleware method called 'Invoke', which is executed for every HTTP request
        public async Task Invoke(HttpContext context)
        {
            // Calling the next middleware in the pipeline and waiting for its completion
            await _next(context);

            if(context.Response.StatusCode == StatusCodes.Status406NotAcceptable)
            {
                var acceptHeader = context.Request.Headers["Accept"].ToString();

                context.Response.ContentType = "application/json";

                var response = new
                {
                    code = StatusCodes.Status406NotAcceptable,
                    ErrorMessage = $"The requested format {acceptHeader} is Not Supported"
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }

        }
    }
}
