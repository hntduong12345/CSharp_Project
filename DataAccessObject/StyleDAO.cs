using BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class StyleDAO
    {
        private readonly WatercolorsPainting2024DBContext _context;
        private static StyleDAO instance;
        public static StyleDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StyleDAO();
                }
                return instance;
            }
        }

        public StyleDAO()
        {
            if (_context == null)
                _context = new WatercolorsPainting2024DBContext();
        }

        public List<Style> GetAllStyles()
        {
            return _context.Styles.ToList();
        }
    }
}
