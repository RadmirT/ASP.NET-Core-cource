using Microsoft.AspNetCore.Mvc;

namespace SampleApplication.Controllers
{
    public class AppointmentController : ControllerBase
    {
        [HttpGet("/appointments")]  //Выполняется только в ответ на GET-запрос к URL-адресу /appointments
        public IActionResult ListAppointments()
        {
            return Ok();
        }

        [HttpPost("/appointments")] // Выполняется только в ответ на POST-запрос к URL-адресу /appointments
        public IActionResult CreateAppointment()
        {
            return Ok();
        }
    }
}
