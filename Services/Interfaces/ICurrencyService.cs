using Btc.App.ViewModels;

namespace Btc.App.Services.Interfaces
{
    public interface ICurrencyService
    {
        Task<List<CurrencyRateViewModel>> GetLatestRates();
    }
}
