using BO.Models;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class FootballClubRepo : IFootballClubRepo
    {
        public async Task<List<FootballClub>> GetAllClubs() => await FootballClubDAO.Instance.GetAllClubs();
    }
}
