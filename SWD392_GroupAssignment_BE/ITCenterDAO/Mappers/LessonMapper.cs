using AutoMapper;
using ITCenterBO.DTOs.Request.Lesson;
using ITCenterBO.DTOs.Response.Lesson;
using ITCenterBO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterDAO.Mappers
{
    public class LessonMapper : Profile
    {
        public LessonMapper()
        {
            CreateMap<CreateLessonRequest, Lesson>();
            CreateMap<Lesson, UpdateLessonResponse>();
        }
    }
}
