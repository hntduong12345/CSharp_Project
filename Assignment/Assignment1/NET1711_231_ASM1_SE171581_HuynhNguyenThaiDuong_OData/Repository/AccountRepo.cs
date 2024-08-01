using BO.Data;
using BO.DTOs;
using BO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AccountRepo : IAccountRepo
    {
        private readonly ASM1Context _context;
        public AccountRepo()
        {
            _context = new ASM1Context();
        }

        #region OldCode
        //public List<Account> GetAllAccounts()
        //{
        //    return AccountData.accounts.ToList();
        //}

        //public Account GetAccount(int id)
        //{
        //    return AccountData.accounts.FirstOrDefault(x => x.AccountId == id);
        //}

        //public Account CreateAccount(AccountDTO account)
        //{
        //    Account currentAccount = AccountData.accounts.FirstOrDefault(x => x.AccountId == account.AccountId);
        //    if (currentAccount != null) return null;

        //    Account newAcc = new Account(
        //        account.AccountId, account.FullName, account.Email, account.Password, account.Phone,
        //        account.Address, account.Role, account.Point, account.IsActive);

        //    AccountData.accounts.Add(newAcc);
        //    return newAcc;
        //}

        //public Account UpdateAccount(int id, UpdateAccountDTO account)
        //{
        //    Account currentAccount = AccountData.accounts.FirstOrDefault(x => x.AccountId == id);
        //    if (currentAccount == null) return null;

        //    currentAccount.FullName = account.FullName;
        //    currentAccount.Email = account.Email;
        //    currentAccount.Password = account.Password;
        //    currentAccount.Phone = account.Phone;
        //    currentAccount.Address = account.Address;
        //    currentAccount.Role = account.Role;
        //    currentAccount.IsActive = account.IsActive;
        //    currentAccount.Point = account.Point;

        //    return currentAccount;
        //}

        //public bool DeleteAccount(int id)
        //{
        //    Account currentAccount = AccountData.accounts.FirstOrDefault(x => x.AccountId == id);
        //    if (currentAccount == null) return false;

        //    AccountData.accounts.Remove(currentAccount);
        //    return true;
        //}
        #endregion

        public List<Account> GetAllAccounts()
        {
            return _context.Accounts.ToList();
        }

        public Account GetAccount(int id)
        {
            return _context.Accounts.FirstOrDefault(x => x.Id == id);
        }

        public Account CreateAccount(AccountDTO account)
        {
            Account currentAccount = _context.Accounts.FirstOrDefault(x => x.Id == account.AccountId);
            if (currentAccount != null) return null;

            Account newAcc = new Account()
            {
                Id = account.AccountId,
                Address = account.Address,
                Email = account.Email,
                FullName = account.FullName,    
                IsActive = account.IsActive,
                Password = account.Password,
                Phone = account.Phone,  
                Point = account.Point,
                Role = account.Role,
            };
            
            _context.Accounts.Add(newAcc);
            return newAcc;
        }

        public Account UpdateAccount(int id, UpdateAccountDTO account)
        {
            Account currentAccount = _context.Accounts.FirstOrDefault(x => x.Id == id);
            if (currentAccount == null) return null;

            currentAccount.FullName = account.FullName;
            currentAccount.Email = account.Email;
            currentAccount.Password = account.Password;
            currentAccount.Phone = account.Phone;
            currentAccount.Address = account.Address;
            currentAccount.Role = account.Role;
            currentAccount.IsActive = account.IsActive;
            currentAccount.Point = account.Point;

            return currentAccount;
        }

        public bool DeleteAccount(int id)
        {
            Account currentAccount = _context.Accounts.FirstOrDefault(x => x.Id == id);
            if (currentAccount == null) return false;

            _context.Accounts.Remove(currentAccount);
            return true;
        }
    }
}
