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

        public CardRepository(CardContext cardContext)
        {
            this._cardContext = cardContext;
        }


        public IEnumerable<PlayerCard> GetAllProduct()
        {
            return _cardContext.PlayerCards
                                .OrderBy(x => x.PlayerName)
                                .ToList();
        }

        public IEnumerable<PlayerCard> GetPlayerCardsByCategory(string category)
        {
            return _cardContext.PlayerCards.Where(x => x.Category.ToLower()
                                            == category.ToLower().Trim().Replace(" ", string.Empty))
                                            .ToList();
        }

        public bool SaveAll()
        {
            return _cardContext.SaveChanges() > 0;
        }
    }
}
