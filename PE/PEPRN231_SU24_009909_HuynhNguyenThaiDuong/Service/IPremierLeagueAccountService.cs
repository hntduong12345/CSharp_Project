using BO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IPremierLeagueAccountService
    {
        public Task<AuthenResponseDTO> Login(AuthenDTO request);
    }
}
