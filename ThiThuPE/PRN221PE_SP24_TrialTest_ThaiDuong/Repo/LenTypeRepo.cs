using BO;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class LenTypeRepo : ILenTypeRepo
    {
        public List<LensType> GetAllLens() => LensTypeDAO.Instance.GetAllLens();
    }
}
