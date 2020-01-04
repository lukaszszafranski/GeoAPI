using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GeolocationAPI.Models
{
    using System;
    using System.Globalization;
    using Newtonsoft.Json;

    public class GeolocationData
    {
        [Key]
        [JsonProperty("ip")]
        public string IP { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("continent_code", NullValueHandling = NullValueHandling.Ignore)]
        public string ContinentCode { get; set; }

        [JsonProperty("continent_name", NullValueHandling = NullValueHandling.Ignore)]
        public string ContinentName { get; set; }

        [JsonProperty("country_code", NullValueHandling = NullValueHandling.Ignore)]
        public string CountryCode { get; set; }

        [JsonProperty("country_name", NullValueHandling = NullValueHandling.Ignore)]
        public string CountryName { get; set; }

        [JsonProperty("region_code", NullValueHandling = NullValueHandling.Ignore)]
        public string RegionCode { get; set; }

        [JsonProperty("region_name", NullValueHandling = NullValueHandling.Ignore)]
        public string RegionName { get; set; }

        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }

        [JsonProperty("zip", NullValueHandling = NullValueHandling.Ignore)]
        public string Zip { get; set; }

        [JsonProperty("latitude", NullValueHandling = NullValueHandling.Ignore)]
        public double Latitude { get; set; }

        [JsonProperty("longitude", NullValueHandling = NullValueHandling.Ignore)]
        public double Longitude { get; set; }
    }
}
