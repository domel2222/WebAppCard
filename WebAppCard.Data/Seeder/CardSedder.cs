using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<StoreUser> _userManager;

        public CardSedder(CardContext cardContext,
                            UserManager<StoreUser> userManager)
        {
            this._cardContext = cardContext;
            this._userManager = userManager;
        }


        public async Task SeedAsync()
        {


            _cardContext.Database.EnsureCreated();


            StoreUser user = await _userManager.FindByEmailAsync("domel13@gmail.com");

            if (user == null)
            {
                user = new StoreUser
                {
                    FirstName = "Marcus",
                    LstName = "Baaaaa",
                    Email = "domel13@gmail.com",
                    UserName = "domel13@gmail.com"
                };

                var result = await _userManager.CreateAsync(user, "P@assw0rd!");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user");
                }

            }
            if (!_cardContext.PlayerCards.Any())
            {

                //sample Data 
                var filePath = Path.Combine("../WebAppCard.Data/Extension/card.json"); 
                var json = File.ReadAllText(filePath);
                var cards = JsonConvert.DeserializeObject<IEnumerable<PlayerCard>>(json);

                _cardContext.PlayerCards.AddRange(cards);


                //var order = new Order()
                var order = _cardContext.Orders.Where(x => x.Id == 1).FirstOrDefault();

                if (order != null)
                {
                    //OrderDate = DateTime.Today,
                    //OrderNumber = 13547,
                    //Items = new List<OrderItem> 
                    order.User = user;
                    order.Items = new List<OrderItem>
                    {
                       new OrderItem()
                       {
                           PlayerCard = cards.First(),
                           Quantity = 13,
                           UnitPrice = cards.First().Price
                       }
                    };
                };

                _cardContext.Orders.Add(order);
                _cardContext.SaveChanges();
            }
        }
    }
}
