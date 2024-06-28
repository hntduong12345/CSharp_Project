using ITCenterBO.Models;
using ITCenterController.Constants;
using ITCenterBO.DTOs.Response.Account;
using ITCenterService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ITCenterBO.Paginate;
using ITCenterBO.DTOs.Request.Account;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;

namespace ITCenterController.Controllers
{
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet(ApiEndPointConstant.Account.AccountsEndPoint)]
        [ProducesResponseType(typeof(IPaginate<GetAccountResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAccount(int page, int size)
        {
            return Ok(await _accountService.GetAllAccounts(page, size));
        }

        [HttpPost(ApiEndPointConstant.Account.AccountsEndPoint)]
        public async Task<IActionResult> CreateAccount(CreateAccountRequest createAccountRequest)
        {
            _accountService.CreateAccount(createAccountRequest);
            return Ok();
        }

        [HttpPatch(ApiEndPointConstant.Account.AccountEndPoint)]
        [ProducesResponseType(typeof(UpdateAccountResponse), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "after sign up, use this api to add userInformation")]
        public async Task<IActionResult> UpdateAccountInformation(int id, UpdateAccountRequest updateAccountRequest)
        {
            UpdateAccountResponse response = await _accountService.UpdateAccountInformation(id, updateAccountRequest);

            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPatch(ApiEndPointConstant.Account.AccountStatusEndPoint)]
        public async Task<IActionResult> ChangeAccountStatus(int id)
        {
            bool result = await _accountService.ChangeAccountStatus(id);
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
