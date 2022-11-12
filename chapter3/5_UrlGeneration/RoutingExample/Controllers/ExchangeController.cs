using Microsoft.AspNetCore.Mvc;

namespace RoutingExample.Controllers
{

    public class ExchangeController : Controller
    {
        [HttpGet("exch/{from}/{to}")]
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
