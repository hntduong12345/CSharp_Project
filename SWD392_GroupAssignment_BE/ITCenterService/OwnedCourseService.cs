using ITCenterBO.DTOs.Request.OwnedCourse;
using ITCenterBO.DTOs.Response.OwnedCourse;
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
    public interface IOwnedCourseService
    {
        public Task<IPaginate<GetOwnedCourseResponse>> GetOwnedCourse(int accountId, int page, int size);
        public Task CreateOwnedCourse(CreateOwnedCourseRequest createOwnedCourseRequest);
        public Task<bool> ChangeOwnedCourseStatus(int id);
    }

    public class OwnedCourseService : IOwnedCourseService
    {
        private readonly IOwnedCourseRepository _ownedCourseRepository;
        public OwnedCourseService()
        {
            if (_ownedCourseRepository == null)
                _ownedCourseRepository = new OwnedCourseRepository();
        }

        public async Task<bool> ChangeOwnedCourseStatus(int id) => await _ownedCourseRepository.ChangeOwnedCourseStatus(id);

        public async Task CreateOwnedCourse(CreateOwnedCourseRequest createOwnedCourseRequest) => await _ownedCourseRepository.CreateOwnedCourse(createOwnedCourseRequest);

        public async Task<IPaginate<GetOwnedCourseResponse>> GetOwnedCourse(int accountId, int page, int size) => await _ownedCourseRepository.GetAllOwnedCourse(accountId, page, size);
    }
}
