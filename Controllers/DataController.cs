using Btc.App.Services.Interfaces;
using Btc.App.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Btc.App.Controllers
{
    [Route("api/data")]
    public class DataController : Controller
    {
        private readonly IBtcService _btcService;

        public DataController(
            IBtcService btcService
        )
        {
            _btcService = btcService;
        }

        [HttpPost]
        [Route("latest/check")]
        public async Task<IActionResult> CheckFoUpdates(DateTime lastTimestamp)
        {
            return Ok(await _btcService.CheckForUpdates(lastTimestamp));
        }

        [HttpPost]
        [Route("delete-many")]
        public async Task<IActionResult> DeleteMany([FromBody] List<int> ids)
        {
            await _btcService.DeleteSnapshots(ids);
            return Ok();
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> Save([FromBody] BtcRateRecordViewModel viewModel)
        {
            var result = await _btcService.SaveRecord(viewModel);

            if (result) return Ok();

            return Problem(statusCode: 500);
        }
    }
}
