using ITCenterBO.DTOs.Request.OwnedLesson;
using ITCenterBO.DTOs.Response.OwnedLesson;
using ITCenterBO.Paginate;
using ITCenterController.Constants;
using ITCenterService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITCenterController.Controllers
{
    [ApiController]
    [Authorize]
    public class OwnedLessonController : ControllerBase
    {
        private readonly IOwnedLessonService _ownedLessonService;

        public OwnedLessonController(IOwnedLessonService ownedLessonService)
        {
            _ownedLessonService = ownedLessonService;
        }

        [HttpGet(ApiEndPointConstant.OwnedLesson.OwnedLessonsEndPoint)]
        [ProducesResponseType(typeof(IPaginate<GetOwnedLessonResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllOwnedLessonsOfCourse(int accountId, int page, int size)
        {
            return Ok(await _ownedLessonService.GetOwnedLessons(accountId, page, size));
        }

        [HttpPost(ApiEndPointConstant.OwnedLesson.OwnedLessonsEndPoint)]
        public async Task<IActionResult> CreateOwnedLesson(int courseId, int accountId)
        {
            await _ownedLessonService.CreateOwnedLesson(courseId, accountId);
            return Ok();
        }

        [HttpPatch(ApiEndPointConstant.OwnedLesson.OwnedLessonStatusEndPoint)]
        public async Task<IActionResult> ChangeOwnedLessonStatus(int id)
        {
            bool result = await _ownedLessonService.ChangeOwnedLessonStatus(id);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet(ApiEndPointConstant.OwnedLesson.OwnedLessonProgressEndPoint)]
        public async Task<IActionResult> GetOwnedLessonProgress(int accountId, int courseId)
        {
            return Ok(await _ownedLessonService.GetOwnedLessonProgress(accountId, courseId));
        }
    }
}
