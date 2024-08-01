using BO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class FootballClubDAO
    {
        private readonly EnglishPremierLeague2024DBContext _context;
        private static FootballClubDAO instance;
        public static FootballClubDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FootballClubDAO();
                }
                return instance;
            }
        }

        public FootballClubDAO()
        {
            if (_context == null)
                _context = new EnglishPremierLeague2024DBContext();
        }

        public async Task<List<FootballClub>> GetAllClubs()
        {
            return await _context.FootballClubs.ToListAsync();
        }
    }
}
