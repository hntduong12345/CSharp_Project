using BO.DTOs;
using BO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IBlogRepo
    {
        public List<Blog> GetAllBlogs();
        public Blog GetBlog(int id);
        public Blog CreateBlog(BlogDTO blog);
        public Blog UpdateBlog(int id, UpdateBlogDTO blog);
        public bool DeleteBlog(int id);
    }
}
