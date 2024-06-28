using ITCenterBO.DTOs.Request.Lesson;
using ITCenterBO.DTOs.Response.Lesson;
using ITCenterBO.Paginate;
using ITCenterRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterService
{
    public interface ILessonService
    {
        public Task<List<GetLessonResponse>> GetAllLessonsOfCourse(int courseId);
        public Task CreateLesson(CreateLessonRequest createLessonRequest);
        public Task<UpdateLessonResponse> UpdateLessonInformation(int id, UpdateLessonRequest updateLessonRequest);
        public Task<bool> DeleteLesson(int id);
    }
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;

        public LessonService()
        {
            if (_lessonRepository == null)
                _lessonRepository = new LessonRepository();
        }

        public async Task CreateLesson(CreateLessonRequest createLessonRequest) => await _lessonRepository.CreateLesson(createLessonRequest);

        public async Task<bool> DeleteLesson(int id) => await _lessonRepository.DeleteLesson(id);

        public async Task<List<GetLessonResponse>> GetAllLessonsOfCourse(int courseId) => await _lessonRepository.GetAllLessonsOfCourse(courseId);

        public async Task<UpdateLessonResponse> UpdateLessonInformation(int id, UpdateLessonRequest updateLessonRequest) => await _lessonRepository.UpdateLessonInformation(id, updateLessonRequest);
    }
}
