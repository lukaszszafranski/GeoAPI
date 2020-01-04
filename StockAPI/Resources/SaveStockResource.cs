using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockAPI.Resources
{
    public class SaveStockResource
    {
        [JsonProperty("quote", NullValueHandling = NullValueHandling.Ignore)]
        public SaveQuoteResource Quote { get; set; }

        [JsonProperty("chart", NullValueHandling = NullValueHandling.Ignore)]
        public List<SaveChartResource> Chart { get; set; }
    }
}
