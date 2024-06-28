using ITCenterBO.DTOs.Request.Order;
using ITCenterBO.DTOs.Response.Order;
using ITCenterBO.Models;
using ITCenterBO.Paginate;
using ITCenterDAO;
using ITCenterRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterService
{
    public interface IOrderService
    {
        Task<IList<GetOrderResponse>> GetOrdersBasedUser(int accountID);
        void AddCourseToCarte(CreateOrderRequest request);
        Task<bool> ChangeStatusOrder(UpdateOrderRequest request);
        Task<IList<GetOrderResponse>> OrderHasBeenPaid(int accountID);

        Task<GetOrderResponse> GetOrderById(int orderId);
        Task<Order> CreateOrder(int accountId);
        Task<IPaginate<GetOrderResponse>> GetAllOrders(int page, int size);
        Task<IPaginate<GetOrderResponse>> GetUserOrders(int accountId, int page, int size);
        Task ChangeOrderStatus(int orderId);
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService()
        {
            if (_orderRepository == null)
            {
                _orderRepository = new OrderRepository();
            }
        }

        public async void AddCourseToCarte(CreateOrderRequest request)
        {
            _orderRepository.AddCourseToCarte(request);
        }


        public async Task<IList<GetOrderResponse>> GetOrdersBasedUser(int accountID)
        {
            return await _orderRepository.GetOrdersBasedUser(accountID);
        }

        public async Task<IList<GetOrderResponse>> OrderHasBeenPaid(int accountID)
        {
            return await _orderRepository.OrderHasBeenPaid(accountID);
        }

        #region UsableMethod
        public async Task<bool> ChangeStatusOrder(UpdateOrderRequest request)
        {
            return await _orderRepository.ChangeStatusOrder(request);
        }

        //Method for Payment
        public async Task<GetOrderResponse> GetOrderById(int orderId)
        {
            return await _orderRepository.GetOrderById(orderId);
        }

        public async Task<Order> CreateOrder(int accountId)
        {
            return await _orderRepository.CreateOrder(accountId);
        }

        public async Task<IPaginate<GetOrderResponse>> GetAllOrders(int page, int size)
        {
            return await _orderRepository.GetAllOrders(page, size);
        }

        public async Task<IPaginate<GetOrderResponse>> GetUserOrders(int accountId, int page, int size)
        {
            return await _orderRepository.GetUserOrders(accountId, page, size);
        }

        public async Task ChangeOrderStatus(int orderId)
        {
            await _orderRepository.ChangeOrderStatus(orderId);
        }
        #endregion
    }
}
