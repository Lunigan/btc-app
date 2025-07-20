using Btc.App.ViewModels;

namespace Btc.App.Services.Interfaces
{
    public interface IBtcService
    {
        List<BtcRateRecordViewModel> GetLatestBtcRateRecords();
    }
}
