using Firebase.Database;
using Firebase.Database.Query;
using PRNAssignment.Models;

namespace PRNAssignment.Services.FirebaseService
{
    public class FirebaseService : IFirebaseService
    {
        private const string FirebaseDatabaseUrl = "https://remoted-locker-default-rtdb.asia-southeast1.firebasedatabase.app/";
        private const string databaseSecret = "M5BJzNkHyVn4TIvOECUTFjfCKVxS1Wc84QZRoDhw";

        private FirebaseClient client;

        public void CreateConnection()
        {
            client = new FirebaseClient(FirebaseDatabaseUrl, 
                new FirebaseOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(databaseSecret)
                });
        }


        public async Task<List<Locker>> GetAvailableLocker()
        {
            try
            {
                List<Locker> lockers = new List<Locker>();
                var data = await client.Child("").OnceAsync<Locker>();
                foreach(var item in data)
                { 
                        lockers.Add(item.Object);  
                }
                return lockers.OrderBy(l => l.Id).ToList();
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return null;
            }
        }

        public async Task<string> UploadData(Locker locker)
        {
            try
            {
                await client.Child("").Child(locker.Name).PutAsync<Locker>(locker);
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
