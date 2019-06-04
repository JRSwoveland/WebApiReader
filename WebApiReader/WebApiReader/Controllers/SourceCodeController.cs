using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApiReader.Controllers
{
    public class SourceCodeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public FileResult Download()
        {
            var fileName = $"source.zip";
            var filepath = $"Content/{fileName}";
            byte[] fileBytes = System.IO.File.ReadAllBytes(filepath);
            return File(fileBytes, "application/x-msdownload", fileName);
        }
    }
}