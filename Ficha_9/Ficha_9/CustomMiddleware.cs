using System.Diagnostics;
namespace Ficha_9
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate next;
        public CustomMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            Debug.WriteLine("Before Third Middleware.");
            await next(context);
            Debug.WriteLine("After Third Middleware");
        }


    }
}
