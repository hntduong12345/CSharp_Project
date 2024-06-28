using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class AccountDAO
    {
        private readonly Equipments2024DBContext _dbContext = null;
        private static AccountDAO instance = null;
        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            }
        }

        public AccountDAO()
        {
            _dbContext = new Equipments2024DBContext();
        }

        public Account Login(string email, string password)
        {
            return _dbContext.Accounts.FirstOrDefault(a => a.Email.Equals(email) && a.Password.Equals(password));
        }
    }
}
