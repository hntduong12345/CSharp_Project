using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public interface IEyeglassesRepo
    {
        public List<Eyeglass> GetAll();
        public Eyeglass GetById(int id);
        public bool Delete(int id);
        public void Add(Eyeglass eyeglass);
        public void Update(Eyeglass eyeglass);
        public List<Eyeglass> GetPaginate(int page, int size, string searchValue);
        public List<Eyeglass> Seach(string searchValue);
    }
}
