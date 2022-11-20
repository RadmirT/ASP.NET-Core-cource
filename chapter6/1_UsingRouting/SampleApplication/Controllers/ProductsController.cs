using Microsoft.AspNetCore.Mvc;

namespace SampleApplication.Controllers
{

    [Route("[controller]/[action]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return this.Ok();
        }

        [Route("{category}")]
        [HttpGet]
        public IActionResult Index(string category)
        {
            return this.Ok();
        }

        [HttpGet]
        public IActionResult Promo()
        {
            return this.Ok();
        }

        [HttpGet]
        public IActionResult Recommended()
        {
            return this.Ok();
        }
    }
}
