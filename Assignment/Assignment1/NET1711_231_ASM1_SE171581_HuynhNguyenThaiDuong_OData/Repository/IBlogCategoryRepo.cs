using BO.DTOs;
using BO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IBlogCategoryRepo
    {
        public List<BlogCategory> GetAllCateogries();
        public BlogCategory GetBlogCategory(int id);
        public BlogCategory CreateBlogCatefory(BlogCategoryDTO blogCategory);
        public BlogCategory UpdateBlogCategory(int id, UpdateBlogCategoryDTO updateInfo);
        public bool DeleteBlogCatefory(int id);
    }
}
