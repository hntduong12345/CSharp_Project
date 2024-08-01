using BO.DTOs;
using BO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IAccountRepo
    {
        public List<Account> GetAllAccounts();
        public Account GetAccount(int id);
        public Account CreateAccount(AccountDTO account);
        public Account UpdateAccount(int id, UpdateAccountDTO account);
        public bool DeleteAccount(int id);
    }
}
