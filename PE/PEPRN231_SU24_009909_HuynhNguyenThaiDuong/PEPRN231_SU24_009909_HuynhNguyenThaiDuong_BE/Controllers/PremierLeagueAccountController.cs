using BO.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace PEPRN231_SU24_009909_HuynhNguyenThaiDuong_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremierLeagueAccountController : ControllerBase
    {
        private readonly IPremierLeagueAccountService _premierLeagueAccountService;
        public PremierLeagueAccountController(IPremierLeagueAccountService premierLeagueAccountService)
        {
            _premierLeagueAccountService = premierLeagueAccountService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthenDTO request)
        {
            AuthenResponseDTO result = await _premierLeagueAccountService.Login(request);
            if (result != null)
            {
                return Ok(result.Token);
            }

            return BadRequest("Incorrect UserName Or Password");
        }
    }
}
