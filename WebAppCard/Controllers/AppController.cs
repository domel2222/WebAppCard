using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppCard.Services;
using WebAppCard.Data.DTO;
using WebAppCard.Data.DataAccess;
using WebAppCard.Data.Repository;
using Microsoft.AspNetCore.Authorization;

namespace WebAppCard.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        //private readonly ICardRepository cardRepository;
        private readonly ICardRepository _cardRepository;

        public AppController(IMailService mailService,
                               ICardRepository cardRepository)
        {
            this._mailService = mailService;
            this._cardRepository = cardRepository;
        }
        public IActionResult Index()
        {
            //throw new InvalidProgramException("Bad things");
            //var result = _cardRepository.PlayerCards.ToList();
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
        public IActionResult Contact(ContactDTO model)
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
        //[Authorize]
        public IActionResult Shop()
        {

            var cos = HttpContext.User;
            var results = _cardRepository.GetAllProduct();

            return View(results);
        }


    }
}
