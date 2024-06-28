using ITCenterBO.DTOs.Request.Order;
using ITCenterBO.DTOs.Response.Order;
using ITCenterBO.Models;
using ITCenterBO.Paginate;
using ITCenterDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterRepository
{
    public interface IOrderRepository
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

    public class OrderRepository : IOrderRepository
    {
        public async void AddCourseToCarte(CreateOrderRequest request)
        {
            OrderDAO.Instance.AddCourseToCart(request);
        }

        public async Task<IList<GetOrderResponse>> GetOrdersBasedUser(int accountID)
        {
            return await OrderDAO.Instance.GetOrdersBasedUser(accountID);
        }

        public async Task<IList<GetOrderResponse>> OrderHasBeenPaid(int orderId)
        {
            return await OrderDAO.Instance.OrderHasBeenPaid(orderId);
        }

        #region UsableMethod
        public async Task<bool> ChangeStatusOrder(UpdateOrderRequest request)
        {
            return await OrderDAO.Instance.ChangeStatusOrder(request);
        }

        //Method for Payment
        public async Task<GetOrderResponse> GetOrderById(int orderId)
        {
            return await OrderDAO.Instance.GetOrderById(orderId);
        }

        public async Task<Order> CreateOrder(int accountId)
        {
            return await OrderDAO.Instance.CreateOrder(accountId);
        }

        public async Task<IPaginate<GetOrderResponse>> GetAllOrders(int page, int size)
        {
            return await OrderDAO.Instance.GetAllOrders(page, size);
        }

        public async Task<IPaginate<GetOrderResponse>> GetUserOrders(int accountId, int page, int size)
        {
            return await OrderDAO.Instance.GetUserOrders(accountId, page, size);
        }

        public async Task ChangeOrderStatus(int orderId)
        {
            await OrderDAO.Instance.ChangeOrderStatus(orderId);
        }
        #endregion
    }
}
