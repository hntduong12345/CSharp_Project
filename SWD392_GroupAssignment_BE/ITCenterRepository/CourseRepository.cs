using ITCenterBO.DTOs.Request.Course;
using ITCenterBO.DTOs.Response.Course;
using ITCenterBO.Models;
using ITCenterBO.Paginate;
using ITCenterDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterRepository
{
    public interface ICourseRepository
    {
        public Task<IPaginate<GetCourseResponse>> GetAllCourses(int page, int size);
        public Task CreateCourse(CreateCourseRequest createCourseRequest);
        public Task<UpdateCourseResponse> UpdateCourseInformation(int id, UpdateCourseRequest updateCourseRequest);
        public Task<bool> ChangeCourseStatus(int id);
        public Task<GetCourseResponse> GetCourseById(int courseId);
        public Task<IPaginate<Course>> GetCoursesByCategoryName(string categoryName, int page, int size);
    }
    public class CourseRepository : ICourseRepository
    {
        public async Task<IPaginate<GetCourseResponse>> GetAllCourses(int page, int size) => await CourseDAO.Instance.GetAllCourses(page, size);

        public async Task CreateCourse(CreateCourseRequest createCourseRequest) => await CourseDAO.Instance.CreateCourse(createCourseRequest);

        public async Task<UpdateCourseResponse> UpdateCourseInformation(int id, UpdateCourseRequest updateCourseRequest) => await CourseDAO.Instance.UpdateCourseInformation(id, updateCourseRequest);

        public async Task<bool> ChangeCourseStatus(int id) => await CourseDAO.Instance.ChangeCourseStatus(id);

        public async Task<GetCourseResponse> GetCourseById(int courseId) => await CourseDAO.Instance.GetCourseById(courseId);

        public async Task<IPaginate<Course>> GetCoursesByCategoryName(string categoryName, int page, int size) 
            => await CourseDAO.Instance.GetCoursesByCategoryName(categoryName, page, size);
    }
}
