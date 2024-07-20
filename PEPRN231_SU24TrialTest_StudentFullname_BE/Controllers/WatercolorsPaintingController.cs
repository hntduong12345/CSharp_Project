using BO;
using BO.Models;
using DataAccessObject.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository;

namespace PEPRN231_SU24TrialTest_StudentFullname_BE.Controllers
{
    public class WatercolorsPaintingController : ODataController
    {
        public WatercolorsPaintingRepository _watercolorsPaintingRepository;
        public WatercolorsPaintingController()
        {
            _watercolorsPaintingRepository = new WatercolorsPaintingRepository();
        }

        [EnableQuery]
        [Authorize(Roles = "2,3")]
        public IActionResult Get()
        {
            var result = _watercolorsPaintingRepository.GetAll();
            return Ok(result);
        }

        [EnableQuery]
        [Authorize(Roles = "2,3")]
        public IActionResult Get([FromRoute]string key)
        {
            var result = _watercolorsPaintingRepository.GetById(key);
            if (result == null) return BadRequest("Cannot find painting");

            return Ok(result);
        }

        [Authorize(Roles = "3")]
        public IActionResult Post([FromBody] WatercolorsPaintingDTO paint)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();

                return BadRequest(errors);
            }

            if (!InputUtil.CheckCapitalLetter(paint.PaintingName))
            {
                return BadRequest("Invalid PaintingName format");
            }

            var result = _watercolorsPaintingRepository.Create(paint);
            if (result.StatusCode == -1) return Conflict(result.Message);
            return Ok(result.Message);
        }

        [Authorize(Roles = "3")]
        public IActionResult Put([FromRoute] string key, [FromBody]UpdateWatercolorsPaintingDTO paint)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();

                return BadRequest(errors);
            }

            if (!InputUtil.CheckCapitalLetter(paint.PaintingName))
            {
                return BadRequest("Invalid PaintingName format");
            }

            var result = _watercolorsPaintingRepository.Update(key, paint);
            if (result.StatusCode == -1) return Conflict(result.Message);
            return Ok(result.Message);
        }

        [Authorize(Roles = "3")]
        public IActionResult Delete([FromRoute]string key)
        {
            var result = _watercolorsPaintingRepository.Delete(key);
            if (result.StatusCode == -1) return Conflict(result.Message);
            return Ok(result.Message);
        }

        [EnableQuery]
        [Authorize(Roles = "2,3")]
        [HttpGet("WatercolorsPainting/search")]
        public IActionResult GetSearch(string searchValue)
        {
            var result = _watercolorsPaintingRepository.Search(searchValue);
            return Ok(result);
        }
    }
}