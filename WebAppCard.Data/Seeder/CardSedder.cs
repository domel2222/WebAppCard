using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppCard.Data.DataAccess;
using WebAppCard.Data.Models;

namespace WebAppCard.Data.Seeder
{
    public class CardSedder
    {
        private readonly CardContext _cardContext;

        public CardSedder(CardContext cardContext)
        {
            this._cardContext = cardContext;
        }


        public void Seed()
        {
            _cardContext.Database.EnsureCreated();
            if (!_cardContext.PlayerCards.Any())
            {
                var filePath = Path.Combine("../Extension/card.json");
                var json = File.ReadAllText(filePath);
                var cards = JsonConvert.DeserializeObject<IEnumerable<PlayerCard>>(json);


            }
        }
    }
}
