using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using PRNAssignment.Models;
using PRNAssignment.Services.FirebaseService;

namespace PRNAssignment.Controllers
{
    [Route("api/lockers")]
    [ApiController]
    public class LockerController : ControllerBase
    {
        private readonly IFirebaseService _firebaseService;
        public LockerController (IFirebaseService firebaseService)
        {
            _firebaseService = firebaseService;
            _firebaseService.CreateConnection();
        }

        [HttpPost]
        public async Task<IActionResult> UploadOrUpdateData(Locker locker)
        {
            string res = await _firebaseService.UploadData(locker);
            if (res.Equals("Success"))
            {
                return Ok("Success");
            }
            return StatusCode(StatusCodes.Status500InternalServerError, res);
        }

        [HttpGet]
        public async Task<IActionResult> GetAvailableLockers()
        {
            List<Locker> lockers = await _firebaseService.GetAvailableLocker();
            if(lockers != null)
            {
                return Ok(lockers);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
