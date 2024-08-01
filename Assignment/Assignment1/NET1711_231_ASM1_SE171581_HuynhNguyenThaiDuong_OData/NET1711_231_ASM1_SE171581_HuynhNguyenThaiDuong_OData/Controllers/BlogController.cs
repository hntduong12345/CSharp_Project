using BO.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using MilkData.Models;
using Repository;
using System.Xml.Linq;

namespace NET1711_231_ASM1_SE171581_HuynhNguyenThaiDuong_OData.Controllers
{
    public class BlogController : ODataController
    {
        private readonly IBlogRepo _blogRepo;
        public BlogController(IBlogRepo blogRepo)
        {
            _blogRepo = blogRepo;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            var result = _blogRepo.GetAllBlogs();
            return Ok(result);
        }

        [EnableQuery]
        public IActionResult Get([FromRoute] int key)
        {
            var result = _blogRepo.GetBlog(key);
            if (result == null)
                return NotFound("Cannot find blog");
            return Ok(result);
        }

        public IActionResult Post([FromBody]BlogDTO blog)
        {
            var result = _blogRepo.CreateBlog(blog);
            if (result != null)
                return Created(result);
            return Conflict("Id has already used");
        }

        public IActionResult Put([FromRoute] int key, UpdateBlogDTO updateInfo)
        {
            var result = _blogRepo.UpdateBlog(key, updateInfo);
            if (result != null)
                return Updated(result);
            return NotFound("Cannot find blog");
        }

        public IActionResult Delete([FromRoute] int key)
        {
            var result = _blogRepo.DeleteBlog(key);
            if (result)
                return Ok("Action successfully");
            return NotFound("Cannot find blog");
        }
    }
}
