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

        public async Task<IActionResult> Index()
        {
            var viewModel = new DashboardViewModel
            {
                BtcRateRecords = await _btcService.GetLatestBtcRateRecords()
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Currencies()
        {
            var viewModel = new DashboardViewModel
            {
                CurrencyRates = await _currencyService.GetLatestRates()
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Snapshots()
        {
            var viewModel = new DashboardViewModel
            {
                BtcRateRecordSnapshots = await _btcService.GetSnapshots()
            };
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
