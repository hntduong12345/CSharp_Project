using ITCenterBO.DTOs.Request.Order;
using ITCenterBO.DTOs.Response.Order;
using ITCenterBO.DTOs.Response.Payment;
using ITCenterBO.Models;
using ITCenterBO.Paginate;
using ITCenterController.Constants;
using ITCenterService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITCenterController.Controllers
{
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IPaymentService _paymentService;

        public OrderController(IOrderService orderService, IOrderDetailService orderDetailService
            , IPaymentService paymentService)
        {
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _paymentService = paymentService;
        }

        #region Tien'sCode
        //[HttpGet(ApiEndPointConstant.Order.OrderEndPoint)]
        //[ProducesResponseType(typeof(IList<GetOrderResponse>), StatusCodes.Status200OK)]
        //public async Task<IActionResult> GetOrdersBasedUser(int accountId)
        //{
        //    if (accountId != null)
        //    {
        //        return Ok(await _orderService.GetOrdersBasedUser(accountId));
        //    }
        //    return BadRequest();
        //}

        //[HttpGet(ApiEndPointConstant.Order.OrderHasBeenPaidEndPoint)]
        //[ProducesResponseType(typeof(IList<GetOrderResponse>), StatusCodes.Status200OK)]
        //public async Task<IActionResult> OrderHasBeenPaid(int accountId)
        //{
        //    if (accountId != null)
        //    {
        //        return Ok(await _orderService.OrderHasBeenPaid(accountId));
        //    }
        //    return BadRequest();
        //}

        //[HttpPost(ApiEndPointConstant.Order.OrderAddEndPoint)]
        //public async Task<IActionResult> AddCourseToCart(CreateOrderRequest request)
        //{
        //    if (request.AccountId != null)
        //    {
        //        _orderService.AddCourseToCarte(request);
        //        return Ok();
        //    }
        //    return BadRequest();
        //}

        //[HttpPut(ApiEndPointConstant.Order.OrderStatusEndPoint)]
        //[ProducesResponseType(typeof(UpdateOrderResponse), StatusCodes.Status200OK)]
        //public async Task<IActionResult> ChangeStatusOrder(UpdateOrderRequest request)
        //{
        //    bool response = await _orderService.ChangeStatusOrder(request);
        //    if (response)
        //    {
        //        return Ok();
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}
        #endregion

        //Duong's Code
        [HttpPost(ApiEndPointConstant.Order.AccountOrderEndPoint)]
        [ProducesResponseType(typeof(PaymentLinkResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateOrder(int accountId, [FromBody] CreateNewOrderRequest request)
        {
            try
            {
                //Create New Order
                Order createdOrder = await _orderService.CreateOrder(accountId);

                //Create OrderDetail (Contains CourseId) 
                foreach (int courseId in request.courseIdInOrderDetail)
                {
                    await _orderDetailService.CreateOrderDetail(courseId, createdOrder.OrderId);
                }

                //Create Payment
                PaymentLinkResponse response = await _paymentService.CreatePayment(createdOrder);

                return Ok(response);
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(BadHttpRequestException))
                {
                    return BadRequest(ex.Message);
                }

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpGet(ApiEndPointConstant.Order.OrdersEndPoint)]
        [ProducesResponseType(typeof(IPaginate<GetOrderResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllOrders(int page, int size)
        {
            try
            {
                var response = await _orderService.GetAllOrders(page, size);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet(ApiEndPointConstant.Order.AccountOrderEndPoint)]
        [ProducesResponseType(typeof(IPaginate<GetOrderResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserOrder(int accountId, int page, int size)
        {
            try
            {
                var response = await _orderService.GetUserOrders(accountId, page, size);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet(ApiEndPointConstant.Order.OrderEndPoint)]
        [ProducesResponseType(typeof(GetOrderInfoResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOrderById(int id, int page, int size)
        {
            try
            {
                var orderInfo = _orderService.GetOrderById(id);
                var orderDetails = _orderDetailService.GetOrderDetailInOrder(id, page, size);


                GetOrderInfoResponse responseInfo = new GetOrderInfoResponse
                {
                    order = orderInfo.Result,
                    OrderDetails = orderDetails.Result
                };

                return Ok(responseInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
