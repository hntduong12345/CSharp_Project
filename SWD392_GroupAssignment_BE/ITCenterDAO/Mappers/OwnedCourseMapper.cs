using AutoMapper;
using ITCenterBO.DTOs.Request.OwnedCourse;
using ITCenterBO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterDAO.Mappers
{
    public class OwnedCourseMapper : Profile
    {
        public OwnedCourseMapper()
        {
            CreateMap<CreateOwnedCourseRequest, OwnedCourse>();
        }
    }
}
