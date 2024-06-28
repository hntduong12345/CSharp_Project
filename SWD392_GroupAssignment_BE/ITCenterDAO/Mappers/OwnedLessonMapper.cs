using AutoMapper;
using ITCenterBO.DTOs.Request.OwnedLesson;
using ITCenterBO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterDAO.Mappers
{
    public class OwnedLessonMapper : Profile
    {
        public OwnedLessonMapper()
        {
            CreateMap<CreateOwnedLessonRequest, OwnedLesson>();
        }
    }
}
