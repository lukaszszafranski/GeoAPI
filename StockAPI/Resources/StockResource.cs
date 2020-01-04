using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAPI.Resources
{
    public class StockResource
    {
        [JsonProperty("quote", NullValueHandling = NullValueHandling.Ignore)]
        public QuoteResource Quote { get; set; }

        [JsonProperty("chart", NullValueHandling = NullValueHandling.Ignore)]
        public List<ChartResource> Chart { get; set; }
    }
}
