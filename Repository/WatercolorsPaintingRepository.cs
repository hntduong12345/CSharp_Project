using BO;
using BO.Models;
using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class WatercolorsPaintingRepository
    {
        public List<WatercolorsPainting> GetAll() => WatercolorsPaintingDAO.Instance.GetAll();
        public WatercolorsPainting GetById(string id) => WatercolorsPaintingDAO.Instance.GetById(id);
        public ResultData Delete(string id) => WatercolorsPaintingDAO.Instance.Delete(id);
        public ResultData Create(WatercolorsPaintingDTO paint) => WatercolorsPaintingDAO.Instance.Create(paint);
        public ResultData Update(string id, UpdateWatercolorsPaintingDTO paint) => WatercolorsPaintingDAO.Instance.Update(id, paint);
        public List<WatercolorsPainting> Search(string searchValue) => WatercolorsPaintingDAO.Instance.Search(searchValue);
    }
}
