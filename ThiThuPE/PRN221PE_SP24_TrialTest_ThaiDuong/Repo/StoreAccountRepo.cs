using BO;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class StoreAccountRepo : IStoreAccountRepo
    {
        public StoreAccount Login(string username, string password) => StoreAccountDAO.Instance.Login(username, password);
    }
}
