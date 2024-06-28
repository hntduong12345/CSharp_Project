using ITCenterBO.DTOs.Request.Category;
using ITCenterBO.DTOs.Response.Account;
using ITCenterBO.DTOs.Response.Category;
using ITCenterBO.Models;
using ITCenterBO.Paginate;
using ITCenterDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterRepository
{
    public interface ICategoryRepository
    {
        public Task<IPaginate<GetCategoryResponse>> GetAllCategories(int page, int size);
        public void CreateCategory(CreateCategoryRequest createCategoryRequest);
        public Task<UpdateCategoryResponse> UpdateCategoryInformation(int id, UpdateCategoryRequest updateCategoryRequest);
        public Task<GetCategoryResponse> GetRandomCategoy();
    }

    public class CategoryRepository : ICategoryRepository
    {
        public async void CreateCategory(CreateCategoryRequest createCategoryRequest) => CategoryDAO.Instance.CreateCategory(createCategoryRequest);

        public async Task<IPaginate<GetCategoryResponse>> GetAllCategories(int page, int size) => await CategoryDAO.Instance.GetAllCategories(page, size);

        public async Task<UpdateCategoryResponse> UpdateCategoryInformation(int id, UpdateCategoryRequest updateCategoryRequest) => await CategoryDAO.Instance.UpdateCategoryInformation(id, updateCategoryRequest);

        public async Task<GetCategoryResponse> GetRandomCategoy() => await CategoryDAO.Instance.GetRandomCategoy();
    }
}
