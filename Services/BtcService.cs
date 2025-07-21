using Btc.App.Services.Interfaces;
using Btc.App.ViewModels;

namespace Btc.App.Services
{
    public class BtcService : IBtcService
    {
        private readonly IHttpService _httpService;

        private const string BTC_API_BASE_URL = "https://localhost:44391/api/bitcoin/rates";
        private const string BTC_API_LATEST_URL = "/latest";
        private const string BTC_API_CHECK_URL = "/check";
        private const string BTC_API_SNAPSHOT_URL = "/snapshots";
        private const string BTC_API_SAVE_URL = "/save";
        private const string BTC_API_DELETE_MANY_URL = "/delete-many";

        public BtcService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<bool> CheckForUpdates(DateTime lastTimestamp)
        {
            return await _httpService
                .PostAsync($"{BTC_API_BASE_URL}{BTC_API_LATEST_URL}{BTC_API_CHECK_URL}", new { lastTimestamp });
        }

        public async Task DeleteSnapshots(List<int> ids)
        {
            await _httpService.PostAsync($"{BTC_API_BASE_URL}{BTC_API_SNAPSHOT_URL}{BTC_API_DELETE_MANY_URL}", ids);
        }

        public async Task<List<BtcRateRecordViewModel>> GetLatestBtcRateRecords()
        {
            var response = await _httpService
                .GetAsync<List<BtcRateRecordViewModel>>($"{BTC_API_BASE_URL}{BTC_API_LATEST_URL}");

            if (response == null || response.Count < 1) return [];

            return response;
        }

        public async Task<List<BtcRateRecordViewModel>> GetSnapshots()
        {
            var response = await _httpService
                .GetAsync<List<BtcRateRecordViewModel>>($"{BTC_API_BASE_URL}{BTC_API_SNAPSHOT_URL}");

            if (response == null || response.Count < 1) return [];

            return response;
        }

        public async Task<bool> SaveRecord(BtcRateRecordViewModel viewModel)
        {
            return await _httpService.PostAsync($"{BTC_API_BASE_URL}{BTC_API_SNAPSHOT_URL}{BTC_API_SAVE_URL}", viewModel);
        }
    }
}
