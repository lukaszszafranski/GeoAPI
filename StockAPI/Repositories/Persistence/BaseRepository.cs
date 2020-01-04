using StockAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAPI.Repositories.Persistence
{
    public abstract class BaseRepository
    {
        protected readonly StockAPIContext _context;

        public BaseRepository(StockAPIContext context)
        {
            _context = context;
        }
    }
}
