using BO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service;

namespace PEPRN231_SU24TrialTest_StudentFullname_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountService _userAccountService;
        public UserAccountController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthenticationDTO request)
        {
            AuthenDTO result = await _userAccountService.Login(request);
            if(result != null)
            {
                return Ok(result.Token);
            }

            return BadRequest("Incorrect UserName Or Password");
        }
    }
}
