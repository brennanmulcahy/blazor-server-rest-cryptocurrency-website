using Newtonsoft.Json;

namespace CryptoWebsite.Models
{
    public class CryptoExchange
    {
        [JsonProperty("exchange_id")]
        public string? ExchangeId { get; set; }

        [JsonProperty("website")]
        public Uri? Website { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("data_start")]
        public DateTimeOffset? DataStart { get; set; }

        [JsonProperty("data_end")]
        public DateTimeOffset? DataEnd { get; set; }

        [JsonProperty("data_quote_start")]
        public DateTimeOffset? DataQuoteStart { get; set; }

        [JsonProperty("data_quote_end")]
        public DateTimeOffset? DataQuoteEnd { get; set; }

        [JsonProperty("data_orderbook_start")]
        public DateTimeOffset? DataOrderbookStart { get; set; }

        [JsonProperty("data_orderbook_end")]
        public DateTimeOffset? DataOrderbookEnd { get; set; }

        [JsonProperty("data_trade_start")]
        public DateTimeOffset? DataTradeStart { get; set; }

        [JsonProperty("data_trade_end")]
        public DateTimeOffset? DataTradeEnd { get; set; }

        [JsonProperty("data_symbols_count")]
        public long? DataSymbolsCount { get; set; }

        [JsonProperty("volume_1hrs_usd")]
        public double? Volume1HrsUsd { get; set; }

        [JsonProperty("volume_1day_usd")]
        public double? Volume1DayUsd { get; set; }

        [JsonProperty("volume_1mth_usd")]
        public double? Volume1MthUsd { get; set; }
    }
}
