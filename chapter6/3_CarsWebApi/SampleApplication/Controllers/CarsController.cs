using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApplication.Model;

namespace CarsWebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private static List<Car> Cars = new List<Car> { };

        string _carsAsXml = "<cars><car>Nissan Micra</car><car>FordFocus</car><car>Opel Zafira</car></cars>";

        [HttpGet("start")]
        [HttpGet("ignition")]
        [HttpGet("/start-car")]
        [HttpGet("")]
        public IEnumerable<string> ListCars()
        {
            return new string[]
                { "Nissan Micra", "Ford Focus", "Opel Zafira" };
        }

        [HttpGet("null")]
        public IActionResult Null()
        {
            return Ok(null);
        }
        [HttpGet("string")]
        public IActionResult Str()
        {
            return Ok("Nissan Micra, Ford Focus, Opel Zafira");
        }

        [HttpGet("content")]
        public string ListCarsAsContent()
        {
            return _carsAsXml;
        }

        [HttpGet("xml")]
        public IActionResult ListCarsAsXml()
        {
            return Content(_carsAsXml, "text/xml");
        }

        [HttpGet("json")]
        public IActionResult ListCarsAsJson()
        {
            return new JsonResult(new string[]
                { "Nissan Micra", "FordFocus" });
        }

        [HttpPost]
        public IActionResult Add(Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Cars.Add(car);
            return Ok();
        }
    }
}
