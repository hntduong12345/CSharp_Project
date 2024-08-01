using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using NET1711_231_ASM3_SE171581_ThaiDuong_gRPC.Models;
using NET1711_231_ASM3_SE171581_ThaiDuong_gRPC.Protos;

namespace NET1711_231_ASM3_SE171581_ThaiDuong_gRPC.Services
{
    public class AccountCRUDService : NET1711_231_ASM3_SE171581_ThaiDuong_gRPC.Protos.AccountCRUD.AccountCRUDBase
    {
        private readonly ILogger<AccountCRUDService> _logger;
        private Models.ToDoDBContext _db;

        public AccountCRUDService(ILogger<AccountCRUDService> logger, Models.ToDoDBContext db)
        {
            _logger = logger;
            _db = db;
        }

        public override Task<EmptyAcc> Delete(AccountFilter request, ServerCallContext context)
        {
            NET1711_231_ASM3_SE171581_ThaiDuong_gRPC.Models.Account data = _db.Accounts.Find(request.ID);
            _db.Accounts.Remove(data);
            _db.SaveChanges();
            return Task.FromResult(new EmptyAcc());
        }

        public override Task<EmptyAcc> Insert(Protos.Account request, ServerCallContext context)
        {
            _db.Accounts.Add(new Models.Account()
            {
                Id = request.ID,
                Role = request.Role,
                FullName = request.FullName,
                Email = request.Email,
                Password = request.Password,
                DateOfBirth = request.DateOfBirth,
                Address = request.Address,  
                Phone = request.Phone,
                Point = request.Point,
                AvatarUrl = request.AvatarUrl,
                IsActive = request.IsActive,
                CreateAt = request.CreateAt,
            });
            _db.SaveChanges();
            return Task.FromResult(new EmptyAcc());
        }

        public override Task<Accounts> SelectAll(EmptyAcc request, ServerCallContext context)
        {
            Accounts responseData = new Accounts();
            var query = from account in _db.Accounts
                        select new Protos.Account()
                        {
                            ID = account.Id,
                            Role = account.Role,
                            FullName = account.FullName,
                            Email = account.Email,
                            Password = account.Password,
                            DateOfBirth = account.DateOfBirth,
                            Address = account.Address,
                            Phone = account.Phone,
                            Point = (int)account.Point,
                            AvatarUrl = account.AvatarUrl,
                            IsActive = (bool)account.IsActive,
                            CreateAt = account.CreateAt,
                        };
            responseData.Items.AddRange(query.ToArray());
            return Task.FromResult(responseData);
        }

        public override Task<Protos.Account> SelectByID(AccountFilter request, ServerCallContext context)
        {
            var data = _db.Accounts.Find(request.ID);
            Protos.Account acc = new Protos.Account()
            {
                ID = data.Id,
                Role = data.Role,
                FullName = data.FullName,
                Email = data.Email,
                Password = data.Password,
                DateOfBirth = data.DateOfBirth,
                Address = data.Address,
                Phone = data.Phone,
                Point = (int)data.Point,
                AvatarUrl = data.AvatarUrl,
                IsActive = (bool)data.IsActive,
                CreateAt = data.CreateAt,
            };
            return Task.FromResult(acc);
        }

        public override Task<EmptyAcc> Update(Protos.Account request, ServerCallContext context)
        {
            _db.Accounts.Update(new Models.Account()
            {
                Id = request.ID,
                Role = request.Role,
                FullName = request.FullName,
                Email = request.Email,
                Password = request.Password,
                DateOfBirth = request.DateOfBirth,
                Address = request.Address,
                Phone = request.Phone,
                Point = request.Point,
                AvatarUrl = request.AvatarUrl,
                IsActive = request.IsActive,
                CreateAt = request.CreateAt,
            });
            _db.SaveChanges();
            return Task.FromResult(new EmptyAcc());
        }
    }
}
