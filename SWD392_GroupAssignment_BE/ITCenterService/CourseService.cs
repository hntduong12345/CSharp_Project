using ITCenterBO.DTOs.Request.Course;
using ITCenterBO.DTOs.Response.Account;
using ITCenterBO.DTOs.Response.Course;
using ITCenterBO.Models;
using ITCenterBO.Paginate;
using ITCenterDAO;
using ITCenterRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterService
{
    public interface ICourseService
    {
        public Task<IPaginate<GetCourseResponse>> GetAllACourses(int page, int size);
        public Task CreateCourse(CreateCourseRequest createCourseRequest);
        public Task<UpdateCourseResponse> UpdateCourseInformation(int id, UpdateCourseRequest updateCourseRequest);
        public Task<bool> ChangeCourseStatus(int id);
        public Task<GetCourseResponse> GetCourseById(int courseId);
        public Task<IPaginate<Course>> GetCoursesByCategoryName(string categoryName, int page, int size);
    }

    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService()
        {
            if (_courseRepository == null)
                _courseRepository = new CourseRepository();
        }
        public async Task<bool> ChangeCourseStatus(int id) => await _courseRepository.ChangeCourseStatus(id);

        public async Task CreateCourse(CreateCourseRequest createCourseRequest) => await _courseRepository.CreateCourse(createCourseRequest);

        public async Task<IPaginate<GetCourseResponse>> GetAllACourses(int page, int size) => await _courseRepository.GetAllCourses(page, size);

        public async Task<UpdateCourseResponse> UpdateCourseInformation(int id, UpdateCourseRequest updateCourseRequest) => await _courseRepository.UpdateCourseInformation(id, updateCourseRequest);

        public async Task<GetCourseResponse> GetCourseById(int courseId) => await _courseRepository.GetCourseById(courseId);

        public async Task<IPaginate<Course>> GetCoursesByCategoryName(string categoryName, int page, int size)
            => await _courseRepository.GetCoursesByCategoryName(categoryName, page, size);
    }
}
