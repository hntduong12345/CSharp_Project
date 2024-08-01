using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using NET1711_231_ASM3_SE171581_ThaiDuong_gRPC.Protos;

namespace NET1711_231_ASM3_SE171581_ThaiDuong_gRPC.Services
{
    public class BlogCategoryCRUDService : NET1711_231_ASM3_SE171581_ThaiDuong_gRPC.Protos.BlogCategoryCRUD.BlogCategoryCRUDBase
    {
        private readonly ILogger<BlogCategoryCRUDService> _logger;
        private Models.ToDoDBContext _db;

        public BlogCategoryCRUDService(ILogger<BlogCategoryCRUDService> logger, Models.ToDoDBContext db)
        {
            _logger = logger;
            _db = db;
        }

        public override Task<EmptyBlogCategory> Delete(BlogCategoryFilter request, ServerCallContext context)
        {
            NET1711_231_ASM3_SE171581_ThaiDuong_gRPC.Models.BlogCategory data = _db.BlogCategories.Find(request.ID);
            _db.BlogCategories.Remove(data);
            _db.SaveChanges();
            return Task.FromResult(new EmptyBlogCategory());
        }

        public override Task<EmptyBlogCategory> Insert(Protos.BlogCategory request, ServerCallContext context)
        {
            _db.BlogCategories.Add(new Models.BlogCategory()
            {
                Id = request.ID,
                Name = request.Name,
            });
            _db.SaveChanges();
            return Task.FromResult(new EmptyBlogCategory());
        }

        public override Task<BlogCategories> SelectAll(EmptyBlogCategory request, ServerCallContext context)
        {
            BlogCategories responseData = new BlogCategories();
            var query = from blogcategory in _db.BlogCategories
                        select new Protos.BlogCategory()
                        {
                            ID = blogcategory.Id,
                            Name = blogcategory.Name
                        };
            responseData.Items.AddRange(query.ToArray());
            return Task.FromResult(responseData);
        }

        public override Task<Protos.BlogCategory> SelectByID(BlogCategoryFilter request, ServerCallContext context)
        {
            var data = _db.BlogCategories.Find(request.ID);
            Protos.BlogCategory cate = new Protos.BlogCategory()
            {
                ID = data.Id,
                Name= data.Name,
            };
            return Task.FromResult(cate);
        }

        public override Task<EmptyBlogCategory> Update(Protos.BlogCategory request, ServerCallContext context)
        {
            _db.BlogCategories.Update(new Models.BlogCategory()
            {
                Id = request.ID,
                Name = request.Name,
            });
            _db.SaveChanges();
            return Task.FromResult(new EmptyBlogCategory());
        }

    }
}
