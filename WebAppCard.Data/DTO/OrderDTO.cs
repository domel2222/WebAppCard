using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAppCard.Data.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { set; get; }
        [Required]
        [Range(1, Int32.MaxValue)]
        public int OrderNumber { get; set; }
        public ICollection<OrderItemDTO> Items { get; set; }
    }
}
