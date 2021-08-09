using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppCard.Data.Models;
using WebAppCard.Data.Repository;

namespace WebAppCard.UI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class CardController : ControllerBase
    {
        private readonly ICardRepository _cardRepository;
        private readonly ILogger<CardController> _logger;

        public CardController(ICardRepository cardRepository, ILogger<CardController> logger )
        {
            this._cardRepository = cardRepository;
            this._logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlayerCard>> GetCards()
        {
            try
            {
                var cards = _cardRepository.GetAllProduct();

                return Ok(cards);
            }
            catch (Exception ex)
            {

                _logger.LogError($"something wrong I can't get products{ex}");

                return BadRequest("failed");
            }
        }
    }
}
