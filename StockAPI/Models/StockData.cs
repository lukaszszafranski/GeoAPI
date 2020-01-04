using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockAPI.Models
{
    using System.Globalization;
    using Newtonsoft.Json;

    public partial class StockData
    {
        [Key]
        public int ID { get; set; } 
        [JsonProperty("quote", NullValueHandling = NullValueHandling.Ignore)]
        public Quote Quote { get; set; }
        [JsonProperty("chart", NullValueHandling = NullValueHandling.Ignore)]
        public List<Chart> Chart { get; set; }
    }
}
