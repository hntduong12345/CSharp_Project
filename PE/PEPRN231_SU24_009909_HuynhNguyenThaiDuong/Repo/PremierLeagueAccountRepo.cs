using BO.DTOs;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class PremierLeagueAccountRepo : IPremierLeagueAccountRepo
    {
        public async Task<AuthenResponseDTO> Login(AuthenDTO request) => await PremierLeagueAccountDAO.Instance.Login(request);
    }
}
