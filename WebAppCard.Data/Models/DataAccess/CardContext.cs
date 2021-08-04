using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppCard.Data.Models.DataAccess
{
    public class CardContext : DbContext
    {

       public CardContext(DbContextOptions<CardContext> options) : base(options)
        {

        }

        public DbSet<PlayerCard> PlayerCards { get; set; } 
        public DbSet<Order> Orders { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }
    }
}
