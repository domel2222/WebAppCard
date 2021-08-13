using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
    [Route("api/orders/{orderId}/items")]
    //[Authorize(Roles = "Admin")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize]
    public class OrderItemsController : ControllerBase
    {
        private readonly ICardRepository _cardRepository;
        private readonly ILogger<OrderItemsController> _logger;
        private readonly IMapper _mapper;

        public OrderItemsController(ICardRepository cardRepository,
                                    ILogger<OrderItemsController> logger,
                                    IMapper mapper)
        {
            this._cardRepository = cardRepository;
            this._logger = logger;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetOrderItemById(int orderId)
        {
            var order = _cardRepository.GetOrderByIdForUser(User.Identity.Name, orderId);
            if (order == null) return NotFound();

            var orderDto = _mapper.Map<IEnumerable<OrderItemDTO>>(order.Items);

            return Ok(orderDto);
        }

        [HttpGet("{itemId}")]
        public IActionResult GetOrderItem(int orderId, int itemId)
        {
            var order = _cardRepository.GetOrderByIdForUser(User.Identity.Name, orderId);
            
            if (order == null) return NotFound();

            var item = order.Items.Where(x => x.Id == itemId).FirstOrDefault();

            if (order == null) return NotFound();

            var itemDto = _mapper.Map<OrderItemDTO>(item);

            return Ok(itemDto);

        }
    }
}
