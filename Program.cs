using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ReaiotBackend.Services;

namespace ReaiotBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
           // MessageService.SendMessage("", "");
            CreateHostBuilder(args).Build().Run();          
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
