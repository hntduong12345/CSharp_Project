using Firebase.Database;
using System.IO.Ports;

namespace LockerAction
{
    public partial class Form1 : Form
    {
        private SerialPort se = new SerialPort("COM3", 9600);

        private const String FirebaseDatabaseurl = "https://remoted-locker-default-rtdb.asia-southeast1.firebasedatabase.app/";
        private const String databaseSecret = "M5BJzNkHyVn4TIvOECUTFjfCKVxS1Wc84QZRoDhw";

        private FirebaseClient firebaseClient;

        public Form1()
        {
            InitializeComponent();
            CreateConnection();
            se.Open();
            Exercute();
        }

        private void CreateConnection()
        {
            firebaseClient = new FirebaseClient(FirebaseDatabaseurl,
                new FirebaseOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(databaseSecret)
                });
        }

        private async void Exercute()
        {
            while (true)
            {
                var data = await firebaseClient.Child("Status").OnceAsync<Boolean>();
                foreach (var item in data)
                {
                    switch (item.Key)
                    {
                        case "L1":
                            textBox1.Text = item.Object.ToString();
                            se.Write("02-" + (item.Object ? "A" : "a"));
                            break;
                        case "L2":
                            textBox2.Text = item.Object.ToString();
                            se.Write("03-" + (item.Object ? "A" : "a"));
                            break;
                        case "L3":
                            textBox3.Text = item.Object.ToString();
                            se.Write("04-" + (item.Object ? "A" : "a"));
                            break;
                        case "L4":
                            textBox4.Text = item.Object.ToString();
                            se.Write("05-" + (item.Object ? "A" : "a"));
                            break;
                    }
                }
                await Task.Delay(1000);
            }
        }
    }
}