using BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public interface IFootballClubRepo
    {
        public Task<List<FootballClub>> GetAllClubs();
    }
}
