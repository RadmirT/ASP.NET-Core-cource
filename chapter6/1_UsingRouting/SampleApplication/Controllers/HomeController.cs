using Microsoft.AspNetCore.Mvc;

namespace SampleApplication.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [Route("")]   // Действие Index будет выполнено, когда будет выполнен запрос к URL-адресу
        [HttpGet]
        public IActionResult Index()
        {
            return this.Ok();
        }
        [Route("contact")]  //Действие Contact будет выполнено, когда будет выполнен запрос к URL-адресу /contact
        [HttpGet]
        public IActionResult Contact()
        {
            return this.Ok();
        }
    }
}

