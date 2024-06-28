using AutoMapper;
using ITCenterBO.DTOs.Request.Order;
using ITCenterBO.DTOs.Response.Order;
using ITCenterBO.Models;
using ITCenterBO.Paginate;
using ITCenterDAO.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterDAO
{
    public class OrderDAO
    {
        private readonly ITCenterContext _context = null;
        private readonly IMapper _mapper;

        private static OrderDAO instance;
        public static OrderDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderDAO();
                }
                return instance;
            }
        }

        public OrderDAO()
        {
            if (_context == null)
            {
                _context = new ITCenterContext();
            }
            if (_mapper == null)
            {
                _mapper = new Mapper(new MapperConfiguration(mc => mc.AddProfile(new OrderMapper())).CreateMapper().ConfigurationProvider);
            }
        }

        public async Task<IList<GetOrderResponse>> GetOrdersBasedUser(int accountID)
        {
            IList<GetOrderResponse> response = await (from order in _context.Orders.AsNoTracking()
                                                      where accountID == order.AccountId
                                                      select new GetOrderResponse
                                                      {
                                                          OrderId = order.OrderId,
                                                          AccountId = order.AccountId,
                                                          CreatedDate = order.CreatedDate.Date,
                                                          Status = order.Status
                                                      }).Where(order => !order.Status).ToListAsync();
            return response;
        }

        public async Task<IList<GetOrderResponse>> OrderHasBeenPaid(int accountID)
        {
            IList<GetOrderResponse> response = await (from order in _context.Orders.AsNoTracking()
                                                      where accountID == order.AccountId
                                                      select new GetOrderResponse
                                                      {
                                                          OrderId = order.OrderId,
                                                          AccountId = order.AccountId,
                                                          CreatedDate = order.CreatedDate.Date,
                                                          Status = order.Status
                                                      }).Where(order => order.Status == true).ToListAsync();
            return response;
        }

        public async void AddCourseToCart(CreateOrderRequest request)
        {
            var checkStsOrder = await _context.Orders.AsNoTracking()
                .FirstOrDefaultAsync(x => x.AccountId == request.AccountId && x.Status == request.Status);
            try
            {
                if (checkStsOrder == null)
                {
                    _context.Orders.Add(_mapper.Map<Order>(request));
                    await _context.SaveChangesAsync();
                }
            }
            catch
            {
                throw new Exception("Bad Request");
            }
        }

        public async Task<bool> ChangeStatusOrder(UpdateOrderRequest request)
        {
            Order order =  _context.Orders.FirstOrDefault(o => o.OrderId == request.OrderId && o.AccountId == request.AccountId);
            if (order != null)
            {
                order.Status = request.Status;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        #region UsableCode
        public async Task<IPaginate<GetOrderResponse>> GetAllOrders(int page, int size)
        {
            IPaginate<GetOrderResponse> response = await _context.Orders.Select(or => new GetOrderResponse
            {
                OrderId = or.OrderId,
                AccountId = or.AccountId,
                CreatedDate = or.CreatedDate,
                Status = or.Status
            }).ToPaginateAsync(page, size, 1);

            return response;
        }

        public async Task<IPaginate<GetOrderResponse>> GetUserOrders(int accountId, int page, int size)
        {
            IPaginate<GetOrderResponse> response = await _context.Orders
                .Where(or => or.AccountId == accountId)
                .Select(or => new GetOrderResponse
                {
                    OrderId = or.OrderId,
                    AccountId = or.AccountId,
                    CreatedDate = or.CreatedDate,
                    Status = or.Status
                }).ToPaginateAsync(page, size, 1);

            return response;
        }

        public async Task ChangeOrderStatus(int orderId)
        {
            Order order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId);
            if (order == null) throw new BadHttpRequestException("Order is not existed");

            order.Status = !order.Status;
            await _context.SaveChangesAsync();
        }

        //Duong's Code
        public async Task<GetOrderResponse> GetOrderById(int orderId)
        {
            return await _context.Orders.Select(or => new GetOrderResponse
            {
                OrderId = or.OrderId,
                AccountId = or.AccountId,
                CreatedDate = or.CreatedDate,
                Status = or.Status
            }).FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        public async Task<Order> CreateOrder(int accountId)
        {
            Account acc = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountId == accountId);
            if (acc == null) throw new BadHttpRequestException("Cannot find account");

            DateTime createDate = DateTime.Now;

            Order newOrder = new Order
            {
                OrderId = 0,
                AccountId = accountId,
                CreatedDate = createDate,
                Status = false //Not Paid
            };
            _context.Orders.Add(newOrder);

            //Save data for id auto generate
            await _context.SaveChangesAsync();

            return await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == newOrder.OrderId);
        }
        #endregion
    }
}
