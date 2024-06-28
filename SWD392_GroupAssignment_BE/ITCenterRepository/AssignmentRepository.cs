using ITCenterBO.DTOs.Request.Assignment;
using ITCenterBO.DTOs.Response.Account;
using ITCenterBO.DTOs.Response.Assignment;
using ITCenterBO.Models;
using ITCenterDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterRepository
{
    public interface IAssignmentRepository
    {
        void CreateAssignment(CreateAssignmentRequest request);
        Task<UpdateAssignmentResponse> UpdateAssignment(UpdateAssignmentRequest request);
        Task<IList<GetAssignmentResponse>> GetAssignmentsInCourse(int courseId);
        Task<GetAssignmentResponse> GetAssignmentById(int assignmentId);
    }

    public class AssignmentRepository : IAssignmentRepository
    {
        public void CreateAssignment(CreateAssignmentRequest request)
        {
            AssignmentDAO.Instance.CreateAssignment(request);
        }

        public async Task<GetAssignmentResponse> GetAssignmentById(int assignmentId)
        {
            return await AssignmentDAO.Instance.GetAssignmentById(assignmentId);
        }

        public Task<IList<GetAssignmentResponse>> GetAssignmentsInCourse(int courseId)
        {
            return AssignmentDAO.Instance.GetAssignmentsInCourse(courseId);
        }

        public async Task<UpdateAssignmentResponse> UpdateAssignment(UpdateAssignmentRequest request)
        {
            return await AssignmentDAO.Instance.UpdateAssignment(request);
        }
    }
}
