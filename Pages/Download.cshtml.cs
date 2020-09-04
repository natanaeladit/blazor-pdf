using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlazorApp.Pages
{
    public class DownloadModel : PageModel
    {
        private IConverter _converter;
        public DownloadModel(IConverter converter)
        {
            _converter = converter;
        }
        public IActionResult OnGet(string name)
        {
            PDFCreator creator = new PDFCreator(_converter);
            var file = creator.GetPDF();
            return File(file, "application/pdf", name);
        }
    }
}
