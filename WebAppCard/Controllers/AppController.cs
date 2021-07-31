using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppCard.Models;

namespace WebAppCard.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            //throw new InvalidProgramException("Bad things");
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About Us";

            return View();
        }
        [HttpGet("contact")]
        public IActionResult Contact()
        {
            //ViewBag.Title = "Contact";

            //throw new InvalidProgramException("Bad things");

            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactView model)
        {

            //ViewBag.Title = "Contact Us";
            return View();
        } 
    }

    
}
