using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class LensTypeDAO
    {
        private readonly Eyeglasses2024DBContext _dbContext = null;
        private static LensTypeDAO instance = null;
        public static LensTypeDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LensTypeDAO();
                }
                return instance;
            }
        }

        public LensTypeDAO()
        {
            if(_dbContext == null)
            {
                _dbContext = new Eyeglasses2024DBContext();
            }
        }

        public List<LensType> GetAllLens()
        {
            return _dbContext.LensTypes.ToList();
        }
    }
}
