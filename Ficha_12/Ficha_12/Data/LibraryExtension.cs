using Ficha_12.Models;

namespace Ficha_12.Data
{
    public static class LibraryExtension
    {
        
        public static void CreateDbIfNotExists(this IHost host)
        {
            {
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var context = services.GetRequiredService<LibraryContext>();

                    if (context.Database.EnsureCreated())
                    {
                        LibraryDBInitializer.InsertData(context);
                    }
                }
            }
        }
    }
}
