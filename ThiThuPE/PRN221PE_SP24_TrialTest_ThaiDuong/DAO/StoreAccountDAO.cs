using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class StoreAccountDAO
    {
        private readonly Eyeglasses2024DBContext _dbContext = null;
        private static StoreAccountDAO instance = null;
        public static StoreAccountDAO Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new StoreAccountDAO();
                }
                return instance;
            }
        }

        public StoreAccountDAO()
        {
            if(_dbContext == null)
                _dbContext = new Eyeglasses2024DBContext();
        }

        public StoreAccount Login(string email, string pass)
        {
            return _dbContext.StoreAccounts.FirstOrDefault(acc => acc.EmailAddress.Equals(email) && acc.AccountPassword.Equals(pass));
        }
    }
}
