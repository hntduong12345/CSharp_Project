using BO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace PEPRN231_SU24TrialTest_StudentFullname_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly UserAccountRepository _userAccountRepository;
        public UserAccountController()
        {
            _userAccountRepository = new UserAccountRepository();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthenticationDTO request)
        {
            AuthenDTO result = await _userAccountRepository.Login(request);
            if(result != null)
            {
                return Ok(result.Token);
            }

            return BadRequest("Incorrect UserName Or Password");
        }
    }
}
