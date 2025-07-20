using System.Diagnostics;
using Btc.App.Models;
using Btc.App.Services.Interfaces;
using Btc.App.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Btc.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBtcService _btcService;
        private readonly ICurrencyService _currencyService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            IBtcService btcService,
            ICurrencyService currencyService,
            ILogger<HomeController> logger
        )
        {
            _btcService = btcService;
            _currencyService = currencyService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var rateViewModel = _currencyService.GetLatestRates();
            var btcViewModel = _btcService.GetLatestBtcRateRecords();

            var viewModel = new DashboardViewModel
            {
                BtcRateRecords = btcViewModel,
                CurrencyRates = rateViewModel
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
