using GeolocationAPI.Models;
using GeolocationAPI.Repositories.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolocationAPI.Repositories
{
    public class GeolocationRepository : BaseRepository, IGeolocationRepository
    {
        public GeolocationRepository(GeolocationAPIContext context) : base(context)
        {

        }
        public async Task<IEnumerable<GeolocationData>> ListAsync()
        {
            return await Task.Run(() => _context.GeolocationData.ToList());
        }
        public async Task AddAsync(GeolocationData geolocationData)
        {
            await _context.GeolocationData.AddAsync(geolocationData);
        }
        public async Task<GeolocationData> FindByIPAsync(string IP)
        {
            return await _context.GeolocationData.FindAsync(IP);
        }

        public void Remove(GeolocationData geolocationData)
        {
            _context.GeolocationData.Remove(geolocationData);
        }

        public bool IsDbEmpty()
        {
            return !_context.GeolocationData.Any();
        }

        public bool SpecificGeolocationDataExists(string IP)
        {
            return _context.GeolocationData.Any(e => e.IP == IP);
        }
    }
}
