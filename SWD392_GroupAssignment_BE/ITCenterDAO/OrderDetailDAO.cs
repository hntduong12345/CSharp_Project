using AutoMapper;
using ITCenterBO.DTOs.Request.OrderDetail;
using ITCenterBO.DTOs.Response.Order;
using ITCenterBO.DTOs.Response.OrderDetail;
using ITCenterBO.DTOs.Response.OwnedCourse;
using ITCenterBO.DTOs.Response.Payment;
using ITCenterBO.Models;
using ITCenterBO.Paginate;
using ITCenterDAO.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterDAO
{
    public class OrderDetailDAO
    {
        private readonly ITCenterContext _context;
        private readonly IMapper _mapper;

        private static OrderDetailDAO instance;
        public static OrderDetailDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderDetailDAO();
                }
                return instance;
            }
        }

        public OrderDetailDAO()
        {
            if (_context == null)
            {
                _context = new ITCenterContext();
            }
            if (_mapper == null)
            {
                _mapper = new Mapper(new MapperConfiguration(mc => mc.AddProfile(new OrderDetailMapper())).CreateMapper().ConfigurationProvider);
            }
        }

        #region Tien'sCode
        public async Task<IList<GetOrderDetailResponse>> OrderDetail(int accountId, int orderId)
        {
            try
            {
                IList<GetOrderDetailResponse> orderDetail = await (from user in _context.Accounts.AsNoTracking()
                                                                   join order in _context.Orders.AsNoTracking()
                                                                   on user.AccountId equals order.AccountId
                                                                   join ODetail in _context.OrderDetails.AsNoTracking()
                                                                   on order.OrderId equals ODetail.OrderId
                                                                   join course in _context.Courses.AsNoTracking()
                                                                   on ODetail.CourseId equals course.CourseId
                                                                   where user.AccountId == accountId
                                                                   && course.IsAvailable && !order.Status
                                                                   && order.OrderId == orderId
                                                                   select new GetOrderDetailResponse
                                                                   {
                                                                       CourseId = course.CourseId,
                                                                       CourseName = course.CourseName,
                                                                       OrderId = order.OrderId,
                                                                       OrderDetailId = ODetail.OrderDetailId,
                                                                       Price = course.Price
                                                                   }).ToListAsync();
                return orderDetail;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IList<GetOrderDetailResponse>> OrderDetailHasPaidedIndividual(int accountId, int orderId)
        {
            try
            {
                IList<GetOrderDetailResponse> orderDetail = await (from user in _context.Accounts.AsNoTracking()
                                                                   join order in _context.Orders.AsNoTracking()
                                                                   on user.AccountId equals order.AccountId
                                                                   join ODetail in _context.OrderDetails.AsNoTracking()
                                                                   on order.OrderId equals ODetail.OrderId
                                                                   join course in _context.Courses.AsNoTracking()
                                                                   on ODetail.CourseId equals course.CourseId
                                                                   where user.AccountId == accountId
                                                                   && order.OrderId == orderId
                                                                   && course.IsAvailable && order.Status
                                                                   select new GetOrderDetailResponse
                                                                   {
                                                                       CourseId = course.CourseId,
                                                                       CourseName = course.CourseName,
                                                                       OrderId = order.OrderId,
                                                                       OrderDetailId = ODetail.OrderDetailId,
                                                                       Price = course.Price
                                                                   }).ToListAsync();
                return orderDetail;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> RemoveCoureAtODetail(int courseId, int accountId)
        {
            OrderDetail getOneOD = await (from od in _context.OrderDetails.AsNoTracking()
                                          join ord in _context.Orders.AsNoTracking()
                                          on od.OrderId equals ord.OrderId
                                          where ord.AccountId == accountId
                                          && od.CourseId == courseId && !ord.Status
                                          select new OrderDetail()).FirstOrDefaultAsync();
            if (getOneOD != null)
            {
                _context.OrderDetails.Remove(getOneOD);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async void AddCourseToOrderDetail(AddCourseToCarteRequest request)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(
                                    o => o.OrderId == request.OrderId && !o.Status);
            var checkCourse = await _context.Courses.AsNoTracking()
                                .FirstOrDefaultAsync(x => x.IsAvailable && x.CourseId == request.CourseId);
            try
            {
                if (order != null && checkCourse != null)
                {
                    _context.OrderDetails.Add(_mapper.Map<OrderDetail>(request));
                    await _context.SaveChangesAsync();
                }
            }
            catch
            {
                throw new Exception("Bad request");
            }
        }

        public async Task<double> GetPriceOrderDetailInOrder(int accountId, int orderId)
        {
            IList<GetOrderDetailResponse> list = await OrderDetail(accountId, orderId);

            double price = list.Sum(p => p.Price);
            return price;
        }

        public async Task<double> GetPricePaidedOrderDetailInOrder(int accountId, int orderId)
        {
            IList<GetOrderDetailResponse> list = await OrderDetailHasPaidedIndividual(accountId, orderId);

            double price = list.Sum(p => p.Price);
            return price;
        }
        #endregion

        //Duong's Code
        public async Task<List<OrderDetail>> GetOrderDetaiListlInOrder(int orderId)
        {
                return await _context.OrderDetails.Where(odd => odd.OrderId == orderId).ToListAsync();
        }

        public async Task<IPaginate<GetOrderDetailResponse>> GetOrderDetailInOrder(int orderId, int page, int size)
        {
            return await _context.OrderDetails.Include(ord => ord.Course)
                                              .Select(orr => new GetOrderDetailResponse
                                              {
                                                  OrderDetailId = orr.OrderDetailId,
                                                  OrderId = orr.OrderId,
                                                  CourseId = orr.CourseId,
                                                  Price = orr.Course.Price,
                                                  CourseName = orr.Course.CourseName
                                              })
                                              .Where(orr => orr.OrderId == orderId)
                                              .ToPaginateAsync(page, size, 1);
        }

        public async Task CreateOrderDetail(int courseId, int orderId)
        {
            //Check course is existed or available
            Course course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseId == courseId);
            if (course == null) throw new BadHttpRequestException("Course does not exist or is unavailable");

            _context.OrderDetails.Add(new OrderDetail
            {
                OrderDetailId = 0,
                CourseId = courseId,
                OrderId = orderId,
            });
            await _context.SaveChangesAsync();
        }

        public async Task<List<GetBestSellerCourseInOrderDetail>> GetBestSeller()
        {
            return await _context.OrderDetails.GroupBy(ord => ord.CourseId)
                                 .Select(ord => new GetBestSellerCourseInOrderDetail
                                 {
                                     Id = ord.Key,
                                     Count = ord.Count(),
                                 })
                                 .OrderByDescending(ord => ord.Count)
                                 .Take(3).ToListAsync();
        }

    }
}
