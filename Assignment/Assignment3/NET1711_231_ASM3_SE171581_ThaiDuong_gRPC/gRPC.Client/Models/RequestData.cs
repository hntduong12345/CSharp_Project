namespace gRPC.Client.Models
{
    public class RequestData
    {
        public int ToDoId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? httpMethod { get; set; }
    }
}
