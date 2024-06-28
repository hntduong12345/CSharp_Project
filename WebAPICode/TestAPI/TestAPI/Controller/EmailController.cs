using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;
using TestAPI.Services;

namespace TestAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult TestEmail()
        {
            var message = new Message(new string[] {"hntduong2003@gmail.com"}, "Test", "Testing Email Send API");

            _emailService.sendEmail(message);
            return StatusCode(StatusCodes.Status200OK,
                new Response {Status = "Susscess", Message = "Email Sent Successfully!" });
        }
    }
}
