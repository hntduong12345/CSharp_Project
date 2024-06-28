using BO;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class AccountRepo : IAccountRepo
    {
        public Account Login(string email, string password) => AccountDAO.Instance.Login(email, password);
    }
}
