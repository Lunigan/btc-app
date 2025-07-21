using Btc.App.ViewModels;

namespace Btc.App.Services.Interfaces
{
    public interface IBtcService
    {
        Task<bool> CheckForUpdates(DateTime lastTimestamp);
        Task DeleteSnapshots(List<int> ids);
        Task<List<BtcRateRecordViewModel>> GetLatestBtcRateRecords();
        Task<List<BtcRateRecordViewModel>> GetSnapshots();
        Task<bool> SaveRecord(BtcRateRecordViewModel viewModel);
    }
}
