using Firebase.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCenterService
{
    public interface IFileService
    {
        public Task<string> UploadFile(Stream fileStream, string fileName);
    }

    public class FileService : IFileService
    {
        private readonly IFirebaseService _firebaseService;
        public FileService()
        {
            if(_firebaseService == null)
                _firebaseService = new FirebaseService();
        }

        public async Task<string> UploadFile(Stream fileStream, string fileName) 
            => await _firebaseService.UploadFile(fileStream, fileName);
    }
}
