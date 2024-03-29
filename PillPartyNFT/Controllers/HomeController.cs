﻿using Microsoft.AspNetCore.Mvc;
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
            ViewBag.color = "club";
            ViewBag.count = "0"; 

            return View( );
        }

        public IActionResult TermsOfService()
        {
            ViewBag.color = "none";
            ViewBag.count = "0";

            return View();
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
            if (Count == 7)
            {
                Count = 0;
            }

            var text = Count.ToString(); 

            var rp = new Attributes(Count);

            return Json(rp);
        }

        [HttpGet]
        public JsonResult Prev(string count)
        {
            var Count = int.Parse(count);
            Count--;
            if (Count == -1)
            {
                Count = 6;
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
        public string Hashtags { get; set; }



        Dictionary<string, string> textMap = new Dictionary<string, string>()
        {
            {"0", "DONT FEAR THE REAPER! <br /> DEMON CLUB HAS A DARKER <br /> AESTHETIC THAN THE REST. <br /> LOOKING THE PARTS; GRANTS <br /> YOU MEMBERSHIP.</p>" },
            {"1", "40 CLUB IS FOR THE BOYS. <br /> IF YOU MEET THE RIGHT CRITERIA, <br /> WE LET YOU IN AND GIVE <br /> YOU A SPECIAL COIN <br /> BADGE TO REPRESENT.</p>" },
            {"2", "72 VIRGINS? NOPE, 97 DEGENS <br /> WITH ETH TO SPARE. <br /> DONT WORRY ABOUT A THING, <br /> YOU'RE IN THE GOOD PLACE NOW.</p>" },
            {"3", "BLACK, WHITE, GREEN, OR BLUE, <br /> COLOR CLUB IS JUST ONE HUE. <br /> IF YOU'RE MULTICOLORED, <br /> THIS ISN'T FOR YOU.</p>" },
            {"4", "YOU KNOW 'EM WHEN YOU SEE 'EM. <br /> THESE GREEN BASTARDS RUIN EVERYTHING. <br /> PRESS 'S' TO SPIT. <br /> GOBLINS TOGETHER ARE STRONG.</p>" },
            {"5", "WE DON'T LIKE TO TALK ABOUT IT. <br /> AND DON'T GO ASK THE NEXT GUY NEITHER. <br /> BRAWLERS ONLY. <br /> KEEP YOUR FISTS CLENCHED.</p>" },
            {"6", "MONEY CLUB'S INFLUENCE EXTENDS <br /> FAR BEYOND THE BOARDROOM. <br /> UNIMAGINABLE WEALTH MANIFEST. <br /> MONEY MONEY MONEY.</p>" }
        };



        Dictionary<string, string> percentMap = new Dictionary<string, string>()
        {
            {"0", "370/10000" },
            {"1", "18/10000" },
            {"2", "97/10000" },
            {"3", "100/10000" },
            {"4", "1121/10000" },
            {"5", "67/10000" },
            {"6", "314/10000" }
        };

        Dictionary<string, string> coinMap = new Dictionary<string, string>()
        {
            {"0", "/css/img/COIN DEMON.png" },
            {"1", "/css/img/COIN 40.png" },
            {"2", "/css/img/COIN ANGEL.png" },
            {"3", "/css/img/COIN COLOR.png" },
            {"4", "/css/img/COIN GOBLIN.png" },
            {"5", "/css/img/COIN FIGHT.png" },
            {"6", "/css/img/COIN MONEY.png" }
        };

        Dictionary<string, string> pointsMap = new Dictionary<string, string>()
        {
            { "0", "WHITE, BLACK, OR RED SKIN <br />DEVIL HORNS" },
            { "1", "BEER HELMET <br />40 0Z" },
            { "2", "HALO <br/>WHITE BACKGROUND" },
            { "3", "MATCHING SHIRT <br />MATCHING SKIN <br />MATCHING BACKGROUND" },
            { "4", "GREEN SKIN <br />ANY SHIRT BUT GREEN" },
            { "5", "BLACK EYE <br />BROKEN TEETH OR SCOWL <br />FIST" },
            { "6", "MONEY HAND <br />MONEY GUN <br />ANY SKIN BUT GREEN" }
        };

        Dictionary<string, string> clubMap = new Dictionary<string, string>()
        {
            { "0", "DEMON CLUB" },
            { "1", "40 CLUB" },
            { "2", "ANGEL CLUB" },
            { "3", "COLOR CLUB" },
            { "4", "GOBLIN CLUB" },
            { "5", "FIGHT CLUB" },
            { "6", "MONEY CLUB" }
        };


        Dictionary<string, string> pathMap = new Dictionary<string, string>()
        {
            {"0", "/css/img/Demon Mascot.png" },
            {"1", "/css/img/Club 40.png" },
            {"2", "/css/img/Club Angel.png" },
            {"3", "/css/img/Club Color.png" },
            {"4", "/css/img/Club Goblin.png" },
            {"5", "/css/img/Club Fight.png" },
            {"6", "/css/img/Money Clubs Page.png" }
        };

        Dictionary<string, string> hashtagMap = new Dictionary<string, string>()
        {
            {"0", "#DemonClub" },
            {"1", "#40Club" },
            {"2", "#AngelClub" },
            {"3", "#ColorClub" },
            {"4", "#GoblinClub" },
            {"5", "#FightClub" },
            {"6", "#MoneyClub" }
        };








        public Attributes(int count )
        {
            var key = count.ToString(); 
            Count = count;
            Text = textMap[key];
            Percent = percentMap[key];
            Coin = coinMap[key];
            Path = pathMap[key];
            Club = clubMap[key];
            Points = pointsMap[key];
            Hashtags = hashtagMap[key]; 

        }
	}
}
