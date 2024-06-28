using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public interface IEquipmentRepo
    {
        public List<Equipment> GetAll();
        public Equipment GetById(int id);
        public bool Delete(int id);
        public bool Create(Equipment equip);
        public bool Update(Equipment equip);
        public List<Equipment> GetPaginate(int page, int size, string searchValue);
        public List<Equipment> Seach(string searchValue);
    }
}
