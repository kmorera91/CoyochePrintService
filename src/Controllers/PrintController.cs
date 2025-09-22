using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using PdfPrintService.Services;
using System;

namespace PdfPrintService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrintController : ControllerBase
    {
        private readonly PrintService _printService;

        public PrintController(PrintService printService)
        {
            _printService = printService;
        }

        [HttpPost("print")]
        public async Task<IActionResult> PostPrintPdf()
        {
            if (Request.ContentLength == null || Request.ContentLength == 0)
            {
                return StatusCode(400, new { status = 400, response = "No PDF document provided." });
            }

            using var memoryStream = new MemoryStream();
            await Request.Body.CopyToAsync(memoryStream);
            var filePath = Path.Combine(Path.GetTempPath(), "temp.pdf");

            await System.IO.File.WriteAllBytesAsync(filePath, memoryStream.ToArray());

            try
            {
                _printService.PrintPdf(filePath);
                return StatusCode(200, new { status = 200, response = "PDF document sent to printer." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = 500, response = ex.Message });
            }
        }
    }
}