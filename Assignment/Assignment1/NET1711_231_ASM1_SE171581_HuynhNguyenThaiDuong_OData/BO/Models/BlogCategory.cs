﻿using System;
using System.Collections.Generic;

namespace MilkData.Models;

public partial class BlogCategory
{
    public int BlogCategoryId { get; set; }

    public string BlogCategoryName { get; set; } = null!;

    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();

    public BlogCategory(int blogCategoryId, string blogCategoryName)
    {
        BlogCategoryId = blogCategoryId;
        BlogCategoryName = blogCategoryName;
    }
}
