using ITCenterBO.DTOs.Request.LearnerAssignment;
using ITCenterBO.DTOs.Response.LearnerAssignment;
using ITCenterDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterRepository
{
    public interface ILearnerAssignmentRepository
    {
        void CreateLeanerAssignment(CreateLearnerAssignmentRequest request);
        Task<UpdateLearnerAssignmentResponse> UpdateLearnerAssignment(UpdateLearnerAssignmentRequest request);
        Task<GetLearnerAssignmentResponse> GetLearnerAssignment(int learnerAssignmentId);
    }

    public class LearnerAssignmentRepository : ILearnerAssignmentRepository
    {
        public async void CreateLeanerAssignment(CreateLearnerAssignmentRequest request)
        {
            LearnerAssignmentDAO.Instance.CreateLearnerAssignment(request);
        }

        public async Task<GetLearnerAssignmentResponse> GetLearnerAssignment(int learnerAssignmentId)
        {
            return await LearnerAssignmentDAO.Instance.GetLearnerAssignment(learnerAssignmentId);
        }

        public async Task<UpdateLearnerAssignmentResponse> UpdateLearnerAssignment(UpdateLearnerAssignmentRequest request)
        {
            return await LearnerAssignmentDAO.Instance.UpdateLearnerAssignment(request);
        }
    }
}
