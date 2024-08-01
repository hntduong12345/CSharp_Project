using Google.Protobuf.WellKnownTypes;
using gRPC.Client.Models;
using gRPC.Client.Protos;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;

namespace gRPC.Client.Controllers
{
    public class BlogController : Controller
    {
        private readonly ILogger<BlogController> _logger;

        public BlogController(ILogger<BlogController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ResponseData> Save(RequestBlogData request)
        {
            try
            {
                var httpHandler = new HttpClientHandler();
                httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                var channel = GrpcChannel.ForAddress("http://localhost:5023", new GrpcChannelOptions { HttpHandler = httpHandler });
                var client = new gRPC.Client.Protos.BlogCRUD.BlogCRUDClient(channel);

                switch (request.httpMethod)
                {
                    case "POST":
                        client.Insert(new Protos.Blog()
                        {
                            ID = request.Id,
                            AccountID = request.AccountId,
                            BlogCategoryID = request.BlogCategoryId,
                            Title = request.Title,
                            DocUrl = request.DocUrl,
                            CreateAt = DateOnly.FromDateTime(DateTime.Now).ToString(),
                            UpdateAt = DateOnly.FromDateTime(DateTime.Now).ToString(),
                            ImageUrl = request.ImageUrl,
                        });
                        break;
                    case "PUT":
                        Blog blog = client.SelectByID(new BlogFilter() { ID = request.Id });
                        blog.ID = request.Id;
                        blog.AccountID = request.AccountId;
                        blog.BlogCategoryID = request.BlogCategoryId;
                        blog.Title = request.Title;
                        blog.DocUrl = request.DocUrl;
                        blog.UpdateAt = DateOnly.FromDateTime(DateTime.Now).ToString();
                        blog.ImageUrl = request.ImageUrl;

                        client.Update(blog);

                        break;
                }

                return new ResponseData()
                {
                    Message = "Action success",
                    Status = 1
                };
            }
            catch (Exception ex)
            {
                return new ResponseData()
                {
                    Message = "Action fail",
                    Status = -1
                };
            }

        }

        [HttpGet]
        public async Task<List<Blog>> GetBlogList()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var channel = GrpcChannel.ForAddress("http://localhost:5023", new GrpcChannelOptions { HttpHandler = httpHandler });
            var client = new gRPC.Client.Protos.BlogCRUD.BlogCRUDClient(channel);

            Blogs blogs = client.SelectAll(new EmptyBlog());

            List<Blog> blogList = new List<Blog>();
            blogList.AddRange(blogs.Items);

            return blogList;
        }

        [HttpGet]
        public IActionResult AddNew()
        {
            return PartialView("Add");
        }

        [HttpPost]
        public async Task<IActionResult> Detail(int id)
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var channel = GrpcChannel.ForAddress("http://localhost:5023", new GrpcChannelOptions { HttpHandler = httpHandler });
            var client = new gRPC.Client.Protos.BlogCRUD.BlogCRUDClient(channel);

            Blog blog = client.SelectByID(new BlogFilter() { ID = id });

            return PartialView("Detail", blog);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id)
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var channel = GrpcChannel.ForAddress("http://localhost:5023", new GrpcChannelOptions { HttpHandler = httpHandler });
            var client = new gRPC.Client.Protos.BlogCRUD.BlogCRUDClient(channel);

            Blog blog = client.SelectByID(new BlogFilter() { ID = id });

            return PartialView("Edit", blog);
        }

        [HttpDelete]
        public async Task<ResponseData> Delete(int id)
        {
            try
            {
                var httpHandler = new HttpClientHandler();
                httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                var channel = GrpcChannel.ForAddress("http://localhost:5023", new GrpcChannelOptions { HttpHandler = httpHandler });
                var client = new gRPC.Client.Protos.BlogCRUD.BlogCRUDClient(channel);

                client.Delete(new BlogFilter() { ID = id });

                return new ResponseData()
                {
                    Message = "Action success",
                    Status = 1
                };
            }
            catch (Exception ex)
            {
                return new ResponseData()
                {
                    Message = "Action fail",
                    Status = -1
                };
            }
        }
    }
}
