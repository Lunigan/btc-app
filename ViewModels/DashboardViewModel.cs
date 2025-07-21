namespace Btc.App.ViewModels
{
    public class DashboardViewModel
    {
        public List<CurrencyRateViewModel> CurrencyRates { get; set; }
        public List<BtcRateRecordViewModel> BtcRateRecords { get; set; }
        public List<BtcRateRecordViewModel> BtcRateRecordSnapshots { get; set; }
    }
}
