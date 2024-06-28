using ITCenterBO.DTOs.Request.Authentication;
using ITCenterBO.DTOs.Response.Authentication;
using ITCenterBO.DTOs.Response.Error;
using ITCenterController.Constants;
using ITCenterService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;

namespace ITCenterController.Controllers
{
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AuthenticationController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [AllowAnonymous]
        [HttpPost(ApiEndPointConstant.Authentication.LoginEndPoint)]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(UnauthorizedObjectResult))]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var loginResponse = await _accountService.Login(loginRequest);
            if (loginResponse == null)
            {
                return Unauthorized(new ErrorResponse()
                {
                    StatusCode = StatusCodes.Status401Unauthorized,
                    Error = MessageConstant.LoginMessage.InvalidEmailOrPassword,
                    TimeStamp = DateTime.Now
                });
            }
            if (!loginResponse.Status)
                return Unauthorized(new ErrorResponse()
                {
                    StatusCode = StatusCodes.Status401Unauthorized,
                    Error = MessageConstant.LoginMessage.AccountIsUnavailable,
                    TimeStamp = DateTime.Now
                });
            return Ok(loginResponse);
        }

        [AllowAnonymous]
        [HttpPost(ApiEndPointConstant.Authentication.SignUpEndPoint)]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(UnauthorizedObjectResult))]
        [SwaggerOperation(Summary = "Signup with email and password, after that, save the accountId to a temporal variable and send to updateAccountApi")]
        public async Task<IActionResult> SignUp(SignUpRequest signUpRequest)
        {
            try
            {
                var response = await _accountService.SignUp(signUpRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Already Used Email"))
                    return BadRequest(new ErrorResponse()
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Error = MessageConstant.SignUpMessage.EmailHasAlreadyUsed,
                        TimeStamp = DateTime.Now
                    });
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
