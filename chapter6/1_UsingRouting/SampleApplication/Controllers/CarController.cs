using Microsoft.AspNetCore.Mvc;

namespace SampleApplication.Controllers
{
    [ApiController]
    public class CarController : ControllerBase
    {
        [Route("car/start")] //Метод Start будет выполнен при совпадении любого из этих шаблонов маршрута
        [Route("car/ignition")]
        [Route("start-car")]
        [HttpGet]
        public IActionResult Start() // Имя метода действия не влияет на шаблон маршрута
        {
            return Ok();
        }

        [Route("car/speed/{speed}")] //Шаблон RouteAttribute может содержать параметры маршрута, в данном случае { speed }
        [Route("set-speed/{speed}")]
        [HttpGet]
        public IActionResult SetCarSpeed(int speed)
        {
            return Ok();
        }
    }
}
