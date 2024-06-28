using AutoMapper;
using ITCenterBO.DTOs.Request.OrderDetail;
using ITCenterBO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterDAO.Mappers
{
    public class OrderDetailMapper : Profile
    {
        public OrderDetailMapper() {

            CreateMap<AddCourseToCarteRequest, OrderDetail>();

        }
    }
}
