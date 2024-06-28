using BookManagement_HuynhNguyenThaiDuong.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement_HuynhNguyenThaiDuong.Repo.Repo
{
    public class BookCategoryRepo
    {
        private readonly BookManagement2023DBContext _dbContext;
        public BookCategoryRepo(BookManagement2023DBContext context)
        {
            _dbContext = context;
        }

        public string getCategory(int id)
        {
            return _dbContext.BookCategories.Find(id).BookGenreType;
        }
    }
}
