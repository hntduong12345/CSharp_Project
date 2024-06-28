using Firebase.Auth;
using Firebase.Storage;

namespace TestAPI.Services.FileService
{
    public class FileService : IFileService
    {
        private static string ApiKey = "AIzaSyAsOi1XxqN2vEqEjhoN4WPI8ufK2sEX4IM";
        private static string Bucket = "boardgameshopstorage.appspot.com";
        private static string AuthEmail = "hntduong2003@gmail.com";
        private static string AuthPassword = "Hntduong12345";

        public async void Upload(Stream stream, string fileName)
        {
            var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
            //var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);
            var a = await auth.SignInAnonymouslyAsync();

            var cancellation = new CancellationTokenSource();

            var task = new FirebaseStorage(Bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    ThrowOnCancel = true
                });

            var temp = task;

            try
            {
                string link = await task.Child("images").Child(fileName).PutAsync(stream, cancellation.Token);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
