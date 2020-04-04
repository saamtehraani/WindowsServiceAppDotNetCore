using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorkerService1.DataModel.Model;
using WorkerService1.Interfaces;
using WorkerService1.Services;

namespace WorkerService1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<TestDbContext>(opts => opts.UseSqlServer(hostContext.Configuration.GetConnectionString("DefaultConnection")));
                    services.AddScoped<ISampleService, SampleService>();
                    services.AddHostedService<Worker>();
                });
    }
}
