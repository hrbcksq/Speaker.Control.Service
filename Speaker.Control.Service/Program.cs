using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Speaker.Http.Api;
using System;
using System.Diagnostics;
using System.IO;

namespace Speaker.Control.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IConfiguration GetConfiguration() => new ConfigurationBuilder()
            // Windows service root directory override for SingleFileDeploy
            .SetBasePath(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName))
            .AddJsonFile("appsettings.json", true, false)
            .Build();

        public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder
                    .UseConfiguration(GetConfiguration())
                    .UseStartup<Startup>()
                    .UseKestrel();
            })
            .UseWindowsService();
    }
}