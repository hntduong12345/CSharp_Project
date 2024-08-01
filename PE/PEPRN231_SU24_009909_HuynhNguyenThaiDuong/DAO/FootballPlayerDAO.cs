using BO.DTOs;
using BO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class FootballPlayerDAO
    {
        private readonly EnglishPremierLeague2024DBContext _context;
        private static FootballPlayerDAO instance;
        public static FootballPlayerDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FootballPlayerDAO();
                }
                return instance;
            }
        }

        public FootballPlayerDAO()
        {
            if (_context == null)
                _context = new EnglishPremierLeague2024DBContext();
        }


        public async Task<List<FootballPlayer>> GetAll()
        {
            return await _context.FootballPlayers.Include(x => x.FootballClub).ToListAsync();
        }

        public async Task<FootballPlayer> GetById(string id)
        {
            return await _context.FootballPlayers.Include(x => x.FootballClub).FirstOrDefaultAsync(x => x.FootballPlayerId.Equals(id));
        }

        public async Task<ResultData> Delete(string id)
        {
            try
            {
                FootballPlayer paint = await _context.FootballPlayers.FirstOrDefaultAsync(x => x.FootballPlayerId.Equals(id));
                if (paint == null)
                    return new ResultData { StatusCode = -1, Message = "Cannot find player" };

                _context.FootballPlayers.Remove(paint);
                await _context.SaveChangesAsync();
                return new ResultData();
            }
            catch (Exception ex)
            {
                _context.ChangeTracker.Clear();
                return new ResultData { StatusCode = -1, Message = ex.Message };
            }
            finally
            {
                _context.ChangeTracker.Clear();
            }
        }

        public async Task<ResultData> Create(FootballPlayerDTO player)
        {
            try
            {
                FootballPlayer currentPaint = await _context.FootballPlayers.FirstOrDefaultAsync(x => x.FootballPlayerId.Equals(player.FootballPlayerId));
                if (currentPaint != null)
                    return new ResultData { StatusCode = -1, Message = "Player has already existed!" };

                FootballPlayer newPlayer = new FootballPlayer()
                {
                    FootballPlayerId = player.FootballPlayerId,
                    Nomination = player.Nomination,
                    Achievements = player.Achievements,
                    Birthday = player.Birthday,
                    FootballClubId = player.FootballClubId,
                    FullName = player.FullName,
                    PlayerExperiences = player.PlayerExperiences
                };

                _context.FootballPlayers.Add(newPlayer);
                await _context.SaveChangesAsync();
                return new ResultData();
            }
            catch (Exception ex)
            {
                _context.ChangeTracker.Clear();
                return new ResultData { StatusCode = -1, Message = ex.Message };
            }
            finally
            {
                _context.ChangeTracker.Clear();
            }
        }

        public async Task<ResultData> Update(string id, UpdateFootballPlayerDTO player)
        {
            try
            {
                FootballPlayer updatedPlayer = await _context.FootballPlayers.FirstOrDefaultAsync(x => x.FootballPlayerId.Equals(id));
                if (updatedPlayer == null)
                    return new ResultData { StatusCode = -1, Message = "Cannot find player" };

                updatedPlayer.FullName = player.FullName;
                updatedPlayer.Achievements = player.Achievements;
                updatedPlayer.Birthday = player.Birthday;
                updatedPlayer.PlayerExperiences = player.PlayerExperiences;
                updatedPlayer.Nomination = player.Nomination;
                updatedPlayer.FootballClubId = player.FootballClubId;

                _context.Update(updatedPlayer);
                await _context.SaveChangesAsync();
                return new ResultData();
            }
            catch (Exception ex)
            {
                return new ResultData { StatusCode = -1, Message = ex.Message };
            }
            finally
            {
                _context.ChangeTracker.Clear();
            }
        }

        public async Task<List<FootballPlayer>> Search(string achive, string nomination)
        {
            if (String.IsNullOrEmpty(achive))
            {
                achive = string.Empty;
            }

            if (String.IsNullOrEmpty(nomination))
            {
                nomination = string.Empty;
            }

            return await _context.FootballPlayers
                .Include(x => x.FootballClub)
                .Where(x => x.Achievements.ToLower().Contains(achive.ToLower()) ||
                            x.Nomination.ToLower().Contains(nomination.ToLower())).ToListAsync();
        }
    }
}
