using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PDFController : ControllerBase
    {
        private IConverter _converter;
        public PDFController(IConverter converter)
        {
            _converter = converter;
        }
        [HttpGet]
        public IActionResult Get()
        {
            PDFCreator creator = new PDFCreator(_converter);
            var file = creator.GetPDF();
            return File(file, "application/pdf", "Test.pdf");
        }
    }
}
