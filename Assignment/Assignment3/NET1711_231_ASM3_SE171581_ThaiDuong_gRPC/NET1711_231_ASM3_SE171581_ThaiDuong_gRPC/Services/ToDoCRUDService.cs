using Grpc.Core;
using NET1711_231_ASM3_SE171581_ThaiDuong_gRPC.Protos;

namespace NET1711_231_ASM3_SE171581_ThaiDuong_gRPC.Services
{
    public class ToDoCRUDService : NET1711_231_ASM3_SE171581_ThaiDuong_gRPC.Protos.ToDoCRUD.ToDoCRUDBase
    {
        private readonly ILogger<ToDoCRUDService> _logger;
        private Models.ToDoDBContext _db;

        public ToDoCRUDService(ILogger<ToDoCRUDService> logger, Models.ToDoDBContext db)
        {
            _logger = logger;
            _db = db;
        }

        public override Task<Empty> Delete(ToDoFilter request, ServerCallContext context)
        {
            NET1711_231_ASM3_SE171581_ThaiDuong_gRPC.Models.ToDo data = _db.ToDos.Find(request.ToDoID);
            _db.ToDos.Remove(data);
            _db.SaveChanges();
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> Insert(ToDo request, ServerCallContext context)
        {
            _db.ToDos.Add(new Models.ToDo()
            {
                ToDoId = request.ToDoID,
                Name = request.Name,
                Description = request.Description,
            });
            _db.SaveChanges();
            return Task.FromResult(new Empty());
        }

        public override Task<ToDos> SelectAll(Empty request, ServerCallContext context)
        {
            ToDos responseData = new ToDos();
            var query = from todo in _db.ToDos
                        select new ToDo()
                        {
                            ToDoID = todo.ToDoId,
                            Name = todo.Name,
                            Description = todo.Description,
                        };
            responseData.Items.AddRange(query.ToArray());
            return Task.FromResult(responseData);
        }

        public override Task<ToDo> SelectByID(ToDoFilter request, ServerCallContext context)
        {
            var data = _db.ToDos.Find(request.ToDoID);
            ToDo toDo = new ToDo()
            {
                ToDoID = data.ToDoId,
                Name = data.Name,
                Description = data.Description,
            };
            return Task.FromResult(toDo);
        }

        public override Task<Empty> Update(ToDo request, ServerCallContext context)
        {
            _db.ToDos.Update(new Models.ToDo()
            {
                ToDoId = request.ToDoID,
                Name = request.Name,
                Description = request.Description,
            });
            _db.SaveChanges();
            return Task.FromResult(new Empty());
        }
    }
}

