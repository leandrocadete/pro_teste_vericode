using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Model.Interfaces.Repository;
using Adapter.Repository;
using System.ComponentModel;
using System.CodeDom;


namespace Worker
{

    public class Program
    {
        public static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();

            var services = scope.ServiceProvider;
            try{
                services.GetRequiredService<App>().Run(args);
            } 
            catch  (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
            //Init(args);
        }

        private static void Init(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();

            var services = scope.ServiceProvider;
        }
        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder().ConfigureServices((_, services) =>
            {
                services
                .AddTransient<ITarefaRepository, TarefaRepository>()
                .AddSingleton<App>();
            });
        }
    }
}