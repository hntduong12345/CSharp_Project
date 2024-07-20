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
using Service;

namespace PEPRN231_SU24TrialTest_StudentFullname_BE.Controllers
{
    public class WatercolorsPaintingController : ODataController
    {
        public IWatercolorsPaintingService _watercolorsPaintingService;
        public WatercolorsPaintingController(IWatercolorsPaintingService watercolorsPaintingService)
        {
            _watercolorsPaintingService = watercolorsPaintingService;
        }

        [EnableQuery]
        [Authorize(Roles = "2,3")]
        public async Task<IActionResult> Get()
        {
            var result = await _watercolorsPaintingService.GetAll();
            return Ok(result);
        }

        [EnableQuery]
        [Authorize(Roles = "2,3")]
        public async Task<IActionResult> Get([FromRoute]string key)
        {
            var result = await _watercolorsPaintingService.GetById(key);
            if (result == null) return BadRequest("Cannot find painting");

            return Ok(result);
        }

        [Authorize(Roles = "3")]
        public async Task<IActionResult> Post([FromBody] WatercolorsPaintingDTO paint)
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

            var result = await _watercolorsPaintingService.Create(paint);
            if (result.StatusCode == -1) return Conflict(result.Message);
            return Ok(result.Message);
        }

        [Authorize(Roles = "3")]
        public async Task<IActionResult> Put([FromRoute] string key, [FromBody]UpdateWatercolorsPaintingDTO paint)
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

            var result = await _watercolorsPaintingService.Update(key, paint);
            if (result.StatusCode == -1) return Conflict(result.Message);
            return Ok(result.Message);
        }

        [Authorize(Roles = "3")]
        public async Task<IActionResult> Delete([FromRoute]string key)
        {
            var result = await _watercolorsPaintingService.Delete(key);
            if (result.StatusCode == -1) return Conflict(result.Message);
            return Ok(result.Message);
        }

        [EnableQuery]
        [Authorize(Roles = "2,3")]
        [HttpGet("WatercolorsPainting/search")]
        public async Task<IActionResult> GetSearch(string searchValue)
        {
            var result = await _watercolorsPaintingService.Search(searchValue);
            return Ok(result);
        }
    }
}