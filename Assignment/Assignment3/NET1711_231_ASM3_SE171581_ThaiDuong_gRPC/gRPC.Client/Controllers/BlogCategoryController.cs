using Google.Protobuf.WellKnownTypes;
using gRPC.Client.Models;
using gRPC.Client.Protos;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;

namespace gRPC.Client.Controllers
{
    public class BlogCategoryController : Controller
    {
        private readonly ILogger<BlogCategoryController> _logger;

        public BlogCategoryController(ILogger<BlogCategoryController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ResponseData> Save(RequestCateData request)
        {
            try
            {
                var httpHandler = new HttpClientHandler();
                httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                var channel = GrpcChannel.ForAddress("http://localhost:5023", new GrpcChannelOptions { HttpHandler = httpHandler });
                var client = new gRPC.Client.Protos.BlogCategoryCRUD.BlogCategoryCRUDClient(channel);

                switch (request.httpMethod)
                {
                    case "POST":
                        client.Insert(new Protos.BlogCategory()
                        {
                            ID = request.Id,
                            Name = request.Name
                        });
                        break;
                    case "PUT":
                        BlogCategory cate = client.SelectByID(new BlogCategoryFilter() { ID = request.Id });
                        cate.ID = request.Id;
                        cate.Name = request.Name;

                        client.Update(cate);

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
        public async Task<List<BlogCategory>> GetCateList()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var channel = GrpcChannel.ForAddress("http://localhost:5023", new GrpcChannelOptions { HttpHandler = httpHandler });
            var client = new gRPC.Client.Protos.BlogCategoryCRUD.BlogCategoryCRUDClient(channel);

            BlogCategories cates = client.SelectAll(new EmptyBlogCategory());

            List<BlogCategory> cateList = new List<BlogCategory>();
            cateList.AddRange(cates.Items);

            return cateList;
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
            var client = new gRPC.Client.Protos.BlogCategoryCRUD.BlogCategoryCRUDClient(channel);

            BlogCategory cate = client.SelectByID(new BlogCategoryFilter() { ID = id });

            return PartialView("Detail", cate);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id)
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var channel = GrpcChannel.ForAddress("http://localhost:5023", new GrpcChannelOptions { HttpHandler = httpHandler });
            var client = new gRPC.Client.Protos.BlogCategoryCRUD.BlogCategoryCRUDClient(channel);

            BlogCategory cate = client.SelectByID(new BlogCategoryFilter() { ID = id });

            return PartialView("Edit", cate);
        }

        [HttpDelete]
        public async Task<ResponseData> Delete(int id)
        {
            try
            {
                var httpHandler = new HttpClientHandler();
                httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                var channel = GrpcChannel.ForAddress("http://localhost:5023", new GrpcChannelOptions { HttpHandler = httpHandler });
                var client = new gRPC.Client.Protos.BlogCategoryCRUD.BlogCategoryCRUDClient(channel);

                client.Delete(new BlogCategoryFilter() { ID = id });

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
