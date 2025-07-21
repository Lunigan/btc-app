using Newtonsoft.Json;

namespace Btc.App.ViewModels
{
    public class BtcRateRecordViewModel
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("instrument")]
        public string Instrument { get; set; } = "BTC-EUR";

        [JsonProperty("btcEurPrice")]
        public decimal BtcEurPrice { get; set; }

        [JsonProperty("eur2Czk")]
        public decimal Eur2Czk { get; set; }

        [JsonProperty("btcCzkPrice")]
        public decimal BtcCzkPrice => BtcEurPrice * Eur2Czk;

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }
    }
}
