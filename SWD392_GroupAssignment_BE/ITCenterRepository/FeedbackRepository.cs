using ITCenterBO.DTOs.Request.Feedback;
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
    public interface IFeedbackRepository
    {
        public void CreateFeedBack(CreateFeedbackRequest request);
        public Task<IPaginate<Feedback>> GetAllFeedbacks(int page, int size);
        public Task<bool> ChangeStatus(int feedbackId);
    }


    public class FeedbackRepository : IFeedbackRepository
    {
        public async void CreateFeedBack(CreateFeedbackRequest request) => FeedbackDAO.Instance.CreateFeedBack(request);
        public async Task<IPaginate<Feedback>> GetAllFeedbacks(int page, int size) => await FeedbackDAO.Instance.GetAllFeedbacks(page, size);
        public async Task<bool> ChangeStatus(int feedbackId) => await FeedbackDAO.Instance.ChangeStatus(feedbackId);
    }
}
