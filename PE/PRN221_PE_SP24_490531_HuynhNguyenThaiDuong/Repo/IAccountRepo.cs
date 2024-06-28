using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public interface IAccountRepo
    {
        public Account Login(string email, string password);
    }
}
