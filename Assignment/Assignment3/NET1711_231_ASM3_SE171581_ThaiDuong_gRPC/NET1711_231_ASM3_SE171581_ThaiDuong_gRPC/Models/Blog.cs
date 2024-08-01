using System;
using System.Collections.Generic;

namespace NET1711_231_ASM3_SE171581_ThaiDuong_gRPC.Models
{
    public partial class Blog
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int BlogCategoryId { get; set; }
        public string? Title { get; set; }
        public string? DocUrl { get; set; }
        public string? ImageUrl { get; set; }
        public string? CreateAt { get; set; }
        public string? UpdateAt { get; set; }
    }
}
