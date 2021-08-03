using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppCard.Data.Models
{
    public class PlayerCard
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Nationality { get; set; }
        public string CardId { get; set; }
        public string PlayerName { get; set; }
        public string Position { get; set; }
        public decimal Prize { get; set; }
        public decimal Height { get; set; }
        public int Age { get; set; }
        public string ActualClub {get; set;} 
        public DateTime PlayerBirthDate { get; set; }


    }
}
