using ITCenterBO.DTOs.Request.OwnedLesson;
using ITCenterBO.DTOs.Response.OwnedLesson;
using ITCenterBO.Paginate;
using ITCenterRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterService
{
    public interface IOwnedLessonService
    {
        public Task<IPaginate<GetOwnedLessonResponse>> GetOwnedLessons(int accountId, int page, int size);
        public Task CreateOwnedLesson(int courseId, int accountId);
        public Task<bool> ChangeOwnedLessonStatus(int id);
        public Task<float> GetOwnedLessonProgress(int accountId, int courseId);
    }

    public class OwnedLessonService : IOwnedLessonService
    {
        private readonly IOwnedLessonRepository _ownedLessonRepository;
        private readonly ILessonRepository _lessonRepository;

        public OwnedLessonService()
        {
            if (_ownedLessonRepository == null)
                _ownedLessonRepository = new OwnedLessonRepository();
            if (_lessonRepository == null)
                _lessonRepository = new LessonRepository();
        }

        public async Task<bool> ChangeOwnedLessonStatus(int id)
            => await _ownedLessonRepository.ChangeOwnedLessonStatus(id);

        public async Task CreateOwnedLesson(int courseId, int accountId)
        {
            var lessons = _lessonRepository.GetListLessonOfCourse(courseId).Result;
            foreach (var lesson in lessons)
            {
                var newOwnedLesson = new CreateOwnedLessonRequest
                {
                    AccountId = accountId,
                    LessonId = lesson.LessonId
                };
                await _ownedLessonRepository.CreateOwnedLesson(newOwnedLesson);
            }
        }

        public async Task<IPaginate<GetOwnedLessonResponse>> GetOwnedLessons(int accountId, int page, int size)
            => await _ownedLessonRepository.GetOwnedLessons(accountId, page, size);

        public async Task<float> GetOwnedLessonProgress(int accountId, int courseId)
        {
            var lessons = await _lessonRepository.GetListLessonOfCourse(courseId);
            List<GetOwnedLessonResponse> ownedLessons = new List<GetOwnedLessonResponse>();
            foreach (var lesson in lessons)
            {
                ownedLessons.Add(_ownedLessonRepository.GetOwnedLessonsList(accountId).Result.FirstOrDefault(x => x.LessonId == lesson.LessonId));
            }
            return (float)ownedLessons.Count(x => x.IsFinished == true) / lessons.Count() * 100;
        }
    }
}
