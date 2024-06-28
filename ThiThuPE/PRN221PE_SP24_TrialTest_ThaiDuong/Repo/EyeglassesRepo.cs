using BO;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class EyeglassesRepo : IEyeglassesRepo
    {
        public List<Eyeglass> GetAll() => EyeglassDAO.Instance.GetAll();
        public Eyeglass GetById(int id) => EyeglassDAO.Instance.GetById(id);
        public bool Delete(int id) => EyeglassDAO.Instance.Delete(id);
        public void Add(Eyeglass eyeglass) => EyeglassDAO.Instance.Add(eyeglass);
        public void Update(Eyeglass eyeglass) => EyeglassDAO.Instance.Update(eyeglass);
        public List<Eyeglass> GetPaginate(int page, int size, string searchValue)
            => EyeglassDAO.Instance.GetPaginate(page, size, searchValue);
        public List<Eyeglass> Seach(string searchValue) => EyeglassDAO.Instance.Seach(searchValue);
    }
}
