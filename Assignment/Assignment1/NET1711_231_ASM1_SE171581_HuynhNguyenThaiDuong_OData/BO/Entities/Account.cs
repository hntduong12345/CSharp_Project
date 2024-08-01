using System;
using System.Collections.Generic;

namespace BO.Entities
{
    public partial class Account
    {
        public Account()
        {
            Blogs = new HashSet<Blog>();
        }

        public int Id { get; set; }
        public string? Role { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public int? Point { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
