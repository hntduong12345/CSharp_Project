using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public interface IRoomRepo
    {
        public List<Room> GetAllRooms();
    }
}
