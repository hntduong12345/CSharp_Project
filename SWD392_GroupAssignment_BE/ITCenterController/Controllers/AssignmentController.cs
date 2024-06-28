using ITCenterBO.DTOs.Request.Assignment;
using ITCenterBO.DTOs.Response.Assignment;
using ITCenterController.Constants;
using ITCenterService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITCenterController.Controllers
{
    [Controller]
    [Authorize]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;
        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        [HttpGet(ApiEndPointConstant.Assignment.AssignmentInCourseEndPoint)]
        [ProducesResponseType(typeof(IList<GetAssignmentResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAssignmentsInCourse(int courseId)
        {
            return Ok(await _assignmentService.GetAssignmentsInCourse(courseId));
        }

        [HttpGet(ApiEndPointConstant.Assignment.AssignmentDetailEndPoint)]
        [ProducesResponseType(typeof(GetAssignmentResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAssignmentById(int assignmentId)
        {
            return Ok(await _assignmentService.GetAssignmentById(assignmentId));
        }

        [HttpPost(ApiEndPointConstant.Assignment.AssignmentCreOrUpdEndPoint)]
        public async Task<IActionResult> CreateAssignment([FromBody] CreateAssignmentRequest request)
        {
            _assignmentService.CreateAssignment(request);
             return Ok();
        }

        [HttpPut(ApiEndPointConstant.Assignment.AssignmentCreOrUpdEndPoint)]
        [ProducesResponseType(typeof(UpdateAssignmentResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAssignment([FromBody] UpdateAssignmentRequest request)
        {
            await _assignmentService.UpdateAssignment(request);
            return Ok();
        }
    }
}
