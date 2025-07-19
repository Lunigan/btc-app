using Microsoft.AspNetCore.Mvc;

namespace Btc.App.Controllers
{
    public class SavedDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
