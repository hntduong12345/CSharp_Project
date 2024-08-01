using BO.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Repository;
using System.Xml.Linq;

namespace NET1711_231_ASM1_SE171581_HuynhNguyenThaiDuong_OData.Controllers
{
    public class BlogCategoryController : ODataController
    {
        private readonly IBlogCategoryRepo _blogCategoryRepo;
        public BlogCategoryController(IBlogCategoryRepo blogCategoryRepo)
        {
            _blogCategoryRepo = blogCategoryRepo;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            var result = _blogCategoryRepo.GetAllCateogries();
            return Ok(result);
        }

        [EnableQuery]
        public IActionResult Get([FromRoute] int key)
        {
            var result = _blogCategoryRepo.GetBlogCategory(key);
            if (result == null)
                return NotFound("Cannot find category");
            return Ok(result);
        }

        public IActionResult Post([FromBody]BlogCategoryDTO category)
        {
            var result = _blogCategoryRepo.CreateBlogCatefory(category);
            if(result != null)
                return Created(result);
            return Conflict("Id has already used");
        }

        public IActionResult Put([FromRoute] int key, UpdateBlogCategoryDTO updateInfo)
        {
            var result = _blogCategoryRepo.UpdateBlogCategory(key, updateInfo);
            if (result != null)
                return Updated(result);
            return NotFound("Cannot find category");
        }

        public IActionResult Delete([FromRoute] int key)
        {
            var result = _blogCategoryRepo.DeleteBlogCatefory(key);
            if (result)
                return Ok("Action successfully");
            return NotFound("Cannot find category");
        }
    }
}
