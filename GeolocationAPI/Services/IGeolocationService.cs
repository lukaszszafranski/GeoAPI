using GeolocationAPI.Models;
using GeolocationAPI.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolocationAPI.Services
{
    public interface IGeolocationService
    {
        Task<IEnumerable<GeolocationData>> ListAsync();
        Task<GeolocationResponse> SaveAsync(GeolocationData geolocationData);
        Task<GeolocationData> FindByIPAsync(string IP);
        Task<GeolocationResponse> DeleteAsync(string IP);
        bool IsDbEmpty();
        bool SpecificGeolocationDataExists(string IP);
    }
}
