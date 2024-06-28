using Firebase.Database;
using Firebase.Database.Query;

namespace AutoLocker
{
    public partial class Form1 : Form
    {
        private const String FirebaseDatabaseurl = "https://remoted-locker-default-rtdb.asia-southeast1.firebasedatabase.app/";
        private const String databaseSecret = "M5BJzNkHyVn4TIvOECUTFjfCKVxS1Wc84QZRoDhw";

        private FirebaseClient firebaseClient;

        public Form1()
        {
            InitializeComponent();
            //Firebase config setup
            CreateConnection();
            RetrieveData();
        }

        private void CreateConnection()
        {
            firebaseClient = new FirebaseClient(FirebaseDatabaseurl,
                new FirebaseOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(databaseSecret)
                });
        }

        private async void RetrieveData()
        {
            var data = await firebaseClient.Child("Status").OnceAsync<Boolean>();
            foreach (var item in data)
            {
                switch (item.Key)
                {
                    case "L1":
                        button1.Text = item.Object.ToString();
                        break;
                    case "L2":
                        button2.Text = item.Object.ToString();
                        break;
                    case "L3":
                        button3.Text = item.Object.ToString();
                        break;
                    case "L4":
                        button4.Text = item.Object.ToString();
                        break;
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await firebaseClient.Child("Status").Child("L1").PutAsync<Boolean>(!bool.Parse(button1.Text));
            RetrieveData();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await firebaseClient.Child("Status").Child("L2").PutAsync<Boolean>(!bool.Parse(button2.Text));
            RetrieveData();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await firebaseClient.Child("Status").Child("L3").PutAsync<Boolean>(!bool.Parse(button3.Text));
            RetrieveData();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            await firebaseClient.Child("Status").Child("L4").PutAsync<Boolean>(!bool.Parse(button4.Text));
            RetrieveData();
        }
    }
}