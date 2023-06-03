using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PillPartyNFT.Models;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Security.Policy;


namespace PillPartyNFT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public int Count = 0; 

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

			ViewBag.color = "home";



            return View();
        }

        public IActionResult About()
        {
            ViewBag.color = "yellow";
            return View();
        }
        public IActionResult Team()
        {
            ViewBag.color = "team";

            return View();
        }
        public IActionResult Gallery()
        {
            ViewBag.color = "black";

			return View();
        }
        public IActionResult Mint()
        {
            ViewBag.color = "pink";

            return View();
        }

        public IActionResult Clubs()
        {
            ViewBag.color = "cream";
            ViewBag.count = "0"; 

            return View( new ClubsViewModel());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public JsonResult Next(string count)
        {
             var Count = int.Parse(count); 
            Count++;
            if (Count == 6)
            {
                Count = 0;
            }

            var text = Count.ToString(); 

            var rp = new Attributes(Count, text); 

            return Json(rp);
        }
    }

	 class Attributes
	{
        public int Count { get; set; }
        public string Text { get; set; }


        public Attributes(int count, string text)
        {
            Count = count;
            Text = text; 
        }
	}
}
