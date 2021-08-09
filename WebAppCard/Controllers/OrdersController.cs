using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppCard.Data.DTO;
using WebAppCard.Data.Repository;

namespace WebAppCard.UI.Controllers
{

    [ApiController]
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ICardRepository _cardRepository;
        private readonly ILogger<OrdersController> _logger;
        private readonly IMapper _mapper;

        public OrdersController(ICardRepository cardRepository, ILogger<OrdersController> logger, IMapper mapper)
        {
            this._cardRepository = cardRepository;
            this._logger = logger;
            this._mapper = mapper;
        }


        [HttpGet]
        // change migration for new value in orgers for 
        public IActionResult GetOrdersWithDetails(bool details = true)
        {
            try
            {
                var result = _cardRepository.GetAllOrders(details);

                var mapResult = _mapper.Map<IEnumerable<OrderDTO>>(result);

                return Ok(mapResult);

            }
            catch (Exception ex)
            {

                _logger.LogError($"something worong...{ex}");

                return BadRequest($"operation failed");
            }
        }

    }


}
