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
    public class BlogRepo : IBlogRepo
    {
        private readonly ASM1Context _context;
        public BlogRepo()
        {
            _context = new ASM1Context();
        }

        public List<Blog> GetAllBlogs()
        {
            return _context.Blogs.ToList();
        }

        public Blog GetBlog(int id)
        {
            return _context.Blogs.FirstOrDefault(x => x.Id == id);
        }

        public Blog CreateBlog(BlogDTO blog)
        {
            Blog currentBlog = _context.Blogs.FirstOrDefault(x => x.Id == blog.BlogId);
            if (currentBlog != null) return null;

            Blog newBlog = new Blog()
            {
                AccountId = blog.AccountId,
                BlogCategoryId = blog.BlogCategoryId,
                CreateAt = blog.CreatedDate,
                DocUrl = blog.DocUrl,
                ImageUrl = blog.ImageUrl,
                ProductSuggestUrl = blog.ProductSuggestUrl,
                Title = blog.Title
                
            };

            _context.Blogs.Add(newBlog);
            return newBlog;
        }

        public Blog UpdateBlog(int id, UpdateBlogDTO blog)
        {
            Blog currentBlog = _context.Blogs.FirstOrDefault(x => x.Id == id);
            if (currentBlog == null) return null;

            currentBlog.BlogCategoryId = blog.BlogCategoryId;
            currentBlog.Title = blog.Title;
            currentBlog.DocUrl = blog.DocUrl;
            currentBlog.ImageUrl = blog.ImageUrl;
            currentBlog.ProductSuggestUrl = blog.ProductSuggestUrl;
            currentBlog.CreateAt = blog.CreatedDate;
            currentBlog.AccountId = blog.AccountId;

            return currentBlog;
        }

        public bool DeleteBlog(int id)
        {
            Blog currentBlog = _context.Blogs.FirstOrDefault(x => x.Id == id);
            if (currentBlog == null) return false;

            _context.Blogs.Remove(currentBlog);
            return true;
        }
    }
}
