using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockAPI.Entities;

namespace StockAPI.Models
{
    public class StockAPIContext : DbContext
    {
        public StockAPIContext (DbContextOptions<StockAPIContext> options)
            : base(options)
        {
        }

        public DbSet<StockData> StockData { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
