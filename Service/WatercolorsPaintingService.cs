using BO;
using BO.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class WatercolorsPaintingService : IWatercolorsPaintingService
    {
        private readonly IWatercolorsPaintingRepository _watercolorsPaintingRepository;
        public WatercolorsPaintingService(IWatercolorsPaintingRepository watercolorsPaintingRepository)
        {
            _watercolorsPaintingRepository = watercolorsPaintingRepository;
        }

        public async Task<ResultData> Create(WatercolorsPaintingDTO paint)
        {
            return await _watercolorsPaintingRepository.Create(paint);
        }

        public async Task<ResultData> Delete(string id)
        {
            return await _watercolorsPaintingRepository.Delete(id);
        }

        public async Task<List<WatercolorsPainting>> GetAll()
        {
            return await _watercolorsPaintingRepository.GetAll();
        }

        public async Task<WatercolorsPainting> GetById(string id)
        {
            return await _watercolorsPaintingRepository.GetById(id);
        }

        public async Task<List<WatercolorsPainting>> Search(string searchValue)
        {
            return await _watercolorsPaintingRepository.Search(searchValue);
        }

        public async Task<ResultData> Update(string id, UpdateWatercolorsPaintingDTO paint)
        {
            return await _watercolorsPaintingRepository.Update(id, paint);
        }
    }
}
