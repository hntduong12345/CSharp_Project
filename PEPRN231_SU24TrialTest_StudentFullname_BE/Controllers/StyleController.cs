using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service;

namespace PEPRN231_SU24TrialTest_StudentFullname_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StyleController : ControllerBase
    {
        private readonly  IStyleService _styleService;
        public StyleController(IStyleService styleService)
        {
            _styleService = styleService;
        }

        [HttpGet("all")]
        [Authorize(Roles = "2,3")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _styleService.GetAllStyles();
            return Ok(result);
        }
    }
}
