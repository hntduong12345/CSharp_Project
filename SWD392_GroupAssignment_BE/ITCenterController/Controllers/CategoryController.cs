using ITCenterBO.DTOs.Request.Category;
using ITCenterBO.DTOs.Response.Category;
using ITCenterBO.Models;
using ITCenterBO.Paginate;
using ITCenterController.Constants;
using ITCenterService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITCenterController.Controllers
{
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ICourseService _courseService;

        public CategoryController(ICategoryService categoryService, ICourseService courseService)
        {
            _categoryService = categoryService;
            _courseService = courseService;
        }

        [HttpGet(ApiEndPointConstant.Category.CategoriesEndPoint)]
        [ProducesResponseType(typeof(IPaginate<GetCategoryResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCategories(int page, int size)
        {
            return Ok(await _categoryService.GetAllCategories(page, size));
        }

        [HttpPost(ApiEndPointConstant.Category.CategoriesEndPoint)]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequest createCategoryRequest)
        {
            _categoryService.CreateCategory(createCategoryRequest);
            return Ok();
        }

        [HttpPatch(ApiEndPointConstant.Category.CategoryEndPoint)]
        [ProducesResponseType(typeof(UpdateCategoryResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateCategoryInformation(int id, UpdateCategoryRequest updateCategoryRequest)
        {
            UpdateCategoryResponse response = await _categoryService.UpdateCategoryInformation(id, updateCategoryRequest);

            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet(ApiEndPointConstant.Category.CoursesOfCategoryEndPoint)]
        [ProducesResponseType(typeof(IPaginate<Course>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCoursesByCategoryName(string name, int page, int size)
        {
            try
            {
                var result = await _courseService.GetCoursesByCategoryName(name, page, size);
                return Ok(result);
            }
            catch (Exception ex)
            {
                if(ex.GetType() == typeof(BadHttpRequestException))
                {
                    return BadRequest(ex.Message);
                }   
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet(ApiEndPointConstant.Category.RandomCategoryEndPoint)]
        [ProducesResponseType(typeof(GetCategoryResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRandomCategoy()
        {
            var result = await _categoryService.GetRandomCategoy();
            return Ok(result);
        }
    }
}
