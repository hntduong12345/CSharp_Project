namespace gRPC.Client.Models
{
    public class RequestBlogData
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int BlogCategoryId { get; set; }
        public string? Title { get; set; }
        public string? DocUrl { get; set; }
        public string? ImageUrl { get; set; }
        public string? CreateAt { get; set; }
        public string? UpdateAt { get; set; }
        public string? httpMethod { get; set; }
    }
}
