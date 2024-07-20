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
    public class WatercolorsPaintingRepository : IWatercolorsPaintingRepository
    {
        public async Task<List<WatercolorsPainting>> GetAll() => await WatercolorsPaintingDAO.Instance.GetAll();
        public async Task<WatercolorsPainting> GetById(string id) =>await WatercolorsPaintingDAO.Instance.GetById(id);
        public async Task<ResultData> Delete(string id) => await WatercolorsPaintingDAO.Instance.Delete(id);
        public async Task<ResultData> Create(WatercolorsPaintingDTO paint) => await WatercolorsPaintingDAO.Instance.Create(paint);
        public async Task<ResultData> Update(string id, UpdateWatercolorsPaintingDTO paint) => await WatercolorsPaintingDAO.Instance.Update(id, paint);
        public async Task<List<WatercolorsPainting>> Search(string searchValue) => await WatercolorsPaintingDAO.Instance.Search(searchValue);
    }
}
