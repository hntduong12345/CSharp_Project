using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfService.Models;

namespace WcfService.DataSrc
{
    public class BlogData
    {
        public static List<Blog> Blogs = new List<Blog>()
        {
            new Blog{Id = 1, AccountId = 3, BlogCategoryId = 1, DocUrl = "Doc1", ImageUrl = "Image1", Title = "Blog1", Status = "Active", Type = "Information"},
            new Blog{Id = 2, AccountId = 3, BlogCategoryId = 1, DocUrl = "Doc2", ImageUrl = "Image2", Title = "Blog2", Status = "Active", Type = "Guide"},
            new Blog{Id = 3, AccountId = 3, BlogCategoryId = 2, DocUrl = "Doc3", ImageUrl = "Image3", Title = "Blog3", Status = "Inactive", Type = "Information"},
            new Blog{Id = 4, AccountId = 4, BlogCategoryId = 2, DocUrl = "Doc4", ImageUrl = "Image4", Title = "Blog4", Status = "Active", Type = "Information"},
            new Blog{Id = 5, AccountId = 4, BlogCategoryId = 3, DocUrl = "Doc5", ImageUrl = "Image5", Title = "Blog5", Status = "Active", Type = "Guide"},
            new Blog{Id = 6, AccountId = 4, BlogCategoryId = 3, DocUrl = "Doc6", ImageUrl = "Image6", Title = "Blog6", Status = "Inactive", Type = "Information"},
        };
    }
}