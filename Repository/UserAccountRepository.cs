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
        public async Task<AuthenDTO> Login(AuthenticationDTO request) => await UserAccountDAO.Instance.Login(request);
    }
}
