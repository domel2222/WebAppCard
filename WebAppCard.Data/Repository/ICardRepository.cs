using System.Collections.Generic;
using WebAppCard.Data.Models;

namespace WebAppCard.Data.Repository
{
    public interface ICardRepository
    {
        IEnumerable<PlayerCard> GetAllProduct();
        IEnumerable<PlayerCard> GetPlayerCardsByCategory(string category);
        Order GetOrderById(int id);
        IEnumerable<Order> GetAllOrders(bool details);
        IEnumerable<Order> GetAllOrders();

        void AddEntity(object entity);
        bool SaveAll();
    }
}