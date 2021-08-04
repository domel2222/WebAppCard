using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppCard.Services;
using WebAppCard.Data.Models;
using WebAppCard.Data.DataAccess;

namespace WebAppCard.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly CardContext _cardContext;

        public AppController(IMailService mailService,
                               CardContext cardContext)
        {
            this._mailService = mailService;
            this._cardContext = cardContext;
        }
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
            if (ModelState.IsValid)
            {
                //send the email
                _mailService.SendMessage("domel2222@gmail.com", model.Subject, $"From: {model.Name} {model.Subject}");
                ViewBag.UserMessageSent = "Mail Sent";
                ModelState.Clear();
            }
            //ViewBag.Title = "Contact Us";
            else
            {
                //show the errors
            }
            return View();
        }
        public IActionResult Shop()
        {
            var results = _cardContext.PlayerCards.OrderBy(x => x.Category).ToList();

            return View(results);
        }


    }
}
