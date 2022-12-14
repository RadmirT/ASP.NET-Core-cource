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

        [HttpGet("fruit")]
        public IEnumerable<string> Index()
        {
            return this._fruit;
        }

        [HttpGet("fruit/{id}")]
        public ActionResult<string> View(int id)
        {
            if (id >= 0 && id < this._fruit.Count)
            {
                return this._fruit[id];
            }

            return this.NotFound();
        }
    }
}
