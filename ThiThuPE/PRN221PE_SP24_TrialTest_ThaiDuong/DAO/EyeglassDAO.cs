using BO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class EyeglassDAO
    {
        private readonly Eyeglasses2024DBContext _dbContext = null;
        private static EyeglassDAO instance = null;
        public static EyeglassDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EyeglassDAO();
                }
                return instance;
            }
        }

        public EyeglassDAO()
        {
            if (_dbContext == null)
                _dbContext = new Eyeglasses2024DBContext();
        }

        public List<Eyeglass> GetAll()
        {
            return _dbContext.Eyeglasses.Include(e => e.LensType).ToList();
        }

        public Eyeglass GetById(int id)
        {
            return _dbContext.Eyeglasses.FirstOrDefault(e => e.EyeglassesId == id);
        }

        //Pagination
        public List<Eyeglass> GetPaginate(int page, int size, string searchValue)
        {
            List<Eyeglass> result = new List<Eyeglass>();
            if (string.IsNullOrEmpty(searchValue))
            {
                result = _dbContext.Eyeglasses.Include(e => e.LensType).ToList();
            }
            else
            {
                result = Seach(searchValue);
            }

            return result.Skip((page - 1) * size).Take(size).ToList();
        }

        //Search
        public List<Eyeglass> Seach(string searchValue)
        {
            return _dbContext.Eyeglasses.Include(e => e.LensType)
                                        .Where(e => e.EyeglassesDescription.Contains(searchValue) ||
                                                    e.Price.ToString().Contains(searchValue)).ToList();
        }
        
        //C UD
        public bool Delete(int id)
        {
            Eyeglass eyeglass = GetById(id);
            if (eyeglass == null) return false;

            _dbContext.Remove(eyeglass);
            _dbContext.SaveChanges();
            return true;
        }

        public void Add(Eyeglass eyeglass)
        {
            _dbContext.Add(eyeglass);
            _dbContext.SaveChanges();
        }

        public void Update(Eyeglass eyeglass)
        {
            Eyeglass beforeEyeglass = GetById(eyeglass.EyeglassesId);

            if (beforeEyeglass == null) return;

            _dbContext.Entry(beforeEyeglass).CurrentValues.SetValues(eyeglass);
            _dbContext.SaveChanges();
        }
    }
}
