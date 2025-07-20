using Btc.App.ViewModels;

namespace Btc.App.Services.Interfaces
{
    public interface ICurrencyService
    {
        List<CurrencyRateViewModel> GetLatestRates();
    }
}
