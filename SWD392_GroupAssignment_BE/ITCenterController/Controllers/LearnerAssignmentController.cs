using ITCenterBO.DTOs.Request.LearnerAssignment;
using ITCenterBO.DTOs.Response.LearnerAssignment;
using ITCenterController.Constants;
using ITCenterRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITCenterController.Controllers
{
    [Controller]
    [Authorize]
    public class LearnerAssignmentController: ControllerBase
    {
        private readonly ILearnerAssignmentService learnerAssignmentService;
        public LearnerAssignmentController()
        {
            if (learnerAssignmentService == null)
            {
                learnerAssignmentService = new LearnerAssignmentService();
            }
        }

        [HttpGet(ApiEndPointConstant.LearnerAssignment.LearnerAssignmentGetOneEndPoint)]
        [ProducesResponseType(typeof(GetLearnerAssignmentResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLearnerAssignment(int learnerAssignmentId)
        {
            return Ok(await learnerAssignmentService.GetLearnerAssignment(learnerAssignmentId));
        }

        [HttpPost(ApiEndPointConstant.LearnerAssignment.LearnerAssignmentCreOrUpdEndPoint)]
        public async Task<IActionResult> CreateLearnerAssignment([FromBody] CreateLearnerAssignmentRequest request)
        {
            learnerAssignmentService.CreateLeanerAssignment(request);
            return Ok();
        }

        [HttpPut(ApiEndPointConstant.LearnerAssignment.LearnerAssignmentCreOrUpdEndPoint)]
        [ProducesResponseType(typeof(UpdateLearnerAssignmentResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateLearnerAssignment([FromBody] UpdateLearnerAssignmentRequest request)
        {
            return Ok(await learnerAssignmentService.UpdateLearnerAssignment(request));
        }
    }
}
