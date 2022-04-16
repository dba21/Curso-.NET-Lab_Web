// See https://aka.ms/new-console-template for more information
namespace Ficha_16
{
    internal class Program
    {
        static async Task Main(string[] args)
        //static void Main(string[] args)
        {
            /*var testSync = new TestSync();
            testSync.Run();*/

            var testAsync = new TestAsync();
            await testAsync.RunAsync();
        }
    }

}
