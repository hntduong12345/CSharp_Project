using BookManagement_HuynhNguyenThaiDuong.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement_HuynhNguyenThaiDuong.Repo.Repo
{
    public class BookRepo
    {
        private readonly BookManagement2023DBContext _dbContext;
        public BookRepo(BookManagement2023DBContext context)
        {
            _dbContext = context;
        }

        public List<Book> GetBooks()
        {
            return _dbContext.Books.ToList();
        }

        public void deleteBook(int id)
        {
            _dbContext.Books.Remove(_dbContext.Books.Find(id));
        }
    }
}
