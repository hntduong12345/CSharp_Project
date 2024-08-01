using BO.Models;
using Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class FootballClubService : IFootballClubService
    {
        private readonly IFootballClubRepo _footballClubRepo;
        public FootballClubService(IFootballClubRepo footballClubRepo)
        {
            _footballClubRepo = footballClubRepo;
        }

        public async Task<List<FootballClub>> GetAllClubs()
        {
            return await _footballClubRepo.GetAllClubs();
        }
    }
}
