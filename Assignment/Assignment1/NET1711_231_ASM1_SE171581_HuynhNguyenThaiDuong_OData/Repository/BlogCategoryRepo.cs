using BO.Data;
using BO.DTOs;
using BO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BlogCategoryRepo : IBlogCategoryRepo
    {
        private readonly ASM1Context _context;
        public BlogCategoryRepo()
        {
            _context = new ASM1Context();
        }

        public List<BlogCategory> GetAllCateogries()
        {
            return _context.BlogCategories.ToList();
        }

        public BlogCategory GetBlogCategory(int id)
        {
            return _context.BlogCategories.FirstOrDefault(x => x.Id == id);
        }

        public BlogCategory CreateBlogCatefory(BlogCategoryDTO blogCategory)
        {
            BlogCategory currentCategory = _context.BlogCategories.FirstOrDefault(x => x.Id == blogCategory.BlogCategoryId);
            if (currentCategory != null) return null;

            BlogCategory newCategory = new BlogCategory()
            {
                Id = blogCategory.BlogCategoryId,
                Name = blogCategory.BlogCategoryName
            };

            _context.BlogCategories.Add(newCategory);
            return newCategory;
        }

        public BlogCategory UpdateBlogCategory(int id, UpdateBlogCategoryDTO updateInfo)
        {
            BlogCategory currentCategory = _context.BlogCategories.FirstOrDefault(x => x.Id == id);
            if (currentCategory == null) return null;

            currentCategory.Name = String.IsNullOrEmpty(updateInfo.BlogCategoryName) ? currentCategory.Name : updateInfo.BlogCategoryName;
            return currentCategory;
        }

        public bool DeleteBlogCatefory(int id)
        {
            BlogCategory currentCategory = _context.BlogCategories.FirstOrDefault(x => x.Id == id);
            if (currentCategory == null) return false;

            _context.BlogCategories.Remove(currentCategory);
            return true;
        }
    }
}
