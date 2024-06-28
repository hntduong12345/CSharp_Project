using AutoMapper;
using ITCenterBO.DTOs.Request.LearnerAssignment;
using ITCenterBO.DTOs.Response.Assignment;
using ITCenterBO.DTOs.Response.LearnerAssignment;
using ITCenterBO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterDAO.Mappers
{
    public class LearnerAssignmentMapper : Profile
    {
        public LearnerAssignmentMapper() {
            CreateMap<CreateLearnerAssignmentRequest, LearnerAssignment>();
            CreateMap<UpdateLearnerAssignmentRequest, LearnerAssignment>();
            CreateMap<LearnerAssignment, UpdateLearnerAssignmentResponse>();
            CreateMap<LearnerAssignment, GetLearnerAssignmentResponse>()
                .ForMember(x => x.Email, y => y.MapFrom(src => src.Account.Email != null ? src.Account.Email : null))
                .ForMember(x => x.FirstName, y => y.MapFrom(src => src.Account.FirstName != null ? src.Account.FirstName : null))
                .ForMember(x => x.LastName, y => y.MapFrom(src => src.Account.LastName != null ? src.Account.LastName : null))
                .ReverseMap();
        }
    }
}
