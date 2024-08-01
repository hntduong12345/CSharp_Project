using System;
using System.Collections.Generic;

namespace BO.Entities
{
    public partial class Blog
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int BlogCategoryId { get; set; }
        public string? Title { get; set; }
        public string? DocUrl { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreateAt { get; set; }
        public string? ProductSuggestUrl { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual BlogCategory BlogCategory { get; set; } = null!;
    }
}
