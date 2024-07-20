using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IUserAccountService
    {
        public Task<AuthenDTO> Login(AuthenticationDTO request);
    }
}
