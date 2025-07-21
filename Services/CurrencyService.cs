using Btc.App.Services.Interfaces;
using Btc.App.ViewModels;

namespace Btc.App.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IHttpService _httpService;

        private const string CURRENCY_API_BASE_URL = "https://localhost:44391/api/currency/rates";
        private const string CURRENCY_API_LATEST_URL = "/latest";

        public CurrencyService(
            IHttpService httpService
        )
        {
            _httpService = httpService;
        }

        /// <summary>
        /// Gets Latest currency rates from API backend
        /// </summary>
        /// <returns></returns>
        public async Task<List<CurrencyRateViewModel>> GetLatestRates()
        {
            var response = await _httpService
                .GetAsync<List<CurrencyRateViewModel>>($"{CURRENCY_API_BASE_URL}{CURRENCY_API_LATEST_URL}");

            if (response == null || response.Count < 1) return [];

            return response;
        }
    }
}
