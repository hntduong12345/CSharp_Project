using BO;
using BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IWatercolorsPaintingRepository
    {
        public Task<List<WatercolorsPainting>> GetAll();
        public Task<WatercolorsPainting> GetById(string id);
        public Task<ResultData> Delete(string id);
        public Task<ResultData> Create(WatercolorsPaintingDTO paint);
        public Task<ResultData> Update(string id, UpdateWatercolorsPaintingDTO paint);
        public Task<List<WatercolorsPainting>> Search(string searchValue);
    }
}
