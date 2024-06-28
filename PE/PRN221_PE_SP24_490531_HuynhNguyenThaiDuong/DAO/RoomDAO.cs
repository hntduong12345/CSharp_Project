using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class RoomDAO
    {
        private readonly Equipments2024DBContext _dbContext = null;
        private static RoomDAO instance = null;
        public static RoomDAO Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new RoomDAO();
                }
                return instance;
            }
        }

        public RoomDAO()
        {
            if(_dbContext == null)
            {
                _dbContext = new Equipments2024DBContext(); 
            }
        }

        public List<Room> GetAllRooms()
        {
            return _dbContext.Rooms.ToList();
        }
    }
}
