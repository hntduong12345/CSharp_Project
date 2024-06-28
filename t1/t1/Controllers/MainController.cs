using Microsoft.AspNetCore.Mvc;
using ProGCoder_MomoAPI.Models.Order;
using System.Web.Http.Cors;
using t1.MomoService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace t1.Controllers
{
    [Route("api/main")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IMomoService _momoService;
        public MainController(IMomoService momoService)
        {
            _momoService = momoService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePaymentUrl(OrderInfoModel orderInfo)
        {
            var response = await _momoService.CreatePaymentAsync(orderInfo);
            //return Redirect(response.PayUrl);
            return Ok(response.PayUrl);

        }

        [HttpGet]
        public IActionResult PaymentCallBack()
        {
            var response = _momoService.PaymentExecuteAsync(HttpContext.Request.Query);
            return Ok(HttpContext.Request.Query);
        }
    }
}
