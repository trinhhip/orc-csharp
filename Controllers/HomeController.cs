using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tesseract;
using test_orc.Models;

namespace test_orc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var engine = new TesseractEngine("./tessdata", "eng", EngineMode.Default);
            var image = Pix.LoadFromFile("../b.PNG");
            var page = engine.Process(image);
            string text = page.GetText();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}