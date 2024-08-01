using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using NET1711_231_ASM3_SE171581_ThaiDuong_gRPC.Models;
using NET1711_231_ASM3_SE171581_ThaiDuong_gRPC.Protos;
using System.Reflection.Metadata;

namespace NET1711_231_ASM3_SE171581_ThaiDuong_gRPC.Services
{
    public class BlogCRUDService : NET1711_231_ASM3_SE171581_ThaiDuong_gRPC.Protos.BlogCRUD.BlogCRUDBase
    {
        private readonly ILogger<BlogCRUDService> _logger;
        private Models.ToDoDBContext _db;

        public BlogCRUDService(ILogger<BlogCRUDService> logger, Models.ToDoDBContext db)
        {
            _logger = logger;
            _db = db;
        }

        public override Task<EmptyBlog> Delete(BlogFilter request, ServerCallContext context)
        {
            NET1711_231_ASM3_SE171581_ThaiDuong_gRPC.Models.Blog data = _db.Blogs.Find(request.ID);
            _db.Blogs.Remove(data);
            _db.SaveChanges();
            return Task.FromResult(new EmptyBlog());
        }

        public override Task<EmptyBlog> Insert(Protos.Blog request, ServerCallContext context)
        {
            _db.Blogs.Add(new Models.Blog()
            {
                Id = request.ID,
                AccountId = request.AccountID,
                BlogCategoryId = request.BlogCategoryID,
                Title = request.Title,
                DocUrl = request.DocUrl,
                CreateAt = request.CreateAt,
                UpdateAt = request.UpdateAt,
                ImageUrl = request.ImageUrl,
            });
            _db.SaveChanges();
            return Task.FromResult(new EmptyBlog());
        }

        public override Task<Blogs> SelectAll(EmptyBlog request, ServerCallContext context)
        {
            Blogs responseData = new Blogs();
            var query = from blog in _db.Blogs
                        select new Protos.Blog()
                        {
                            ID = blog.Id,
                            AccountID = blog.AccountId,
                            BlogCategoryID = blog.BlogCategoryId,
                            Title = blog.Title,
                            DocUrl = blog.DocUrl,
                            CreateAt = blog.CreateAt,
                            UpdateAt = blog.UpdateAt,
                            ImageUrl = blog.ImageUrl,
                        };
            responseData.Items.AddRange(query.ToArray());
            return Task.FromResult(responseData);
        }

        public override Task<Protos.Blog> SelectByID(BlogFilter request, ServerCallContext context)
        {
            var data = _db.Blogs.Find(request.ID);
            Protos.Blog blog = new Protos.Blog()
            {
                ID = data.Id,
                AccountID = data.AccountId,
                BlogCategoryID = data.BlogCategoryId,
                Title = data.Title,
                DocUrl = data.DocUrl,
                CreateAt = data.CreateAt,
                UpdateAt = data.UpdateAt,
                ImageUrl = data.ImageUrl,
            };
            return Task.FromResult(blog);
        }

        public override Task<EmptyBlog> Update(Protos.Blog request, ServerCallContext context)
        {
            _db.Blogs.Update(new Models.Blog()
            {
                Id = request.ID,
                AccountId = request.AccountID,
                BlogCategoryId = request.BlogCategoryID,
                Title = request.Title,
                DocUrl = request.DocUrl,
                CreateAt = request.CreateAt,
                UpdateAt = request.UpdateAt,
                ImageUrl = request.ImageUrl,
            });
            _db.SaveChanges();
            return Task.FromResult(new EmptyBlog());
        }
    }
}
