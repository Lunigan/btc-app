using Btc.App.Services.Interfaces;
using Btc.App.ViewModels;

namespace Btc.App.Services
{
    public class BtcService : IBtcService
    {
        public BtcService()
        {
            
        }

        /// <summary>
        /// TODO: implemenmt http serrvice and api call to get rate records from last 24h
        /// </summary>
        /// <returns></returns>
        public List<BtcRateRecordViewModel> GetLatestBtcRateRecords()
        {
            return new List<BtcRateRecordViewModel>
            {
                new BtcRateRecordViewModel
                {
                    BtcEurPrice = 102094.39M,
                    Eur2Czk = 24.21M,
                    Instrument = "BTC-EUR",
                    Timestamp = new DateTime(2025, 7, 20, 14, 34, 0)
                },
                new BtcRateRecordViewModel
                {
                    BtcEurPrice = 101094.39M,
                    Eur2Czk = 24.21M,
                    Instrument = "BTC-EUR",
                    Timestamp = new DateTime(2025, 7, 20, 14, 20, 0)
                },
                new BtcRateRecordViewModel
                {
                    BtcEurPrice = 104094.39M,
                    Eur2Czk = 24.21M,
                    Instrument = "BTC-EUR",
                    Timestamp = new DateTime(2025, 7, 20, 14, 05, 0)
                },
                new BtcRateRecordViewModel
                {
                    BtcEurPrice = 100094.39M,
                    Eur2Czk = 24.21M,
                    Instrument = "BTC-EUR",
                    Timestamp = new DateTime(2025, 7, 20, 13, 46, 0)
                },
                new BtcRateRecordViewModel
                {
                    BtcEurPrice = 106094.39M,
                    Eur2Czk = 24.21M,
                    Instrument = "BTC-EUR",
                    Timestamp = new DateTime(2025, 7, 20, 13, 34, 0)
                },
                new BtcRateRecordViewModel
                {
                    BtcEurPrice = 105094.39M,
                    Eur2Czk = 24.21M,
                    Instrument = "BTC-EUR",
                    Timestamp = new DateTime(2025, 7, 20, 13, 20, 0)
                },
                new BtcRateRecordViewModel
                {
                    BtcEurPrice = 110094.39M,
                    Eur2Czk = 24.21M,
                    Instrument = "BTC-EUR",
                    Timestamp = new DateTime(2025, 7, 20, 12, 59, 0)
                },
                new BtcRateRecordViewModel
                {
                    BtcEurPrice = 115094.39M,
                    Eur2Czk = 24.21M,
                    Instrument = "BTC-EUR",
                    Timestamp = new DateTime(2025, 7, 20, 12, 46, 0)
                }
            }.OrderBy(x => x.Timestamp).ToList();
        }
    }
}
