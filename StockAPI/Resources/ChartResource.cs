using Newtonsoft.Json;
using System;

namespace StockAPI.Resources
{
    public class ChartResource
    {
        [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? Date { get; set; }

        [JsonProperty("open", NullValueHandling = NullValueHandling.Ignore)]
        public double? Open { get; set; }

        [JsonProperty("close", NullValueHandling = NullValueHandling.Ignore)]
        public double? Close { get; set; }

        [JsonProperty("high", NullValueHandling = NullValueHandling.Ignore)]
        public double? High { get; set; }

        [JsonProperty("low", NullValueHandling = NullValueHandling.Ignore)]
        public double? Low { get; set; }

        [JsonProperty("volume", NullValueHandling = NullValueHandling.Ignore)]
        public long? Volume { get; set; }

        [JsonProperty("uOpen", NullValueHandling = NullValueHandling.Ignore)]
        public double? UOpen { get; set; }

        [JsonProperty("uClose", NullValueHandling = NullValueHandling.Ignore)]
        public double? UClose { get; set; }

        [JsonProperty("uHigh", NullValueHandling = NullValueHandling.Ignore)]
        public double? UHigh { get; set; }

        [JsonProperty("uLow", NullValueHandling = NullValueHandling.Ignore)]
        public double? ULow { get; set; }

        [JsonProperty("uVolume", NullValueHandling = NullValueHandling.Ignore)]
        public long? UVolume { get; set; }

        [JsonProperty("change", NullValueHandling = NullValueHandling.Ignore)]
        public double? Change { get; set; }

        [JsonProperty("changePercent", NullValueHandling = NullValueHandling.Ignore)]
        public double? ChangePercent { get; set; }

        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; }

        [JsonProperty("changeOverTime", NullValueHandling = NullValueHandling.Ignore)]
        public double? ChangeOverTime { get; set; }
    }
}
