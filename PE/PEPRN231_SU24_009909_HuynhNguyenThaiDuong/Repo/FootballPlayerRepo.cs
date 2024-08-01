using BO.DTOs;
using BO.Models;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class FootballPlayerRepo : IFootballPlayerRepo
    {
        public async Task<List<FootballPlayer>> GetAll() => await FootballPlayerDAO.Instance.GetAll();
        public async Task<FootballPlayer> GetById(string id) => await FootballPlayerDAO.Instance.GetById(id);
        public async Task<ResultData> Delete(string id) => await FootballPlayerDAO.Instance.Delete(id);
        public async Task<ResultData> Create(FootballPlayerDTO player) => await FootballPlayerDAO.Instance.Create(player);
        public async Task<ResultData> Update(string id, UpdateFootballPlayerDTO player) => await FootballPlayerDAO.Instance.Update(id, player);
        public async Task<List<FootballPlayer>> Search(string achive, string nomination) => await FootballPlayerDAO.Instance.Search(achive, nomination);
    }
}
