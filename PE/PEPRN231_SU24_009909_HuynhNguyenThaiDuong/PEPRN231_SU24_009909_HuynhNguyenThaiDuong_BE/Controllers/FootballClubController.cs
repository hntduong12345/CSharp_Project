using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace PEPRN231_SU24_009909_HuynhNguyenThaiDuong_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballClubController : ControllerBase
    {
        private readonly IFootballClubService _footballClubService;
        public FootballClubController(IFootballClubService footballClubService)
        {
            _footballClubService = footballClubService;
        }

        [HttpGet("all")]
        [Authorize(Roles = "1,2")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _footballClubService.GetAllClubs();
            return Ok(result);
        }
    }
}
