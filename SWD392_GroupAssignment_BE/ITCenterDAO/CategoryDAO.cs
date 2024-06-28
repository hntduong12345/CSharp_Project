﻿using AutoMapper;
using ITCenterBO.DTOs.Request.Category;
using ITCenterBO.DTOs.Response.Category;
using ITCenterBO.Models;
using ITCenterBO.Paginate;
using ITCenterDAO.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterDAO
{
    public class CategoryDAO
    {
        private readonly ITCenterContext _dbContext = null;
        private readonly IMapper _mapper;

        private static CategoryDAO instance;
        public static CategoryDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CategoryDAO();
                }
                return instance;
            }
        }

        public CategoryDAO()
        {
            if (_dbContext == null)
                _dbContext = new ITCenterContext();
            if (_mapper == null)
                _mapper = new Mapper(new MapperConfiguration(mc => mc.AddProfile(new CategoryMapper())).CreateMapper().ConfigurationProvider);
        }

        #region CategoryFunction

        public async Task<IPaginate<GetCategoryResponse>> GetAllCategories(int page, int size)
        {
            IPaginate<GetCategoryResponse> categoryList = await _dbContext.Categories.Select(x => new GetCategoryResponse
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                Description = x.Description
            }).ToPaginateAsync(page, size, 1);
            return categoryList;
        }

        public async void CreateCategory(CreateCategoryRequest createCategoryRequest)
        {
            Category category = _dbContext.Categories.FirstOrDefault(x => x.CategoryName.ToLower() == createCategoryRequest.CategoryName.ToLower());

            if (category == null)
            {
                _dbContext.Categories.Add(_mapper.Map<Category>(createCategoryRequest));
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<UpdateCategoryResponse> UpdateCategoryInformation(int id, UpdateCategoryRequest updateCategoryRequest)
        {
            Category category = _dbContext.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (category != null)
            {
                category.CategoryName = string.IsNullOrEmpty(updateCategoryRequest.CategoryName) ?
                    category.CategoryName : updateCategoryRequest.CategoryName;
                category.Description = string.IsNullOrEmpty(updateCategoryRequest.Description) ?
                    category.Description : updateCategoryRequest.Description;

                _dbContext.Categories.Update(category);
                await _dbContext.SaveChangesAsync();

                UpdateCategoryResponse response = _mapper.Map<UpdateCategoryResponse>(category);
                return response;
            }
            return null;
        }

        public async Task<GetCategoryResponse> GetRandomCategoy()
        {
            Random rd = new Random();
            int categoriesAmount = await _dbContext.Categories.CountAsync();
            int toSkip = rd.Next(0, categoriesAmount - 1);

            GetCategoryResponse randomCategory = await _dbContext.Categories
                                                 .Select(ct => new GetCategoryResponse
                                                 {
                                                     CategoryId = ct.CategoryId,
                                                     CategoryName = ct.CategoryName,
                                                     Description = ct.Description,
                                                 })
                                                 .Skip(toSkip).Take(1).FirstAsync();
            return randomCategory;
        }
        #endregion

    }
}
