using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace PEPRN231_SU24TrialTest_StudentFullname_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StyleController : ControllerBase
    {
        private readonly StyleRepository _styleRepository;
        public StyleController()
        {
            _styleRepository = new StyleRepository();
        }

        [HttpGet("all")]
        [Authorize(Roles = "2,3")]
        public IActionResult GetAll()
        {
            var result = _styleRepository.GetAllStyles();
            return Ok(result);
        }
    }
}
