//using Google.Protobuf.WellKnownTypes;
using gRPC.Client.Models;
using gRPC.Client.Protos;
using Grpc.Net.Client;
using Grpc.Net.Client.Balancer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Diagnostics;
using System.Security.Principal;
using ToDos = gRPC.Client.Protos.ToDos;

namespace gRPC.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ResponseData> Save(RequestData request)
        {
            try
            {
                var httpHandler = new HttpClientHandler();
                httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                var channel = GrpcChannel.ForAddress("http://localhost:5023", new GrpcChannelOptions { HttpHandler = httpHandler });
                var client = new gRPC.Client.Protos.ToDoCRUD.ToDoCRUDClient(channel);

                switch (request.httpMethod)
                {
                    case "POST":
                        client.Insert(new ToDo()
                        {
                            Name = request.Name,
                            Description = request.Description,
                        });
                        break;
                    case "PUT":
                        ToDo todo = client.SelectByID(new ToDoFilter() { ToDoID = request.ToDoId });
                        todo.Name = request.Name;
                        todo.Description = request.Description;

                        client.Update(todo);

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
        public async Task<List<ToDo>> GetToDoList()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var channel = GrpcChannel.ForAddress("http://localhost:5023", new GrpcChannelOptions { HttpHandler = httpHandler });
            var client = new gRPC.Client.Protos.ToDoCRUD.ToDoCRUDClient(channel);

            ToDos toDos = client.SelectAll(new Empty());

            List<ToDo> todoList = new List<ToDo>();
            todoList.AddRange(toDos.Items);

            return todoList;
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
            var client = new gRPC.Client.Protos.ToDoCRUD.ToDoCRUDClient(channel);

            ToDo todo = client.SelectByID(new ToDoFilter() { ToDoID = id });

            return PartialView("Detail", todo);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id)
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var channel = GrpcChannel.ForAddress("http://localhost:5023", new GrpcChannelOptions { HttpHandler = httpHandler });
            var client = new gRPC.Client.Protos.ToDoCRUD.ToDoCRUDClient(channel);

            ToDo todo = client.SelectByID(new ToDoFilter() { ToDoID = id });

            return PartialView("Detail", todo);
        }

        [HttpDelete]
        public async Task<ResponseData> Delete(int id)
        {
            try
            {
                var httpHandler = new HttpClientHandler();
                httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                var channel = GrpcChannel.ForAddress("http://localhost:5023", new GrpcChannelOptions { HttpHandler = httpHandler });
                var client = new gRPC.Client.Protos.ToDoCRUD.ToDoCRUDClient(channel);

                client.Delete(new ToDoFilter() { ToDoID = id });

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



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
