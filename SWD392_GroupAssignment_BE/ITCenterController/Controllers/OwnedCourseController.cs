using ITCenterBO.DTOs.Request.OwnedCourse;
using ITCenterBO.DTOs.Response.OwnedCourse;
using ITCenterBO.Paginate;
using ITCenterController.Constants;
using ITCenterService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITCenterController.Controllers
{
    [ApiController]
    [Authorize]
    public class OwnedCourseController : ControllerBase
    {
        private readonly IOwnedCourseService _ownedCourseService;

        public OwnedCourseController(IOwnedCourseService ownedCourseService)
        {
            _ownedCourseService = ownedCourseService;
        }

        [HttpGet(ApiEndPointConstant.OwnedCourse.OwnedCoursesEndPoint)]
        [ProducesResponseType(typeof(IPaginate<GetOwnedCourseResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllOwnedCourses(int accountId, int page, int size)
        {
            return Ok(await _ownedCourseService.GetOwnedCourse(accountId, page, size));
        }

        [HttpPost(ApiEndPointConstant.OwnedCourse.OwnedCoursesEndPoint)]
        public async Task<IActionResult> CreateOwnedCourse(CreateOwnedCourseRequest createOwnedCourseRequest)
        {
            await _ownedCourseService.CreateOwnedCourse(createOwnedCourseRequest);
            return Ok();
        }

        [HttpPatch(ApiEndPointConstant.OwnedCourse.OwnedCourseStatusEndPoint)]
        public async Task<IActionResult> ChangeOwnedCourseStatus(int id)
        {
            bool result = await _ownedCourseService.ChangeOwnedCourseStatus(id);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
