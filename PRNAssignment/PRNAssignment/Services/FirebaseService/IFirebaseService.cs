using PRNAssignment.Models;

namespace PRNAssignment.Services.FirebaseService
{
    public interface IFirebaseService
    {
        void CreateConnection();

        Task<List<Locker>> GetAvailableLocker();

        Task<string> UploadData(Locker locker);
    }
}
