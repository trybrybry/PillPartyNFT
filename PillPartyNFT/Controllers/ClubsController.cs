using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PillPartyNFT.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PillPartyNFT.Controllers
{
    public class ClubsController : Controller
    {
        public int Count = 0; 
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(new ClubsViewModel());
        }

        [HttpGet]
        public JsonResult Next()
        {
            Count++;
            if(Count == 6)
            {
                Count = 0; 
            }
            return Json(Count.ToString()); 
        }
    }
}

