using BookManagement_HuynhNguyenThaiDuong.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement_HuynhNguyenThaiDuong.Repo.Repo
{
    public class BookManagementMemberRepo
    {
        private readonly BookManagement2023DBContext _dbContext;
        public BookManagementMemberRepo(BookManagement2023DBContext context)
        {
            _dbContext = context;
        }

        public int CheckLogin(string email, string password)
        {
            BookManagementMember bookManagement = _dbContext.BookManagementMembers.Where(bm => bm.Email == email &&
            bm.Password == password).FirstOrDefault();
            if (bookManagement != null) { return bookManagement.MemberRole; }

            return 0;
        }
    }
}
