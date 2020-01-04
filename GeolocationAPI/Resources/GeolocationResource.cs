using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolocationAPI.Resources
{
    public class GeolocationResource
    {
        public string IP { get; set; }

        public string Type { get; set; }

        public string ContinentCode { get; set; }

        public string ContinentName { get; set; }

        public string CountryCode { get; set; }

        public string CountryName { get; set; }

        public string RegionCode { get; set; }

        public string RegionName { get; set; }

        public string City { get; set; }

        public string Zip { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
