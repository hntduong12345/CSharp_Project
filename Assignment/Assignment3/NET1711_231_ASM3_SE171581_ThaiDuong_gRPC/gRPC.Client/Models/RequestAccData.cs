namespace gRPC.Client.Models
{
    public class RequestAccData
    {
        public int Id { get; set; }
        public string? Role { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public int? Point { get; set; }
        public string? AvatarUrl { get; set; }
        public bool? IsActive { get; set; }
        public string? CreateAt { get; set; }
        public string? httpMethod { get; set; }
    }
}
