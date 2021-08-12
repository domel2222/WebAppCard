using System.Collections.Generic;
using WebAppCard.Data.Models;

namespace WebAppCard.Data.Repository
{
    public interface ICardRepository
    {
        IEnumerable<PlayerCard> GetAllProduct();
        IEnumerable<PlayerCard> GetPlayerCardsByCategory(string category);
        //Order GetOrderById(int id);
        Order GetOrderByIdForUser(string name, int orderId);
        IEnumerable<Order> GetAllOrdersByUser(string username, bool details);
        IEnumerable<Order> GetAllOrders(bool details);
        IEnumerable<Order> GetAllOrders();

        void AddEntity(object entity);
        bool SaveAll();
    }
}