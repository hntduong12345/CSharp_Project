using ITCenterBO.DTOs.Request.LearnerAssignment;
using ITCenterBO.DTOs.Response.LearnerAssignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterRepository
{
    public interface ILearnerAssignmentService
    {
        void CreateLeanerAssignment(CreateLearnerAssignmentRequest request);
        Task<UpdateLearnerAssignmentResponse> UpdateLearnerAssignment(UpdateLearnerAssignmentRequest request);
        Task<GetLearnerAssignmentResponse> GetLearnerAssignment(int learnerAssignmentId);

    }

    public class LearnerAssignmentService : ILearnerAssignmentService
    {
        private readonly ILearnerAssignmentRepository _learnerAssignmentRepository;
        public LearnerAssignmentService()
        {
            if (_learnerAssignmentRepository == null)
            {
                _learnerAssignmentRepository = new LearnerAssignmentRepository();
            }
        }
        public void CreateLeanerAssignment(CreateLearnerAssignmentRequest request)
        {
            _learnerAssignmentRepository.CreateLeanerAssignment(request);
        }

        public async Task<GetLearnerAssignmentResponse> GetLearnerAssignment(int learnerAssignmentId)
        {
            return await _learnerAssignmentRepository.GetLearnerAssignment(learnerAssignmentId);
        }

        public async Task<UpdateLearnerAssignmentResponse> UpdateLearnerAssignment(UpdateLearnerAssignmentRequest request)
        {
            return await _learnerAssignmentRepository.UpdateLearnerAssignment(request);
        }
    }
}
