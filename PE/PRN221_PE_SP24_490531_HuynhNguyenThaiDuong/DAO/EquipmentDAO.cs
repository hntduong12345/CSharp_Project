using BO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class EquipmentDAO
    {
        private readonly Equipments2024DBContext _dbContext = null;
        private static EquipmentDAO instance;
        public static EquipmentDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EquipmentDAO();
                }
                return instance;
            }
        }

        public EquipmentDAO()
        {
            if (_dbContext == null)
            {
                _dbContext = new Equipments2024DBContext(); 
            }
        }

        public List<Equipment> GetAll()
        {
            return _dbContext.Equipments.Include(e => e.Room).ToList();
        }

        public Equipment GetById(int id)
        {
            return _dbContext.Equipments.Include(e => e.Room).FirstOrDefault(e => e.EqId == id);
        }

        public bool Delete(int id)
        {
            Equipment equip = GetById(id);
            if (equip == null) return false;

            _dbContext.Equipments.Remove(equip);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Create(Equipment equip)
        {
            if (GetById(equip.EqId) != null) return false;

            _dbContext.Equipments.Add(equip);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Update(Equipment equip)
        {
            Equipment updatedEquip = GetById(equip.EqId);
            _dbContext.Entry(updatedEquip).CurrentValues.SetValues(equip);
            _dbContext.SaveChanges();
            return true;
        }

        //Pagination
        public List<Equipment> GetPaginate(int page, int size, string searchValue)
        {
            List<Equipment> result = new List<Equipment>();
            if (string.IsNullOrEmpty(searchValue))
            {
                result = _dbContext.Equipments.Include(e => e.Room).ToList();
            }
            else
            {
                result = Seach(searchValue);
            }

            return result.Skip((page - 1) * size).Take(size).ToList();
        }

        //Search
        public List<Equipment> Seach(string searchValue)
        {
            return _dbContext.Equipments.Include(e => e.Room)
                                   .Where(e => e.EqName.Contains(searchValue) ||
                                               e.Quantity.ToString().Contains(searchValue)).ToList();
        }

    }
}
