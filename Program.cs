
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MontadorasGameApi.Models;

namespace MontadorasGameApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host =  CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<MontadorasGameContext>();

                DataGenerator.Initialize(services);
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("https://192.168.15.2:5001","http://192.168.15.2:5000","https://localhost:5001","http://localhost:5000");
                });
    }
}
