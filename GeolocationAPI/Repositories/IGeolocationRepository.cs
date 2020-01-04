using GeolocationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolocationAPI.Repositories
{
    public interface IGeolocationRepository
    {
        Task<IEnumerable<GeolocationData>> ListAsync();
        Task AddAsync(GeolocationData geolocationData);
        Task<GeolocationData> FindByIPAsync(string IP);
        void Remove(GeolocationData geolocationData);
        bool IsDbEmpty();
        bool SpecificGeolocationDataExists(string IP);
    }
}
