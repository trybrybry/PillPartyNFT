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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
			List<Pill> items = new List<Pill>();


			using (StreamReader r = new StreamReader(Path.Combine(Environment.CurrentDirectory, "json/_metadata.json")))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<Pill>>(json);
            }


			ViewBag.color = "home";

            ViewBag.items = items;


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
			List<Pill> items = new List<Pill>();


			using (StreamReader r = new StreamReader(Path.Combine(Environment.CurrentDirectory, "json/_metadata.json")))
			{
				string json = r.ReadToEnd();
				items = JsonConvert.DeserializeObject<List<Pill>>(json);
			}

			ViewBag.items = items;

			return View();
        }
        public IActionResult Mint()
        {
            ViewBag.color = "pink";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

	internal class Pill
	{
        public string name { get; set; }
        public string description { get; set; }
        public string img { get; set; }
        public string ndc { get; set; }

        public int number { get; set; }
        public string date { get; set; }
        public Attributes[] attributes { get; set; }
        
        public string compiler { get; set; }

    }

	 class Attributes
	{
        public string trait_type { get; set; }
        public string value { get; set; }
	}
}
