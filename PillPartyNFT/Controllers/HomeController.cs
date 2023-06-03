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

            var rp = new Attributes(Count);

            return Json(rp);
        }
    }

	 class Attributes
	{
        public int Count { get; set; }
        public string Text { get; set; }
        public string Percent { get; set; }
        public string Coin { get; set; }
        public string Club { get; set; }
        public string Path { get; set; }
        public string Points { get; set;  }



        Dictionary<string, string> textMap = new Dictionary<string, string>()
        {
            {"0", "DONT FEAR THE REAPER! <br /> DEMON CLUB HAS A DARKER <br /> AESTHETIC THAN THE REST. <br /> LOOKING FOR THE PARTS GRANTS <br /> YOU MEMBERSHIP.</p>" },
            {"1", "40 CLUB IS FOR THE BOYS <br /> IF YOU MEET THE RIGHT CRITERIA <br /> WE LET YOU IN AND GIVE. <br /> YOU A SPECIAL COIN <br /> BADGE TO REPRESENT.</p>" },
            {"2", "72 VIRGINS? NOPE,97 DEGENS <br /> WITH ETH TO SPARE <br /> DONT WORRY ABOUT A THING, <br /> YOU'RE IN THE GOOD PLACE NOW.</p>" },
            {"3", "BLACK, WHITE, GREEN, OR BLUE <br /> COLOR CLUB IS JUST ONE HUE. <br /> IF YOU'RE MMULTICOLORED, <br /> THIS ISN'T FOR YOU.</p>" },
            {"4", "YOU KNOW 'EM WHEN YOU SEE 'EM. <br /> THESE GREEN BASTARDS RUIN EVERYTHING. <br /> PRESS 'S' TO SPIT. <br /> GOBLINS TOGETHER ARE STRONG.</p>" },
            {"5", "WE DON'T LIKE TO TALK ABOUT IT. <br /> AND DON'T GO ASK THE NEXT GUY EITHER. <br /> BRAWLERS ONLY. <br /> KEEP YOUR FISTS CLENCHED.</p>" },
            {"6", "MONEY CLUB'S INFLUENCE EXTENDS. <br /> FAR BEYOND THE BOARD ROOM. <br /> UNIMAGINABLE WEALTH MANIFEST. <br /> MONEY MONEY MONEY.</p>" }
        };

        



        public Attributes(int count )
        {
            var key = count.ToString(); 
            Count = count;
            Text = textMap[key];
            var t = 0; 
            Percent = percentMap[key];
            Coin = coinMap[key];
            Club = clubMap[key];
            Path = pathMap[key];
            Poins = pointsMap[key]; 

        }
	}
}
