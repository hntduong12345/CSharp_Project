using ITCenterBO.DTOs.Request.Course;
using ITCenterBO.DTOs.Response.Course;
using ITCenterBO.Models;
using ITCenterBO.Paginate;
using ITCenterController.Constants;
using ITCenterService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITCenterController.Controllers
{
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IFileService _fileService;
        private readonly IOrderDetailService _orderDetailService;

        public CourseController(ICourseService courseService, IFileService fileService,
            IOrderDetailService orderDetailService)
        {
            _courseService = courseService;
            _fileService = fileService;
            _orderDetailService = orderDetailService;
        }

        [AllowAnonymous]
        [HttpGet(ApiEndPointConstant.Course.CoursesEndPoint)]
        [ProducesResponseType(typeof(IPaginate<GetCourseResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCourses(int page, int size)
        {
            return Ok(await _courseService.GetAllACourses(page, size));
        }

        [HttpPost(ApiEndPointConstant.Course.CoursesEndPoint)]
        [Authorize]
        public async Task<IActionResult> CreateCourse([FromForm]CreateCourseRequest createCourseRequest)
        {
            var stream = createCourseRequest.file.OpenReadStream();
            var filename = createCourseRequest.file.FileName;

            string imageUrl = await _fileService.UploadFile(stream, filename);

            createCourseRequest.ImageUrl = imageUrl;

            await _courseService.CreateCourse(createCourseRequest);
            return Ok();
        }

        [HttpPatch(ApiEndPointConstant.Course.CourseEndPoint)]
        [ProducesResponseType(typeof(UpdateCourseResponse), StatusCodes.Status200OK)]
        [Authorize]
        public async Task<IActionResult> UpdateCourseInformation(int id, [FromForm]UpdateCourseRequest updateCourseRequest)
        {
            var stream = updateCourseRequest.file.OpenReadStream();
            var filename = updateCourseRequest.file.FileName;

            string imageUrl = await _fileService.UploadFile(stream, filename);

            updateCourseRequest.ImageUrl = imageUrl;

            UpdateCourseResponse response = await _courseService.UpdateCourseInformation(id, updateCourseRequest);

            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPatch(ApiEndPointConstant.Course.CourseStatusEndPoint)]
        [Authorize]
        public async Task<IActionResult> ChangeCourseStatus(int id)
        {
            bool result = await _courseService.ChangeCourseStatus(id);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet(ApiEndPointConstant.Course.BestSellerCourseEndPoint)]
        public async Task<IActionResult> GetBestSellerCourses()
        {
            var bestSellerCourse = await _orderDetailService.GetBestSeller();

            List<GetCourseResponse> bestSellerCourseInfo = new List<GetCourseResponse>();
            foreach (var course in bestSellerCourse)
            {
                bestSellerCourseInfo.Add(_courseService.GetCourseById(course.Id).Result);
            }

            return Ok(bestSellerCourseInfo);
        }

        [HttpGet(ApiEndPointConstant.Course.CourseEndPoint)]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var result = await _courseService.GetCourseById(id);
            return Ok(result);
        }
    }
}
