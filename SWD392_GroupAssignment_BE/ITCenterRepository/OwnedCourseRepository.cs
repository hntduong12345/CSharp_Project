using ITCenterBO.DTOs.Request.OwnedCourse;
using ITCenterBO.DTOs.Response.OwnedCourse;
using ITCenterBO.Paginate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterRepository
{
    public interface IOwnedCourseRepository
    {
        public Task<IPaginate<GetOwnedCourseResponse>> GetAllOwnedCourse(int accountId, int page, int size);
        public Task CreateOwnedCourse(CreateOwnedCourseRequest createOwnedCourseRequest);
        public Task<bool> ChangeOwnedCourseStatus(int id);
    }

    public class OwnedCourseRepository : IOwnedCourseRepository
    {
        public async Task<bool> ChangeOwnedCourseStatus(int id) 
            => await ITCenterDAO.OwnedCourseDAO.Instance.ChangeOwnedCourseStatus(id);

        public async Task CreateOwnedCourse(CreateOwnedCourseRequest createOwnedCourseRequest) 
            => await ITCenterDAO.OwnedCourseDAO.Instance.CreateOwnedCourse(createOwnedCourseRequest);

        public async Task<IPaginate<GetOwnedCourseResponse>> GetAllOwnedCourse(int accountId, int page, int size)
            => await ITCenterDAO.OwnedCourseDAO.Instance.GetOwnedCourse(accountId, page, size);
    }
}
