using Btc.App.Services.Interfaces;
using Btc.App.ViewModels;

namespace Btc.App.Services
{
    public class CurrencyService : ICurrencyService
    {
        public CurrencyService()
        {
            
        }

        /// <summary>
        /// TODO: implemetn http service and call to API
        /// </summary>
        /// <returns></returns>
        public List<CurrencyRateViewModel> GetLatestRates()
        {
            return [
                new CurrencyRateViewModel
                { 
                    SourceCurrencyCode = "EUR", 
                    TargetCurrencyCode = "CZK",
                    Amount = 1,
                    Rate = 24.21M,
                    ValidFor = DateTime.Now
                },
                new CurrencyRateViewModel
                {
                    SourceCurrencyCode = "USD",
                    TargetCurrencyCode = "CZK",
                    Amount = 1,
                    Rate = 21.05M,
                    ValidFor = DateTime.Now
                }
            ];
        }
    }
}
