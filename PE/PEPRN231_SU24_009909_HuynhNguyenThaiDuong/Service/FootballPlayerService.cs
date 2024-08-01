using BO.DTOs;
using BO.Models;
using Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class FootballPlayerService : IFootballPlayerService
    {
        private readonly IFootballPlayerRepo _footballPlayerRepo;
        public FootballPlayerService(IFootballPlayerRepo footballPlayerRepo)
        {
            _footballPlayerRepo = footballPlayerRepo;
        }

        public async Task<ResultData> Create(FootballPlayerDTO player)
        {
            return await _footballPlayerRepo.Create(player);
        }

        public async Task<ResultData> Delete(string id)
        {
            return await _footballPlayerRepo.Delete(id);
        }

        public async Task<List<FootballPlayer>> GetAll()
        {
            return await _footballPlayerRepo.GetAll();
        }

        public async Task<FootballPlayer> GetById(string id)
        {
            return await _footballPlayerRepo.GetById(id);
        }

        public async Task<List<FootballPlayer>> Search(string achive, string nomination)
        {
            return await _footballPlayerRepo.Search(achive, nomination);
        }

        public async Task<ResultData> Update(string id, UpdateFootballPlayerDTO player)
        {
            return await _footballPlayerRepo.Update(id, player);
        }
    }
}
