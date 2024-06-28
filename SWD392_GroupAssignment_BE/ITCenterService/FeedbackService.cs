using ITCenterBO.DTOs.Request.Feedback;
using ITCenterBO.Models;
using ITCenterBO.Paginate;
using ITCenterRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterService
{
    public interface IFeedbackService
    {
        public void CreateFeedBack(CreateFeedbackRequest request);
        public Task<IPaginate<Feedback>> GetAllFeedbacks(int page, int size);
        public Task<bool> ChangeStatus(int feedbackId);
    }

    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository = null;

        public FeedbackService()
        {
            if (_feedbackRepository == null)
                _feedbackRepository = new FeedbackRepository();
        }

        public async void CreateFeedBack(CreateFeedbackRequest request) => _feedbackRepository.CreateFeedBack(request);
        public async Task<IPaginate<Feedback>> GetAllFeedbacks(int page, int size) => await _feedbackRepository.GetAllFeedbacks(page, size);
        public async Task<bool> ChangeStatus(int feedbackId) => await _feedbackRepository.ChangeStatus(feedbackId);
    }
}
