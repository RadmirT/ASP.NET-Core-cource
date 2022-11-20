using Microsoft.AspNetCore.Mvc;
using SampleApplication.ServicesLayer;

namespace SampleApplication.Controllers
{
    public class UserController : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult RegisterUser(string username)
        {
            var emailSender = new EmailSender();
            emailSender.SendEmail(username);
            return Ok();
        }
    }

    //[ApiController]
    //[Route("[controller]")]
    //public class UserController : ControllerBase
    //{
    //    [HttpPost("register")]
    //    public IActionResult RegisterUser(string username)
    //    {
    //        var emailSender = new EmailSender(
    //            new MessageFactory(),
    //            new NetworkClient(
    //                new EmailServerSettings
    //                {
    //                    Host = "smtp.server.com",
    //                    Port = 25
    //                })
    //            );
    //        emailSender.SendEmail(username);
    //        return this.Ok("Email sent!");
    //    }
    //}
}
