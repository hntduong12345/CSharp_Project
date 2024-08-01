using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfService.Models;

namespace WcfService.DataSrc
{
    public class AccData
    {
        public static List<Account> Accounts = new List<Account>()
        {
            new Account{Id = 1, Address = "Test1", Email = "admin1@gmail.com", FullName = "Admin1", IsActive = true, Password = "admin1123", Phone = "0983746574", Point = 1, Role = "Admin"},
            new Account{Id = 2, Address = "Test2", Email = "admin2@gmail.com", FullName = "Admin2", IsActive = true, Password = "admin2123", Phone = "0942353244", Point = 1, Role = "Admin"},
            new Account{Id = 3, Address = "Test3", Email = "staff1@gmail.com", FullName = "Staff1", IsActive = true, Password = "staff1123", Phone = "0926473648", Point = 2, Role = "Staff"},
            new Account{Id = 4, Address = "Test4", Email = "staff2@gmail.com", FullName = "Staff2", IsActive = true, Password = "staff2123", Phone = "0974836284", Point = 2, Role = "Staff"},
            new Account{Id = 5, Address = "Test5", Email = "member1@gmail.com", FullName = "Member1", IsActive = true, Password = "member1123", Phone = "0975836582", Point = 3, Role = "Member"},
            new Account{Id = 6, Address = "Test6", Email = "member2@gmail.com", FullName = "Member2", IsActive = true, Password = "member2123", Phone = "0974628465", Point = 3, Role = "Member"},
            new Account{Id = 7, Address = "Test7", Email = "member3@gmail.com", FullName = "Member3", IsActive = true, Password = "member3123", Phone = "0973527455", Point = 3, Role = "Member"},
            new Account{Id = 8, Address = "Test8", Email = "member4@gmail.com", FullName = "Member4", IsActive = true, Password = "member4123", Phone = "0963816384", Point = 3, Role = "Member"},
            new Account{Id = 9, Address = "Test9", Email = "member5@gmail.com", FullName = "Member5", IsActive = true, Password = "member5123", Phone = "0951426487", Point = 3, Role = "Member"},
        };
    }
}