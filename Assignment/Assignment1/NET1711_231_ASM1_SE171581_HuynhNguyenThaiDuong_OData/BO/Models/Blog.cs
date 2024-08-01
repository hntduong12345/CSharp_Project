using System;
using System.Collections.Generic;

namespace MilkData.Models;

public partial class Blog
{
    public int BlogId { get; set; }

    public int BlogCategoryId { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;

    public string ProductSuggestUrl { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public int AccountId { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual BlogCategory BlogCategory { get; set; } = null!;


    public Blog(int blogId, int blogCategoryId, string title, string content, string imageUrl, string productSuggestUrl, DateTime createdDate, int accountId)
    {
        BlogId = blogId;
        BlogCategoryId = blogCategoryId;
        Title = title;
        Content = content;
        ImageUrl = imageUrl;
        ProductSuggestUrl = productSuggestUrl;
        CreatedDate = createdDate;
        AccountId = accountId;
    }
}
