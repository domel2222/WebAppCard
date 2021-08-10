using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppCard.Data.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { set; get; }
        [Required]
        //[MinLength(4)]
        // change to int , new migration
        public int OrderNumber { get; set; }
        public ICollection<OrderItemDTO> Items { get; set; }
    }
}
