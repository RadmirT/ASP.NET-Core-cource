using Moq;
using NUnit.Framework;
using SampleApplication.Controllers;
using SampleApplication.ServicesLayer;

namespace SampleApplication.UnitTests
{
    [TestFixture]
    public class UserControllerTest
    {
        [Test]
        public void RegisterUserTest()
        {
            var emailSenderMock = new Mock<IEmailSender>();
            var username = "testuser";
            emailSenderMock.Setup(o => o.SendEmail(username)).Verifiable();

            var controller = new UserController(emailSenderMock.Object);
            controller.RegisterUser(username); 
            emailSenderMock.Verify();
        }

    }
}