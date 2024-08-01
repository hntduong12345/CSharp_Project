using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfService.Models;

namespace WcfService.DataSrc
{
    public class BlogCategoryData
    {
        public static List<BlogCategory> BlogCategories = new List<BlogCategory>()
        {
            new BlogCategory{Id = 1, Name = "Sua bot"},
            new BlogCategory{Id = 2, Name = "Sua hop"},
            new BlogCategory{Id = 3, Name = "Sua chua"},
        };
    }
}