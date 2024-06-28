using AutoMapper;
using ITCenterBO.DTOs.Request.Course;
using ITCenterBO.DTOs.Response.Course;
using ITCenterBO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterDAO.Mappers
{
    public class CourseMapper : Profile
    {
        public CourseMapper()
        {
            CreateMap<CreateCourseRequest, Course>();
            CreateMap<Course, UpdateCourseResponse>();
        }
    }
}
