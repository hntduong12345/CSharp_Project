using System.IO.Ports;
using AForge.Video;
using AForge.Video.DirectShow;
using Firebase.Database;
using ZXing;
using ZXing.Windows.Compatibility;

namespace AdruinoControl
{
    public partial class Form1 : Form
    {
        private SerialPort se = new SerialPort("COM3", 9600);
        List<Button> buttonList = new List<Button>();
        List<int> buttonState = new List<int>();
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;

        FirebaseClient firebaseClient;
        String FirebaseDatabaseurl = "https://remoted-locker-default-rtdb.asia-southeast1.firebasedatabase.app/";
        String databaseSecret = "M5BJzNkHyVn4TIvOECUTFjfCKVxS1Wc84QZRoDhw";
        public Form1()
        {
            InitializeComponent();
            firebaseClient = new FirebaseClient(FirebaseDatabaseurl);
            try { se.Open(); }
            catch (Exception ex)
            {
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (firebaseClient != null)
            {
                MessageBox.Show("Firebase is connected!");
            }
            else
            {
                MessageBox.Show("Firebase is not connected!");
            }

        }
        /*        private void button1_Click(object sender, EventArgs e)
       {
           if (lockStates[0] == 'a')
           {
               lockStates[0] = 'A';
               button1.Text = "ON";
               button1.BackColor = Color.Green;
           }
           else
           {
               lockStates[0] = 'a';
               button1.Text = "OFF";
               button1.BackColor = ColorTranslator.FromHtml("#626262");
           }
           //se.Write("02-" + lockStates[0]);
           button8.Text = "02-" + lockStates[0];
       }*/
    }
}