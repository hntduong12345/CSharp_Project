using BO;
using BO.Models;
using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserAccountRepository
    {
        public AuthenDTO Login(AuthenticationDTO request) => UserAccountDAO.Instance.Login(request);
    }
}
