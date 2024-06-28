using ITCenterBO.DTOs.Request.OwnedCourse;
using ITCenterBO.DTOs.Request.OwnedLesson;
using ITCenterController.Constants;
using ITCenterService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Payment.Domain.VNPay.Response;
using System.Net;

namespace ITCenterController.Controllers
{
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IOwnedCourseService _ownedCourseService;
        private readonly IOwnedLessonService _ownedLessonService;

        public PaymentController(IPaymentService paymentService, IOrderService orderService, IOrderDetailService orderDetailService, IOwnedLessonService ownedLessonService, IOwnedCourseService ownedCourseService)
        {
            _paymentService = paymentService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _ownedCourseService = ownedCourseService;
            _ownedLessonService = ownedLessonService;
        }

        [HttpGet(ApiEndPointConstant.Payment.PyamentReturnEndPoint)]
        public async Task<IActionResult> VnpayReturn([FromQuery] VNPayResponse response)
        {
            try
            {
                var result = await _paymentService.CheckPaymentResponse(response);

                var order = await _orderService.GetOrderById(result.OrderId);
                int accountId = order.AccountId;

                //Check is payment (order) paid successfully
                if (result.PaymentStatus.Equals("Success"))
                {
                    //Change Order status => True
                    await _orderService.ChangeOrderStatus(result.OrderId);

                    //Add Course and lesson in orderDetail to OwnCourse, OwnLesson
                    foreach (var orderDetail in _orderDetailService.GetOrderDetaiListlInOrder(result.OrderId).Result)
                    {
                        await _ownedCourseService.CreateOwnedCourse(new CreateOwnedCourseRequest()
                        {
                            AccountId = accountId,
                            CourseId = orderDetail.CourseId
                        });

                        await _ownedLessonService.CreateOwnedLesson(orderDetail.CourseId, accountId);
                    }

                }
                string returnUrl = $"http://localhost:3000/learner?paymentStatus={result.PaymentStatus}&message={result.PaymentMessage}&amount={result.Amount}";
                return Redirect(returnUrl);
            }
            catch (Exception ex)
            {
                if(ex.GetType() == typeof(BadHttpRequestException))
                {
                    return BadRequest(ex.Message);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
