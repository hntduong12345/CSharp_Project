using BO;
using BO.Models;
using DataAccessObject.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class UserAccountDAO
    {
        private readonly WatercolorsPainting2024DBContext _context;
        private static UserAccountDAO instance;
        public static UserAccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserAccountDAO();
                }
                return instance;
            }
        }

        public UserAccountDAO()
        {
            if (_context == null)
                _context = new WatercolorsPainting2024DBContext();
        }

        public async Task<AuthenDTO> Login(AuthenticationDTO request)
        {
            UserAccount account = await _context.UserAccounts.FirstOrDefaultAsync(a => a.UserEmail.Equals(request.Email) && 
                                                                                       a.UserPassword.Equals(request.Password));
            if (account == null) return null;

            return new AuthenDTO
            {
                Token = JwtUtil.GenerateJwtToken(account)
            };
        }
    }
}

