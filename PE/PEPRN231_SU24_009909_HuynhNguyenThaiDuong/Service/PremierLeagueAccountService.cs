using BO.DTOs;
using Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PremierLeagueAccountService : IPremierLeagueAccountService
    {
        private readonly IPremierLeagueAccountRepo _premierLeagueAccountRepo;
        public PremierLeagueAccountService(IPremierLeagueAccountRepo premierLeagueAccountRepo)
        {
            _premierLeagueAccountRepo = premierLeagueAccountRepo;
        }

        public async Task<AuthenResponseDTO> Login(AuthenDTO request)
        {
            return await _premierLeagueAccountRepo.Login(request);
        }
    }
}
