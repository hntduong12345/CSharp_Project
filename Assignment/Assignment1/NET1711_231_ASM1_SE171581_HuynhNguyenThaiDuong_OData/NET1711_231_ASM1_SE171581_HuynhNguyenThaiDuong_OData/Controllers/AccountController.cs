using BO.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Repository;
using System.Xml.Linq;

namespace NET1711_231_ASM1_SE171581_HuynhNguyenThaiDuong_OData.Controllers
{
    public class AccountController : ODataController
    {
        private readonly IAccountRepo _accountRepo;
        public AccountController(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            var result = _accountRepo.GetAllAccounts();
            return Ok(result);
        }

        [EnableQuery]
        public IActionResult Get([FromRoute] int key)
        {
            var result = _accountRepo.GetAccount(key);
            if (result == null)
                return NotFound("Cannot find account");
            return Ok(result);
        }

        public IActionResult Post([FromBody] AccountDTO account)
        {
            var result = _accountRepo.CreateAccount(account);
            if (result != null)
                return Created(result);
            return Conflict("Id has already used");
        }

        public IActionResult Put([FromRoute] int key, UpdateAccountDTO updateInfo)
        {
            var result = _accountRepo.UpdateAccount(key, updateInfo);
            if (result != null)
                return Updated(result);
            return NotFound("Cannot find account");
        }

        public IActionResult Delete([FromRoute] int key)
        {
            var result = _accountRepo.DeleteAccount(key);
            if (result)
                return Ok("Action successfully");
            return NotFound("Cannot find account");
        }
    }
}
