using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppCard.Data.DataAccess;
using WebAppCard.Data.Models;

namespace WebAppCard.Data.Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly CardContext _cardContext;
        private readonly ILogger<CardRepository> _logger;

        public CardRepository(CardContext cardContext,
                               ILogger<CardRepository> logger)
        {
            this._cardContext = cardContext;
            this._logger = logger;
        }

        public void AddEntity(object entity)
        {
            _cardContext.Add(entity);
        }

        public IEnumerable<Order> GetAllOrders(bool details)
        {

            

            if (details)
            {
                

                return _cardContext.Orders
                           .Include(x => x.Items)
                           .ThenInclude(c => c.PlayerCard)
                           .ToList();

                
            }
            else
            {
                return _cardContext.Orders
                                    .ToList();
            }
        }

        public IEnumerable<PlayerCard> GetAllProduct()
        {
            try
            {
                return _cardContext.PlayerCards
                                .OrderBy(x => x.PlayerName)
                                .ToArray();
            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to get all cards {ex}");
                return default;
            }
            
        }
        public IEnumerable<Order> GetAllOrders()
        {
            try
            {
                return _cardContext.Orders
                                .OrderBy(x => x.OrderDate)
                                .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all cards {ex}");
                return default;
            }

        }
        //public Order GetOrderById(int id)
        //{
        //    var order = _cardContext.Orders
        //                    .Include(i => i.Items)
        //                    .ThenInclude(c => c.PlayerCard)
        //                    .Where(x => x.Id == id)
        //                    .FirstOrDefault();
        //    return order;
        //}

        public IEnumerable<PlayerCard> GetPlayerCardsByCategory(string category)
        {
            return _cardContext.PlayerCards.Where(x => x.Category.ToLower()
                                            == category.ToLower().Trim().Replace(" ", string.Empty))
                                            .ToList();
        }

        public IEnumerable<Order> GetAllOrdersByUser(string username, bool details)
        {
            if (details)
            {
                return _cardContext.Orders
                           .Where(x => x.User.UserName == username)
                           .Include(x => x.Items)
                           .ThenInclude(c => c.PlayerCard)
                           .ToList();
            }
            else
            {
                return _cardContext.Orders
                                    .Where(x => x.User.UserName == username)
                                    .ToList();
            }
        }

        public Order GetOrderByIdForUser(string name, int orderId)
        {
            var order = _cardContext.Orders
                .Include(i => i.Items)
                .ThenInclude(c => c.PlayerCard)
                .Where(x => x.Id == orderId && x.User.UserName == name)
                .FirstOrDefault();

            return order;
        }
        public bool SaveAll()
        {
            return _cardContext.SaveChanges() > 0;
        }
    }
}
