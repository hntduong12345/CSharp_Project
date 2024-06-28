using ITCenterBO.DTOs.Request.OrderDetail;
using ITCenterBO.DTOs.Response.OrderDetail;
using ITCenterBO.DTOs.Response.OwnedCourse;
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
    public interface IOrderDetailRepository
    {
        Task<IList<GetOrderDetailResponse>> OrderDetail(int accountId, int orderId);
        Task<IList<GetOrderDetailResponse>> OrderDetailHasPaidedIndividual(int accountId, int orderId);
        void AddCourseToOrderDetail(AddCourseToCarteRequest orderDetail);
        Task<bool> RemoveCoureAtODetail(int courseId, int orderId);
        Task<double> GetPriceOrderDetailInOrder(int accountId, int orderId);
        Task<double> GetPricePaidedOrderDetailInOrder(int accountId, int orderId);

        Task<List<OrderDetail>> GetOrderDetaiListlInOrder(int orderId);
        Task CreateOrderDetail(int courseId, int orderId);
        Task<IPaginate<GetOrderDetailResponse>> GetOrderDetailInOrder(int orderId, int page, int size);
        Task<List<GetBestSellerCourseInOrderDetail>> GetBestSeller();
    }
    public class OrderDetailRepository : IOrderDetailRepository
    {
        #region Tien'sCode
        public async void AddCourseToOrderDetail(AddCourseToCarteRequest orderDetail)
        {
            OrderDetailDAO.Instance.AddCourseToOrderDetail(orderDetail);
        }

        public async Task<IList<GetOrderDetailResponse>> OrderDetail(int accountId, int orderId)
        {
            return await OrderDetailDAO.Instance.OrderDetail(accountId, orderId);
        }

        public async Task<bool> RemoveCoureAtODetail(int courseId, int accountId)
        {
            return await OrderDetailDAO.Instance.RemoveCoureAtODetail(courseId, accountId);
        }

        public async Task<double> GetPriceOrderDetailInOrder(int accountId, int orderId)
        {
            return await OrderDetailDAO.Instance.GetPriceOrderDetailInOrder(accountId, orderId);
        }

        public async Task<double> GetPricePaidedOrderDetailInOrder(int accountId, int orderId)
        {
            return await OrderDetailDAO.Instance.GetPricePaidedOrderDetailInOrder(accountId, orderId);
        }

        public async Task<IList<GetOrderDetailResponse>> OrderDetailHasPaidedIndividual(int accountId, int orderId)
        {
            return await OrderDetailDAO.Instance.OrderDetailHasPaidedIndividual(accountId, orderId);
        }
        #endregion

        //Duong's Code
        public async Task<List<OrderDetail>> GetOrderDetaiListlInOrder(int orderId)
        {
            return await OrderDetailDAO.Instance.GetOrderDetaiListlInOrder(orderId);
        }

        public async Task CreateOrderDetail(int courseId, int orderId)
        {
            await OrderDetailDAO.Instance.CreateOrderDetail(courseId, orderId);
        }

        public async Task<IPaginate<GetOrderDetailResponse>> GetOrderDetailInOrder(int orderId, int page, int size)
        {
            return await OrderDetailDAO.Instance.GetOrderDetailInOrder(orderId, page, size);
        }

        public async Task<List<GetBestSellerCourseInOrderDetail>> GetBestSeller()
        {
            return await OrderDetailDAO.Instance.GetBestSeller();
        }
    }
}
