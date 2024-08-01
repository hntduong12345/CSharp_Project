﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.DTOs
{
    public class BlogDTO
    {
        public int BlogId { get; set; }

        public int BlogCategoryId { get; set; }

        public string Title { get; set; } = null!;

        public string DocUrl { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string ProductSuggestUrl { get; set; } = null!;

        public DateTime CreatedDate { get; set; }

        public int AccountId { get; set; }
    }

    public class UpdateBlogDTO
    {
        public int BlogCategoryId { get; set; }

        public string Title { get; set; } = null!;

        public string DocUrl { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string ProductSuggestUrl { get; set; } = null!;

        public DateTime CreatedDate { get; set; }

        public int AccountId { get; set; }
    }
}
