using System.Diagnostics;
namespace Ficha_9
{
    public class LoggerMiddleware
    {
        private readonly RequestDelegate next;
        public LoggerMiddleware(RequestDelegate next)
            {
            this.next = next;
            }

        public async Task InvokeAsync(HttpContext context)
        {
            string before = String.Format($"Before: { context.Request.Path}, { context.Request.Method}, {DateTime.Now}\n");
            string after = String.Format($"After: { context.Request.Path}, { context.Request.Method}, {DateTime.Now}\n");

            File.AppendAllText("logs.txt", before);
            Debug.WriteLine(before);

            await next(context);

            Debug.WriteLine(after);
            File.AppendAllText("logs.txt", after);
            
        }
    }
}
