using System.Collections.Generic;
using WebAppCard.Data.Models;

namespace WebAppCard.Data.Repository
{
    public interface ICardRepository
    {
        IEnumerable<PlayerCard> GetAllProduct();
        IEnumerable<PlayerCard> GetPlayerCardsByCategory(string category);
        IEnumerable<Order> GetAllOrders(bool details);

        void AddEntity(object entity);
        bool SaveAll();
    }
}