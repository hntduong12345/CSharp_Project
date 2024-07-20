using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUserAccountRepository
    {
        public Task<AuthenDTO> Login(AuthenticationDTO request);
    }
}
