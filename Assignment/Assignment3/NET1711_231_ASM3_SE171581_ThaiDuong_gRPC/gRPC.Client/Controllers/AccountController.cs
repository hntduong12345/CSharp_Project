using Google.Protobuf.WellKnownTypes;
using gRPC.Client.Models;
using gRPC.Client.Protos;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Drawing;
using System.Net;
using System.Numerics;

namespace gRPC.Client.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ResponseData> Save(RequestAccData request)
        {
            try
            {
                var httpHandler = new HttpClientHandler();
                httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                var channel = GrpcChannel.ForAddress("http://localhost:5023", new GrpcChannelOptions { HttpHandler = httpHandler });
                var client = new gRPC.Client.Protos.AccountCRUD.AccountCRUDClient(channel);

                switch (request.httpMethod)
                {
                    case "POST":
                        client.Insert(new Account()
                        {
                            ID = request.Id,
                            Role = request.Role,
                            FullName = request.FullName,
                            Email = request.Email,
                            Password = request.Password,
                            DateOfBirth = request.DateOfBirth,
                            Address = request.Address,
                            Phone = request.Phone,
                            Point = (int)request.Point,
                            AvatarUrl = request.AvatarUrl,
                            IsActive = (bool)request.IsActive,
                            CreateAt = DateOnly.FromDateTime(DateTime.Now).ToString(),
                        });
                        break;
                    case "PUT":
                        Account acc = client.SelectByID(new AccountFilter() { ID = request.Id });
                        acc.ID = request.Id;
                        acc.Role = request.Role;
                        acc.FullName = request.FullName;
                        acc.Email = request.Email;
                        acc.Password = request.Password;
                        acc.DateOfBirth = request.DateOfBirth;
                        acc.Address = request.Address;
                        acc.Phone = request.Phone;
                        acc.Point = (int)request.Point;
                        acc.AvatarUrl = request.AvatarUrl;
                        acc.IsActive = (bool)request.IsActive;

                        client.Update(acc);

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
        public async Task<List<Account>> GetAccList()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var channel = GrpcChannel.ForAddress("http://localhost:5023", new GrpcChannelOptions { HttpHandler = httpHandler });
            var client = new gRPC.Client.Protos.AccountCRUD.AccountCRUDClient(channel);

            Accounts accs = client.SelectAll(new EmptyAcc());

            List<Account> accList = new List<Account>();
            accList.AddRange(accs.Items);

            return accList;
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
            var client = new gRPC.Client.Protos.AccountCRUD.AccountCRUDClient(channel);

            Account acc = client.SelectByID(new AccountFilter() { ID = id });

            return PartialView("Detail", acc);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id)
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            var channel = GrpcChannel.ForAddress("http://localhost:5023", new GrpcChannelOptions { HttpHandler = httpHandler });
            var client = new gRPC.Client.Protos.AccountCRUD.AccountCRUDClient(channel);

            Account acc = client.SelectByID(new AccountFilter() { ID = id });

            return PartialView("Edit", acc);
        }

        [HttpDelete]
        public async Task<ResponseData> Delete(int id)
        {
            try
            {
                var httpHandler = new HttpClientHandler();
                httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                var channel = GrpcChannel.ForAddress("http://localhost:5023", new GrpcChannelOptions { HttpHandler = httpHandler });
                var client = new gRPC.Client.Protos.AccountCRUD.AccountCRUDClient(channel);

                client.Delete(new AccountFilter() { ID = id });

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
