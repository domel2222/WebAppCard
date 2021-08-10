using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppCard.Data.Models;

namespace WebAppCard.Data.DataAccess
{
    public class CardContext : IdentityDbContext<StoreUser>
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder
            //    .Entity<Order>()
            //    .Property(e => e.OrderNumber)
            //    .HasConversion<string>();

        }
    }
}



