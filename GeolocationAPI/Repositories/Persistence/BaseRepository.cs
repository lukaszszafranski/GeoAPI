using GeolocationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolocationAPI.Repositories.Persistence
{
    public abstract class BaseRepository
    {
        protected readonly GeolocationAPIContext _context;

        public BaseRepository(GeolocationAPIContext context)
        {
            _context = context;
        }
    }
}
