using MilkData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Data
{
    public static class AccountData
    {
        public static List<Account> accounts = new List<Account>()
        {
            new Account(1, "Nguyen A", "nguyenA@gmail.com", "123", "0964725472", "Abc Street", "Customer", 100, true),
            new Account(2, "Le B", "lb@gmail.com", "123", "0964725472", "Abc Street", "Customer", 100, true),
            new Account(3, "Tran C", "tranC@gmail.com", "312", "0964725472", "Abc Street", "Customer", 100, false),
            new Account(4, "Ly D", "ld@gmail.com", "2141", "0964725472", "Abc Street", "Customer", 100, true),
            new Account(5, "Huynh E", "HE@gmail.com", "14234", "0964725472", "Abc Street", "Customer", 100, true),
            new Account(6, "Van F", "VVF@gmail.com", "32141", "0964725472", "Abc Street", "Customer", 100, false),
        };
    }
}
