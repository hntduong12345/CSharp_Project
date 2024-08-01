using BO.DTOs;
using BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public interface IFootballPlayerRepo
    {
        public Task<List<FootballPlayer>> GetAll();
        public Task<FootballPlayer> GetById(string id);
        public Task<ResultData> Delete(string id);
        public Task<ResultData> Create(FootballPlayerDTO player);
        public Task<ResultData> Update(string id, UpdateFootballPlayerDTO player);
        public Task<List<FootballPlayer>> Search(string achive, string nomination);
    }
}
