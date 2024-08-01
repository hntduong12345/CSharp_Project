using System;
using System.Collections.Generic;

namespace BO.Entities
{
    public partial class BlogCategory
    {
        public BlogCategory()
        {
            Blogs = new HashSet<Blog>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
