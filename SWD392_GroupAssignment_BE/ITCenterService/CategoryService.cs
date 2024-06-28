using ITCenterBO.DTOs.Request.Category;
using ITCenterBO.DTOs.Response.Category;
using ITCenterBO.Models;
using ITCenterBO.Paginate;
using ITCenterRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterService
{
    public interface ICategoryService
    {
        public Task<IPaginate<GetCategoryResponse>> GetAllCategories(int page, int size);
        public void CreateCategory(CreateCategoryRequest createCategoryRequest);
        public Task<UpdateCategoryResponse> UpdateCategoryInformation(int id, UpdateCategoryRequest updateCategoryRequest);
        public Task<GetCategoryResponse> GetRandomCategoy();
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository = null;

        public CategoryService()
        {
            if (_categoryRepository == null)
                _categoryRepository = new CategoryRepository();
        }

        public async void CreateCategory(CreateCategoryRequest createCategoryRequest) => _categoryRepository.CreateCategory(createCategoryRequest);

        public async Task<IPaginate<GetCategoryResponse>> GetAllCategories(int page, int size) => await _categoryRepository.GetAllCategories(page, size);

        public async Task<UpdateCategoryResponse> UpdateCategoryInformation(int id, UpdateCategoryRequest updateCategoryRequest) => await _categoryRepository.UpdateCategoryInformation(id, updateCategoryRequest);

        public async Task<GetCategoryResponse> GetRandomCategoy() => await _categoryRepository.GetRandomCategoy();
    }
}
