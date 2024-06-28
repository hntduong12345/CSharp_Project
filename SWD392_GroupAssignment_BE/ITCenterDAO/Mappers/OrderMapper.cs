using AutoMapper;
using ITCenterBO.DTOs.Request.Order;
using ITCenterBO.DTOs.Response.Order;
using ITCenterBO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterDAO.Mappers
{
    public class OrderMapper : Profile
    {
        public OrderMapper() {
            CreateMap<CreateOrderRequest, Order>();
            CreateMap<Order, UpdateOrderResponse>();
            CreateMap<Order, GetOrderResponse>().ReverseMap();
                

        }
    }
}
