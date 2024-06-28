using ITCenterBO.DTOs.Request.OwnedLesson;
using ITCenterBO.DTOs.Response.OwnedLesson;
using ITCenterBO.Paginate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterRepository
{
    public interface IOwnedLessonRepository
    {
        public Task<IPaginate<GetOwnedLessonResponse>> GetOwnedLessons(int accountId, int page, int size);
        public Task CreateOwnedLesson(CreateOwnedLessonRequest newOwnedLesson);
        public Task<bool> ChangeOwnedLessonStatus(int id);
        public Task<List<GetOwnedLessonResponse>> GetOwnedLessonsList(int accountId);
    }

    public class OwnedLessonRepository : IOwnedLessonRepository
    {
        public async Task<bool> ChangeOwnedLessonStatus(int id)
            => await ITCenterDAO.OwnedLessonDAO.Instance.ChangeOwnedLessonStatus(id);

        public async Task CreateOwnedLesson(CreateOwnedLessonRequest newOwnedLesson)
            => await ITCenterDAO.OwnedLessonDAO.Instance.CreateOwnedLesson(newOwnedLesson);

        public async Task<IPaginate<GetOwnedLessonResponse>> GetOwnedLessons(int accountId, int page, int size)
            => await ITCenterDAO.OwnedLessonDAO.Instance.GetOwnedLesson(accountId, page, size);

        public async Task<List<GetOwnedLessonResponse>> GetOwnedLessonsList(int accountId) => await ITCenterDAO.OwnedLessonDAO.Instance.GetOwnedLessonsList(accountId);
    }
}
