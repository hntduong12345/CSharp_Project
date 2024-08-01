using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.DTOs
{
    public class BlogCategoryDTO
    {
        public int BlogCategoryId {  get; set; }
        public string BlogCategoryName { get; set; }
    }
    
    public class UpdateBlogCategoryDTO
    {
        public string BlogCategoryName { get; set; }
    }
}
