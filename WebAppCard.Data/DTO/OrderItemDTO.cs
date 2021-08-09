using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppCard.Data.DTO
{
    public class OrderItemDTO
    {
        public int Id { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public int PlayerCardId { get; set; }

        public string PlayerCardCategory { get; set; }
        public string PlayerCardNationality { get; set; }
        public string PlayerCardPlayerName { get; set; }
        public string PlayerCardCardId { get; set; }
    }
}
