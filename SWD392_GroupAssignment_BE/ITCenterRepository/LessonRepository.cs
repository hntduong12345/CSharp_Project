using ITCenterBO.DTOs.Request.Lesson;
using ITCenterBO.DTOs.Response.Lesson;
using ITCenterBO.Paginate;
using ITCenterDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterRepository
{
    public interface ILessonRepository
    {
        public Task<List<GetLessonResponse>> GetAllLessonsOfCourse(int courseId);
        public Task<List<GetLessonResponse>> GetListLessonOfCourse(int courseId);
        public Task CreateLesson(CreateLessonRequest createLessonRequest);
        public Task<UpdateLessonResponse> UpdateLessonInformation(int id, UpdateLessonRequest updateLessonRequest);
        public Task<bool> DeleteLesson(int id);
    }

    public class LessonRepository : ILessonRepository
    {
        public async Task CreateLesson(CreateLessonRequest createLessonRequest)
            => await LessonDAO.Instance.CreateLesson(createLessonRequest);

        public async Task<bool> DeleteLesson(int id)
            => await LessonDAO.Instance.DeleteLesson(id);

        public async Task<List<GetLessonResponse>> GetAllLessonsOfCourse(int courseId)
            => await LessonDAO.Instance.GetAllLessonsOfCourse(courseId);

        public async Task<List<GetLessonResponse>> GetListLessonOfCourse(int courseId) => await LessonDAO.Instance.GetListLessonOfCourse(courseId);

        public async Task<UpdateLessonResponse> UpdateLessonInformation(int id, UpdateLessonRequest updateLessonRequest)
            => await LessonDAO.Instance.UpdateLesson(id, updateLessonRequest);
    }
}
