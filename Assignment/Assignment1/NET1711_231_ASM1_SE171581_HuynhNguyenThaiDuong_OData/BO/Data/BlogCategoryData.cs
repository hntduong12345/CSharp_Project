using MilkData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Data
{
    public static class BlogCategoryData
    {
        public static List<BlogCategory> blogCategories = new List<BlogCategory>()
       {
           new BlogCategory(1,"Media"),
           new BlogCategory(2,"Guide"),
           new BlogCategory(3,"Product"),
           new BlogCategory(4,"News"),
           new BlogCategory(5,"Review"),
           new BlogCategory(6,"Advertising")
       };
    }
}
