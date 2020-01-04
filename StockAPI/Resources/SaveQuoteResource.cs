using Newtonsoft.Json;

namespace StockAPI.Resources
{
    public class SaveQuoteResource
    {
        [JsonProperty("symbol", NullValueHandling = NullValueHandling.Ignore)]
        public string Symbol { get; set; }

        [JsonProperty("companyName", NullValueHandling = NullValueHandling.Ignore)]
        public string CompanyName { get; set; }

        [JsonProperty("primaryExchange", NullValueHandling = NullValueHandling.Ignore)]
        public string PrimaryExchange { get; set; }

        [JsonProperty("calculationPrice", NullValueHandling = NullValueHandling.Ignore)]
        public string CalculationPrice { get; set; }

        [JsonProperty("open", NullValueHandling = NullValueHandling.Ignore)]
        public double? Open { get; set; }

        [JsonProperty("openTime", NullValueHandling = NullValueHandling.Ignore)]
        public long? OpenTime { get; set; }

        [JsonProperty("close", NullValueHandling = NullValueHandling.Ignore)]
        public double? Close { get; set; }

        [JsonProperty("closeTime", NullValueHandling = NullValueHandling.Ignore)]
        public long? CloseTime { get; set; }

        [JsonProperty("high", NullValueHandling = NullValueHandling.Ignore)]
        public double? High { get; set; }

        [JsonProperty("low", NullValueHandling = NullValueHandling.Ignore)]
        public long? Low { get; set; }

        [JsonProperty("latestPrice", NullValueHandling = NullValueHandling.Ignore)]
        public double? LatestPrice { get; set; }

        [JsonProperty("latestSource", NullValueHandling = NullValueHandling.Ignore)]
        public string LatestSource { get; set; }

        [JsonProperty("latestTime", NullValueHandling = NullValueHandling.Ignore)]
        public string LatestTime { get; set; }

        [JsonProperty("latestUpdate", NullValueHandling = NullValueHandling.Ignore)]
        public long? LatestUpdate { get; set; }

        [JsonProperty("latestVolume", NullValueHandling = NullValueHandling.Ignore)]
        public long? LatestVolume { get; set; }


        [JsonProperty("delayedPrice", NullValueHandling = NullValueHandling.Ignore)]
        public double? DelayedPrice { get; set; }

        [JsonProperty("delayedPriceTime", NullValueHandling = NullValueHandling.Ignore)]
        public long? DelayedPriceTime { get; set; }

        [JsonProperty("extendedPrice", NullValueHandling = NullValueHandling.Ignore)]
        public double? ExtendedPrice { get; set; }

        [JsonProperty("extendedChange", NullValueHandling = NullValueHandling.Ignore)]
        public double? ExtendedChange { get; set; }

        [JsonProperty("extendedChangePercent", NullValueHandling = NullValueHandling.Ignore)]
        public double? ExtendedChangePercent { get; set; }

        [JsonProperty("extendedPriceTime", NullValueHandling = NullValueHandling.Ignore)]
        public long? ExtendedPriceTime { get; set; }

        [JsonProperty("previousClose", NullValueHandling = NullValueHandling.Ignore)]
        public double? PreviousClose { get; set; }

        [JsonProperty("previousVolume", NullValueHandling = NullValueHandling.Ignore)]
        public long? PreviousVolume { get; set; }

        [JsonProperty("change", NullValueHandling = NullValueHandling.Ignore)]
        public double? Change { get; set; }

        [JsonProperty("changePercent", NullValueHandling = NullValueHandling.Ignore)]
        public double? ChangePercent { get; set; }

        [JsonProperty("volume", NullValueHandling = NullValueHandling.Ignore)]
        public long? Volume { get; set; }


        [JsonProperty("avgTotalVolume", NullValueHandling = NullValueHandling.Ignore)]
        public long? AvgTotalVolume { get; set; }


        [JsonProperty("marketCap", NullValueHandling = NullValueHandling.Ignore)]
        public long? MarketCap { get; set; }

        [JsonProperty("peRatio", NullValueHandling = NullValueHandling.Ignore)]
        public double? PeRatio { get; set; }

        [JsonProperty("week52High", NullValueHandling = NullValueHandling.Ignore)]
        public double? Week52High { get; set; }

        [JsonProperty("week52Low", NullValueHandling = NullValueHandling.Ignore)]
        public double? Week52Low { get; set; }

        [JsonProperty("ytdChange", NullValueHandling = NullValueHandling.Ignore)]
        public double? YtdChange { get; set; }

        [JsonProperty("lastTradeTime", NullValueHandling = NullValueHandling.Ignore)]
        public long? LastTradeTime { get; set; }

        [JsonProperty("isUSMarketOpen", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsUsMarketOpen { get; set; }
    }
}
