using BO.DTOs;
using DAO.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Service;

namespace PEPRN231_SU24_009909_HuynhNguyenThaiDuong_BE.Controllers
{
    public class FootballPlayerController : ODataController
    {
        public readonly IFootballPlayerService _footballPlayerService;
        public FootballPlayerController(IFootballPlayerService footballPlayerService)
        {
            _footballPlayerService = footballPlayerService;
        }

        [EnableQuery]
        [Authorize(Roles = "1,2")]
        public async Task<IActionResult> Get()
        {
            var result = await _footballPlayerService.GetAll();
            return Ok(result);
        }

        [EnableQuery]
        [Authorize(Roles = "1,2")]
        public async Task<IActionResult> Get([FromRoute] string key)
        {
            var result = await _footballPlayerService.GetById(key);
            if (result == null) return BadRequest("Cannot find painting");

            return Ok(result);
        }

        [Authorize(Roles = "1")]
        public async Task<IActionResult> Post([FromBody] FootballPlayerDTO player)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();

                return BadRequest(errors);
            }

            if (!InputUtil.CheckCapitalLetter(player.FullName))
            {
                return BadRequest("Invalid PaintingName format");
            }

            if (player.Birthday >= DateTime.Parse("01-01-2007"))
            {
                return BadRequest("Invalid Birthdate (Must < 01-01-2007)");
            }

            if (player.Nomination.Length < 9 || player.Nomination.Length > 100)
            {
                return BadRequest("Invalid Nomination length (must in 9-100 characters)");
            }

            if (player.Achievements.Length < 9 || player.Achievements.Length > 100)
            {
                return BadRequest("Invalid Achievements length (must in 9-100 characters)");
            }

            var result = await _footballPlayerService.Create(player);
            if (result.StatusCode == -1) return Conflict(result.Message);
            return Ok(result.Message);
        }

        [Authorize(Roles = "1")]
        public async Task<IActionResult> Put([FromRoute] string key, [FromBody] UpdateFootballPlayerDTO player)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();

                return BadRequest(errors);
            }

            if (!InputUtil.CheckCapitalLetter(player.FullName))
            {
                return BadRequest("Invalid PaintingName format");
            }

            if(player.Birthday >= DateTime.Parse("01-01-2007"))
            {
                return BadRequest("Invalid Birthdate (Must < 01-01-2007)");
            }

            if(player.Nomination.Length<9 || player.Nomination.Length > 100)
            {
                return BadRequest("Invalid Nomination length (must in 9-100 characters)");
            }

            if (player.Achievements.Length < 9 || player.Achievements.Length > 100)
            {
                return BadRequest("Invalid Achievements length (must in 9-100 characters)");
            }

            var result = await _footballPlayerService.Update(key, player);
            if (result.StatusCode == -1) return Conflict(result.Message);
            return Ok(result.Message);
        }

        [Authorize(Roles = "1")]
        public async Task<IActionResult> Delete([FromRoute] string key)
        {
            var result = await _footballPlayerService.Delete(key);
            if (result.StatusCode == -1) return Conflict(result.Message);
            return Ok(result.Message);
        }

        [EnableQuery]
        [Authorize(Roles = "1,2")]
        [HttpGet("FootballPlayer/search")]
        public async Task<IActionResult> GetSearch([FromBody]SearchDTO value)
        {
            try
            {
                var result = await _footballPlayerService.Search(value.Achivement, value.Nomination);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }
    }
}
