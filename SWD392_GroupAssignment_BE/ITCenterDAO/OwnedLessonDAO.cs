using AutoMapper;
using ITCenterBO.DTOs.Request.OwnedLesson;
using ITCenterBO.DTOs.Response.OwnedCourse;
using ITCenterBO.DTOs.Response.OwnedLesson;
using ITCenterBO.Models;
using ITCenterBO.Paginate;
using ITCenterDAO.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterDAO
{
    public class OwnedLessonDAO
    {
        private readonly ITCenterContext _dbContext = null;
        private readonly IMapper _mapper = null;

        private static OwnedLessonDAO instance;
        public static OwnedLessonDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OwnedLessonDAO();
                }
                return instance;
            }
        }

        public OwnedLessonDAO()
        {
            if (_dbContext == null)
                _dbContext = new ITCenterContext();
            if (_mapper == null)
                _mapper = new Mapper(new MapperConfiguration(mc => mc.AddProfile(new OwnedLessonMapper())).CreateMapper().ConfigurationProvider);
        }

        public async Task CreateOwnedLesson(CreateOwnedLessonRequest newOwnedLesson)
        {
            _dbContext.OwnedLessons.Add(_mapper.Map<OwnedLesson>(newOwnedLesson));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IPaginate<GetOwnedLessonResponse>> GetOwnedLesson(int accountId, int page, int size)
        {
            IPaginate<GetOwnedLessonResponse> ownedLessonList = await _dbContext.OwnedLessons.Select(x => new GetOwnedLessonResponse
            {
                OwnedLessonId = x.OwnedLessonId,
                LessonId = x.LessonId,
                AccountId = x.AccountId,
                IsFinished = x.IsFinished,
                FinishedDate = (DateTime)x.FinishedDate
            }).Where(x => x.AccountId == accountId).ToPaginateAsync(page, size, 1);
            return ownedLessonList;
        }

        public async Task<bool> ChangeOwnedLessonStatus(int ownedLessonId)
        {
            var ownedLesson = await _dbContext.OwnedLessons.FindAsync(ownedLessonId);
            if (ownedLesson != null)
            {
                ownedLesson.IsFinished = true;
                ownedLesson.FinishedDate = DateTime.Now;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<GetOwnedLessonResponse>> GetOwnedLessonsList(int accountId)
        {
            List<GetOwnedLessonResponse> list = await _dbContext.OwnedLessons.Select(x => new GetOwnedLessonResponse
            {
                OwnedLessonId = x.OwnedLessonId,
                LessonId = x.LessonId,
                AccountId = x.AccountId,
                IsFinished = x.IsFinished,
                FinishedDate = (DateTime)x.FinishedDate
            }).Where(x => x.AccountId == accountId).ToListAsync();
            return list;
        }
    }
}
