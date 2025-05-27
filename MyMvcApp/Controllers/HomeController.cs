using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers
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
            var products = new List<ProductModel>
            {
                new () {Id =1, Name = "Crocs", Price =250.00m },
                new () {Id =2, Name = "Palazzo", Price = 500.50m},
                new () {Id =3, Name = "Laptop", Price = 1000.00m}

            };
            return View(products);
        }

        public ActionResult About()
        {
            var product = new ProductModel
            {
                Id = 23,
                Name = "Android",
                Price = 313.17m,
                Description = "Android don cost die make u safeguard your phone wella"
            };
            ViewData["Title"] = "About product";

            return View(product);

        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        //public IActionResult About()
        //{
        //    return View();
        //}
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
