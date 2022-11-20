using Microsoft.AspNetCore.Mvc;

namespace SampleApplication.Controllers
{
    [ApiController]
    public class FruitController : ControllerBase
    {
        private readonly List<string> _fruit = new List<string>
        {
            "Pear",
            "Lemon",
            "Peach"
        };

        [HttpGet("fruits")]
        public IEnumerable<string> Index()
        {
            return _fruit;
        }

        [HttpGet("fruits/{id}")]
        public ActionResult<string> View(int id)
        {
            if (id >= 0 && id < _fruit.Count)
            {
                return _fruit[id];
            }

            return NotFound();
        }
    }
}
