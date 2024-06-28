using BO;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class EquipmentRepo : IEquipmentRepo
    {
        public List<Equipment> GetAll() => EquipmentDAO.Instance.GetAll();
        public Equipment GetById(int id) => EquipmentDAO.Instance.GetById(id);
        public bool Delete(int id) => EquipmentDAO.Instance.Delete(id);
        public bool Create(Equipment equip) => EquipmentDAO.Instance.Create(equip);
        public bool Update(Equipment equip) => EquipmentDAO.Instance.Update(equip);
        public List<Equipment> GetPaginate(int page, int size, string searchValue)
            => EquipmentDAO.Instance.GetPaginate(page, size, searchValue);
        public List<Equipment> Seach(string searchValue) => EquipmentDAO.Instance.Seach(searchValue);
    }
}
