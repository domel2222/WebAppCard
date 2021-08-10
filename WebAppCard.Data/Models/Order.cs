using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppCard.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { set; get; }
        // change to int , new migration
        public int OrderNumber { get; set; }  
        public ICollection<OrderItem> Items { get; set; }
        public StoreUser User { get; set; }
    }
}
