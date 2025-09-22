using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PdfPrintService.Services;

namespace PdfPrintService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var builder = WebApplication.CreateBuilder(args);
                builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                // Register PrintService as a singleton
                builder.Services.AddSingleton<PrintService>();
                builder.Services.AddControllers();

                // Read URL from configuration
                var url = builder.Configuration["Kestrel:Endpoints:Http:Url"] ?? "http://0.0.0.0:5000";
                builder.WebHost.UseUrls(url);

                // Enable running as a Windows Service
                builder.Host.UseWindowsService();

                var app = builder.Build();

                app.MapControllers();

                app.Run();
            }
            catch (Exception ex)
            {
                var logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Program.log");
                var logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Unhandled exception: {ex}\n";
                File.AppendAllText(logPath, logMessage);
                throw;
            }
        }
    }
}