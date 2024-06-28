using ITCenterBO.DTOs.Request.Assignment;
using ITCenterBO.DTOs.Response.Account;
using ITCenterBO.DTOs.Response.Assignment;
using ITCenterBO.Models;
using ITCenterRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterService
{
    public interface IAssignmentService
    {
        void CreateAssignment(CreateAssignmentRequest request);
        Task<UpdateAssignmentResponse> UpdateAssignment(UpdateAssignmentRequest request);
        Task<IList<GetAssignmentResponse>> GetAssignmentsInCourse(int courseId);
        Task<GetAssignmentResponse> GetAssignmentById(int assignmentId);
    }

    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;
        public AssignmentService()
        {
            if(_assignmentRepository == null) { 
                _assignmentRepository = new AssignmentRepository();
            }
        }
        public async void CreateAssignment(CreateAssignmentRequest request)
        {
            _assignmentRepository.CreateAssignment(request);
        }

        public async Task<GetAssignmentResponse> GetAssignmentById(int assignmentId)
        {
            return await _assignmentRepository.GetAssignmentById(assignmentId);
        }

        public async Task<IList<GetAssignmentResponse>> GetAssignmentsInCourse(int courseId)
        {
            return await _assignmentRepository.GetAssignmentsInCourse(courseId);
        }

        public async Task<UpdateAssignmentResponse> UpdateAssignment(UpdateAssignmentRequest request)
        {
            return await _assignmentRepository.UpdateAssignment(request);
        }
    }
}
