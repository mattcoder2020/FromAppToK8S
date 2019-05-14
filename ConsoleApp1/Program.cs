using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var services = new ServiceCollection();
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile("jsconfig.json");

            var config = configBuilder.Build();

            services.AddSingleton<IConfiguration>(config);

            IServiceProvider provider = services.BuildServiceProvider();
            var configOutOfDi = provider.GetService<IConfiguration>();
            Console.WriteLine ("config value is " + configOutOfDi.GetSection("version").Value);

            Console.ReadLine();





        }
    }
}
