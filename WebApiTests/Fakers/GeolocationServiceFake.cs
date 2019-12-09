using GeolocationAPI.Models;
using GeolocationAPI.Services;
using GeolocationAPI.Services.Communication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace WebApiTests.Fakers
{
    public class GeolocationServiceFake : IGeolocationService
    {
        private readonly List<GeolocationData> _geolocationDatas;

        public GeolocationServiceFake()
        {
            _geolocationDatas = new List<GeolocationData>()
            {
                new GeolocationData()
                {
                    IP = "109.131.249.58",
                    Type = "ipv4",
                    ContinentCode = "EU",
                    ContinentName = "Europe",
                    CountryCode = "BE",
                    CountryName = "Belgium",
                    RegionCode = "BRU",
                    RegionName = "Brussels Capital",
                    City = "Brussels",
                    Zip = "1000",
                    Latitude = 50.84674072265625,
                    Longitude = 4.3524899482727051
                },

                new GeolocationData()
                {
                    IP = "109.131.249.59",
                    Type = "ipv4",
                    ContinentCode = "EU",
                    ContinentName = "Europe",
                    CountryCode = "BE",
                    CountryName = "Belgium",
                    RegionCode = "BRU",
                    RegionName = "Brussels Capital",
                    City = "Brussels",
                    Zip = "1000",
                    Latitude = 50.84674072265625,
                    Longitude = 4.3524899482727051
                },

                new GeolocationData()
                {
                    IP = "109.131.249.60",
                    Type = "ipv4",
                    ContinentCode = "EU",
                    ContinentName = "Europe",
                    CountryCode = "BE",
                    CountryName = "Belgium",
                    RegionCode = "BRU",
                    RegionName = "Brussels Capital",
                    City = "Brussels",
                    Zip = "1000",
                    Latitude = 50.84674072265625,
                    Longitude = 4.3524899482727051
                },
            };
        }

        public async Task<GeolocationResponse> DeleteAsync(string IP)
        {
            var existingGeoData = _geolocationDatas.First(g => g.IP == IP);
            _geolocationDatas.Remove(existingGeoData);

            return await Task.Run(() => new GeolocationResponse(existingGeoData));
        }

        public async Task<GeolocationData> FindByIPAsync(string IP)
        {
            return await Task.Run(() => _geolocationDatas.Where(g => g.IP == IP).FirstOrDefault());
        }

        public bool IsDbEmpty()
        {
            return !_geolocationDatas.Any();
        }

        public async Task<IEnumerable<GeolocationData>> ListAsync()
        {
            return await Task.Run(() => _geolocationDatas);
        }

        public async Task<GeolocationResponse> SaveAsync(GeolocationData geolocationData)
        {
            return await Task.Run(() => new GeolocationResponse(geolocationData));
        }

        public bool SpecificGeolocationDataExists(string IP)
        {
            return _geolocationDatas.Any(g => g.IP == IP);
        }
    }
}
