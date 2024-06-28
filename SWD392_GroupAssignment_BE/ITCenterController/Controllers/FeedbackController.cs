using ITCenterBO.DTOs.Request.Feedback;
using ITCenterBO.Models;
using ITCenterBO.Paginate;
using ITCenterController.Constants;
using ITCenterService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITCenterController.Controllers
{
    [ApiController]
    [Authorize]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet(ApiEndPointConstant.Feedback.FeedbacksEndPoint)]
        [ProducesResponseType(typeof(IPaginate<Feedback>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllFeedbacks(int page, int size)
        {
            return Ok(await _feedbackService.GetAllFeedbacks(page, size));
        }

        [HttpPost(ApiEndPointConstant.Feedback.FeedbacksEndPoint)]
        public async Task<IActionResult> CreateFeedback([FromBody] CreateFeedbackRequest request)
        {
            _feedbackService.CreateFeedBack(request);
            return Ok();
        }

        [HttpPatch(ApiEndPointConstant.Feedback.FeedbackStatusEndPoint)]
        public async Task<IActionResult> ChangeFeedbackStatus(int id)
        {
            bool result = await _feedbackService.ChangeStatus(id);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
