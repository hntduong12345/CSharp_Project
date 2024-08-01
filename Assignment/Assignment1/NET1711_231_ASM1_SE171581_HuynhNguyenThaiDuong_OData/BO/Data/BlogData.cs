using MilkData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Data
{
    public static class BlogData
    {
        public static List<Blog> Blogs = new List<Blog>()
        {
            new Blog(1,1,"Blog 1", "Content 1", "Image 1", "Product URL 1", DateTime.Parse("10-30-2035"), 1),
            new Blog(2,1,"Blog 2", "Content 2", "Image 2", "Product URL 2", DateTime.Parse("2-3-2035"), 1),
            new Blog(3,2,"Blog 3", "Content 3", "Image 3", "Product URL 3", DateTime.Parse("4-10-2035"), 2),
            new Blog(4,2,"Blog 4", "Content 4", "Image 4", "Product URL 4", DateTime.Parse("10-20-2035"), 2),
            new Blog(5,3,"Blog 5", "Content 5", "Image 5", "Product URL 5", DateTime.Parse("3-25-2035"), 3),
            new Blog(6,3,"Blog 6", "Content 6", "Image 6", "Product URL 6", DateTime.Parse("7-3-2035"), 3),
            new Blog(7,4,"Blog 7", "Content 7", "Image 7", "Product URL 7", DateTime.Parse("8-17-2035"), 4),
            new Blog(8,4,"Blog 8", "Content 8", "Image 8", "Product URL 8", DateTime.Parse("9-11-2035"), 4),
            new Blog(9,5,"Blog 9", "Content 9", "Image 9", "Product URL 9", DateTime.Parse("12-4-2035"), 5),
            new Blog(10,5,"Blog 10", "Content 10", "Image 10", "Product URL 10", DateTime.Parse("2-4-2035"), 5),
            new Blog(11,6,"Blog 11", "Content 11", "Image 11", "Product URL 11", DateTime.Parse("3-21-2035"), 6),
            new Blog(12,6,"Blog 12", "Content 12", "Image 12", "Product URL 12", DateTime.Parse("11-12-2035"), 6),
        };
    }
}
