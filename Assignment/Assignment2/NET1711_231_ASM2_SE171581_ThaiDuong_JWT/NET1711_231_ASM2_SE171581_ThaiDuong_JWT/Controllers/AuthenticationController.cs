using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NET1711_231_ASM2_SE171581_ThaiDuong_JWT.Models;
using NET1711_231_ASM2_SE171581_ThaiDuong_JWT.Payload.Request;
using NET1711_231_ASM2_SE171581_ThaiDuong_JWT.Utils;

namespace NET1711_231_ASM2_SE171581_ThaiDuong_JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthenticationRequest request)
        {
            Account account = AccountData.Accounts.FirstOrDefault(a => a.Email.Equals(request.Email) &&
                                                                       a.Password.Equals(request.Password));

            if (account == null) return BadRequest("Incorrect Email or Password");

            var token = JwtUtil.GenerateJwtToken(account);
            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AuthenticationRequest request)
        {
            Account account = AccountData.Accounts.FirstOrDefault(a => a.Email.Equals(request.Email));

            if (account != null) return BadRequest("The Email has already");

            Account newAccount = new Account()
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                Password = request.Password,
                PhoneNumber = String.Empty,
                UserName = String.Empty,
                Role = "Customer"
            };

            var token = JwtUtil.GenerateJwtToken(newAccount);
            return Ok(token);
        }

        [Authorize]
        [HttpGet("getAll")]
        public async Task<IActionResult> Test()
        {
            return Ok(AccountData.Accounts.ToList());
        }
    }
}
