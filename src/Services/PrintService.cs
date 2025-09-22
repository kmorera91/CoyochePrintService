using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;
using PdfiumViewer;

namespace PdfPrintService.Services
{
    public class PrintService : IHostedService
    {
        private readonly string _acrobatReaderPath;
        private readonly string _PrinterName;

        public PrintService(IConfiguration configuration)
        {
            _acrobatReaderPath = configuration["PdfPrintService:AcrobatReaderPath"];
            _PrinterName = configuration["PdfPrintService:PrinterName"];

        }

        //public void PrintPdf(string filePath)
        //{
        //    if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
        //    {
        //        throw new ArgumentException("Invalid file path.", nameof(filePath));
        //    }
        //    if (string.IsNullOrEmpty(_acrobatReaderPath) || !File.Exists(_acrobatReaderPath))
        //    {
        //        throw new InvalidOperationException("Acrobat Reader path is not configured or the file does not exist.");
        //    }
        //    var processStartInfo = new ProcessStartInfo
        //    {
        //        FileName = _acrobatReaderPath,
        //        Arguments = $"/s /o /h /t \"{filePath}\"",
        //        CreateNoWindow = true,
        //        WindowStyle = ProcessWindowStyle.Hidden
        //    };
        //    using (var process = Process.Start(processStartInfo))
        //    {
        //        process.WaitForExit();
        //    }
        //}

        public void PrintPdf(string filePath)
        {
            using (var document = PdfDocument.Load(filePath))
            {
                using (var printDocument = document.CreatePrintDocument())
                {
                    printDocument.PrinterSettings.PrinterName = _PrinterName;
                    printDocument.Print();
                }
            }
        }
        public Task StartAsync(CancellationToken cancellationToken) => Task.CompletedTask;
        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}