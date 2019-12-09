using GeolocationAPI.Models;
using GeolocationAPI.Repositories.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolocationAPI.Repositories.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GeolocationAPIContext _context;

        public UnitOfWork(GeolocationAPIContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
