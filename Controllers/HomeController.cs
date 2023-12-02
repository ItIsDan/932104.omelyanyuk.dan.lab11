using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotnet.Models;
using Lab1.Models;
using Lab1.ViewModels;

namespace dotnet.Controllers
{

    public class HomeController : Controller
    {
        //    private readonly ILogger<HomeController> _logger;

        public LabModel Calculate()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            (var first, var second) = (rnd.Next() % 10, rnd.Next() % 10);

            int divResult;
            try
            {
                divResult = first / second;
            }
            catch (DivideByZeroException)
            {
                divResult = -1;
            }

            return new LabModel
            {
                firstRndNum = first,
                secondRndNum = second,
                sumResult = first + second,
                subResult = first - second,
                divResult = divResult,
                mulResult = first * second
            };
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PassUsingViewData()
        {
            ViewData["data"] = Calculate();

            return View();
        }

        public IActionResult PassUsingViewBag()
        {
            ViewBag.data = Calculate();

            return View();
        }

        public IActionResult PassUsingService()
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
