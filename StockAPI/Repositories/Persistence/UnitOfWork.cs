using StockAPI.Models;
using StockAPI.Repositories.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAPI.Repositories.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StockAPIContext _context;

        public UnitOfWork(StockAPIContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
