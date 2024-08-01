using BO.DTOs;
using BO.Models;
using DAO.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class PremierLeagueAccountDAO
    {
        private readonly EnglishPremierLeague2024DBContext _context;
        private static PremierLeagueAccountDAO instance;
        public static PremierLeagueAccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PremierLeagueAccountDAO();
                }
                return instance;
            }
        }

        public PremierLeagueAccountDAO()
        {
            if (_context == null)
                _context = new EnglishPremierLeague2024DBContext();
        }

        public async Task<AuthenResponseDTO> Login(AuthenDTO request)
        {
            PremierLeagueAccount account = await _context.PremierLeagueAccounts.FirstOrDefaultAsync(a => a.EmailAddress.Equals(request.Email) &&
                                                                                       a.Password.Equals(request.Password));
            if (account == null) return null;

            return new AuthenResponseDTO
            {
                Token = JwtUtil.GenerateJwtToken(account)
            };
        }
    }
}
