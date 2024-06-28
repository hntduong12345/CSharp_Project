using ITCenterBO.DTOs.Request.Lesson;
using ITCenterBO.DTOs.Response.Lesson;
using ITCenterBO.Paginate;
using ITCenterController.Constants;
using ITCenterService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITCenterController.Controllers
{
    [ApiController]
    [Authorize]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet(ApiEndPointConstant.Lesson.LessonsEndPoint)]
        [ProducesResponseType(typeof(IPaginate<GetLessonResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllLessonsOfCourse(int courseId)
        {
            return Ok(await _lessonService.GetAllLessonsOfCourse(courseId));
        }

        [HttpPost(ApiEndPointConstant.Lesson.LessonsEndPoint)]
        public async Task<IActionResult> CreateLesson(CreateLessonRequest createLessonRequest)
        {
            await _lessonService.CreateLesson(createLessonRequest);
            return Ok();
        }

        [HttpPatch(ApiEndPointConstant.Lesson.LessonEndPoint)]
        [ProducesResponseType(typeof(UpdateLessonResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateLessonInformation(int id, UpdateLessonRequest updateLessonRequest)
        {
            UpdateLessonResponse response = await _lessonService.UpdateLessonInformation(id, updateLessonRequest);

            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete(ApiEndPointConstant.Lesson.LessonDeleteEndPoint)]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            bool result = await _lessonService.DeleteLesson(id);
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
