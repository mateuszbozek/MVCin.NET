using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tekpro.Models;

namespace Tekpro.Controllers
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
            Console.Write("To jest wykonanie tej akcji");
            return View();
        }

        public IActionResult Privacy()
        {
            Console.Write("A teraz wykonujemy akcjê wywo³ania widoku Privacy");
            return View();
        }

        public IActionResult MyFirstPage()
        {
            String myString = "Testowy string";
            //ViewBag.myString = myString;
            return View(model: myString);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
