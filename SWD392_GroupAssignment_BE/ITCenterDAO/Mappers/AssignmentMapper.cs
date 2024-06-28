using AutoMapper;
using ITCenterBO.DTOs.Request.Assignment;
using ITCenterBO.DTOs.Response.Assignment;
using ITCenterBO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterDAO.Mappers
{
    public class AssignmentMapper : Profile
    {
        public AssignmentMapper() {
            CreateMap<CreateAssignmentRequest, Assignment>();
            CreateMap<UpdateAssignmentRequest, Assignment>();
            CreateMap<Assignment, UpdateAssignmentResponse>();
            CreateMap<Assignment, GetAssignmentResponse>()
                .ForMember(x => x.CourseName, y => y.MapFrom(src => src.Course.CourseName != null ? src.Course.CourseName : null))
                .ForMember(x => x.ImageUrl, y => y.MapFrom(src => src.Course.ImageUrl != null ? src.Course.ImageUrl : null))
                .ReverseMap();
        }
    }
}
