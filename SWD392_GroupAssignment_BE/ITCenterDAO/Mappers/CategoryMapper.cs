using AutoMapper;
using ITCenterBO.DTOs.Request.Category;
using ITCenterBO.DTOs.Response.Category;
using ITCenterBO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterDAO.Mappers
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, UpdateCategoryResponse>();
            CreateMap<CreateCategoryRequest, Category>();
        }
    }
}
