using EFCoreSamples.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreSamples.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { //Server=(localdb)\\mssqllocaldb
            optionsBuilder.UseSqlite(@"Data Source=Order.db");
        }
    }
}
