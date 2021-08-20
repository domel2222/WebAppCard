using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppCard.Data.DTO;
using WebAppCard.Data.Models;
using WebAppCard.Data.Repository;

namespace WebAppCard.UI.Controllers
{

    [ApiController]
    [Produces("application/json")]
    [Route("api/[Controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize]
    //[Authorize(Roles = "Admin, Borys")]
    //[Authorize(Roles = "Admin")]
    public class OrdersController : ControllerBase
    {
        private readonly ICardRepository _cardRepository;
        private readonly ILogger<OrdersController> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<StoreUser> _userManager;

        public OrdersController(ICardRepository cardRepository, 
                                ILogger<OrdersController> logger,   
                                IMapper mapper,
                                UserManager<StoreUser> userManager)
        {
            this._cardRepository = cardRepository;
            this._logger = logger;
            this._mapper = mapper;
            this._userManager = userManager;
        }


        [HttpGet]
        // change migration for new value in orgers for 
        public IActionResult GetOrdersWithDetails(bool details = true)
        {
            try
                {
                var username = User.Identity.Name;


                //var result = _cardRepository.GetAllOrders(details);
                var result = _cardRepository.GetAllOrdersByUser(username, details);

                var mapResult = _mapper.Map<IEnumerable<OrderDTO>>(result);

                return Ok(mapResult);

            }
            catch (Exception ex)
            {

                _logger.LogError($"something worong...{ex}");

                return BadRequest($"operation failed - return all orders");
            }
        }

        [HttpGet("{id:int}")]

        public IActionResult GetById(int id)
        {
            try
            {
                var order = _cardRepository.GetOrderByIdForUser(User.Identity.Name, id);
                if (order == null) return NotFound();
                else  
                {
                    var orderDTO = _mapper.Map<OrderDTO>(order);

                    return Ok(orderDTO);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fatall Erorr AAAHAAA {ex}");
                return BadRequest($"Failed to return order");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] OrderDTO model)
        {
            Console.WriteLine("dd");
            // add to DB 
            try
            {
                if (ModelState.IsValid)
                {
                    var newOrder = _mapper.Map<Order>(model);
                    if (newOrder.OrderDate == DateTime.MinValue)
                    {
                        newOrder.OrderDate = DateTime.Now;
                    }

                    //separate class for recall users???
                    var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);

                    newOrder.User = currentUser;

                    _cardRepository.AddEntity(newOrder);
                    if (_cardRepository.SaveAll())
                    {
                        var order = _mapper.Map<OrderDTO>(newOrder);
                        return Created($"/api/orders/{newOrder.Id}", order);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to save new order: {ex}");
            }

            return BadRequest("Mission Failed to save new order");
        }

    }


}
