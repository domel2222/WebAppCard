using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppCard.Data.DTO
{
    public class OrderItemDTO
    {
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public int PlayerCardId { get; set; }

        // for refactor... simpler name
        public string PlayerCardCategory { get; set; }
        public string PlayerCardNationality { get; set; }
        public string PlayerCardPlayerName { get; set; }
        public string PlayerCardCardId { get; set; }
    }
}
