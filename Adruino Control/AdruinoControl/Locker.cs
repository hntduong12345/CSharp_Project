using System.IO.Ports;

using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

using Firebase.Database;
using Firebase.Database.Query;
using AdruinoControl.Models;

namespace AdruinoControl
{
    public partial class Locker : Form
    {
        List<Button> buttonList = new List<Button>();
        List<int> buttonState = new List<int>();
        private int internalCounter = 0, counter, counter1, counter2;
        Button activeLocker1, activeLocker2;

        SerialPort serialPort = new SerialPort("COM3", 9600);

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;

        FirebaseClient firebaseClient;
        String FirebaseDatabaseurl = "https://remoted-locker-default-rtdb.asia-southeast1.firebasedatabase.app/";
        String databaseSecret = "M5BJzNkHyVn4TIvOECUTFjfCKVxS1Wc84QZRoDhw";

        public Locker()
        {
            InitializeComponent();
            firebaseClient = new FirebaseClient(FirebaseDatabaseurl, new FirebaseOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(databaseSecret)
            });
            try { serialPort.Open(); }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            getButtons();
        }

        private void Locker_Load(object sender, EventArgs e)
        {
            if (firebaseClient != null)
            {
                MessageBox.Show("Firebase is connected!");
            }
            else
            {
                MessageBox.Show("Firebase is not connected!");
            }

            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[2].MonikerString);
            videoCaptureDevice.Start();
        }
        private void getButtons()
        {
            //button1
            buttonList.Add(button1);
            buttonState.Add(0);
            button1.Enabled = false;
            button1.BackColor = getColor(buttonState.ElementAt(0));
            //button2
            buttonList.Add(button2);
            buttonState.Add(0);
            button2.Enabled = false;
            button2.BackColor = getColor(buttonState.ElementAt(1));
            //button3
            buttonList.Add(button3);
            buttonState.Add(0);
            button3.Enabled = false;
            button3.BackColor = getColor(buttonState.ElementAt(2));
            //button4
            buttonList.Add(button4);
            buttonState.Add(0);
            button4.Enabled = false;
            button4.BackColor = getColor(buttonState.ElementAt(3));
            //button5
            buttonList.Add(button5);
            buttonState.Add(0);
            button5.Enabled = false;
            button5.BackColor = getColor(buttonState.ElementAt(4));
            //button6
            buttonList.Add(button6);
            buttonState.Add(0);
            button6.Enabled = false;
            button6.BackColor = getColor(buttonState.ElementAt(5));
            //button7
            buttonList.Add(button7);
            buttonState.Add(0);
            button7.Enabled = false;
            button7.BackColor = getColor(buttonState.ElementAt(6));
            //button8
            buttonList.Add(button8);
            buttonState.Add(0);
            button8.Enabled = false;
            button8.BackColor = getColor(buttonState.ElementAt(7));
            //button9
            buttonList.Add(button9);
            buttonState.Add(0);
            button9.Enabled = false;
            button9.BackColor = getColor(buttonState.ElementAt(8));
            //button10
            buttonList.Add(button10);
            buttonState.Add(0);
            button10.Enabled = false;
            button10.BackColor = getColor(buttonState.ElementAt(9));
            //button11
            buttonList.Add(button11);
            buttonState.Add(0);
            button11.Enabled = false;
            button11.BackColor = getColor(buttonState.ElementAt(10));
            //button12
            buttonList.Add(button12);
            buttonState.Add(0);
            button12.Enabled = false;
            button12.BackColor = getColor(buttonState.ElementAt(11));
        }
        private Color getColor(int state)
        {
            if (state == 0)
            {
                return Color.Cornsilk;
            }
            else if (state == 1)
            {
                return Color.LightSteelBlue;
            }
            else
            {
                return Color.White;
            }
        }

        private void videoCaptureDevice_newFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }
        private void buttonQRScan_Click(object sender, EventArgs e)
        {
            pictureBox1.Show();
            videoCaptureDevice.NewFrame += videoCaptureDevice_newFrame;
            counter = 15;
            buttonQRScan.Enabled = false;
            labelMess.Text = "Time out in " + counter + "s";
            timer1.Start();
        }
        private void Locker_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((videoCaptureDevice != null) && (videoCaptureDevice.IsRunning))
            {
                videoCaptureDevice.SignalToStop();
            }
        }
        //Signal is like "ButtonNumberToken"
        private async void readSignal(string QRCode)
        {

            try
            {
                int activeLockerNumber = Int32.Parse(QRCode.Substring(1, 2));
                //string token = QRCode.Substring(3);
                bool check = true; //condition for token, but at first nothing to check
                                   //firebase
                                   //code check token to make sure QR code valid
                                   //setData
                var lockers = await firebaseClient.Child("").OrderByKey().OnceAsync<LockerModel>();

                lockers.Select(x => new KeyValuePair<string, LockerModel>(x.Key, x.Object)).ToList();

                check = lockers.ElementAt(activeLockerNumber - 1).Object.Status;

                if (check)
                {
                    serialPort.Write(QRCode.Substring(1, 2) + "-UNLOCK");
                    updateActiveLocker(activeLockerNumber);
                    pictureBox1.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid QR Code");
                    pictureBox1.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void updateActiveLocker(int activeLockerNumber)
        {
            if (activeLocker1 == null)
            {
                activeLocker1 = buttonList.ElementAt(activeLockerNumber - 1);
                activeLocker1.BackColor = Color.LightSteelBlue;
                counter1 = 0;
                timer2.Start();
            }
            else if ((activeLocker2 == null))
            {
                activeLocker2 = buttonList.ElementAt(activeLockerNumber - 1);
                activeLocker2.BackColor = Color.LightSteelBlue;
                counter2 = 0;
                timer3.Start();
            }
            else
            {
                if (counter1 > counter2)
                {
                    activeLocker1.BackColor = Color.Cornsilk;
                    activeLocker1 = buttonList.ElementAt(activeLockerNumber - 1);
                    activeLocker1.BackColor = Color.LightSteelBlue;
                    counter1 = 0;
                    timer2.Start();
                }
                else
                {
                    activeLocker2.BackColor = Color.Cornsilk;
                    activeLocker2 = buttonList.ElementAt(activeLockerNumber - 1);
                    activeLocker2.BackColor = Color.LightSteelBlue;
                    counter2 = 0;
                    timer3.Start();
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            internalCounter++;
            if (internalCounter == 10)
            {
                internalCounter = 0;
                counter--;
            }
            labelMess.Text = "Time out in " + counter + "s";
            if (pictureBox1 != null)
            {
                var reader = new BarcodeReaderGeneric();
                Bitmap image = (Bitmap)pictureBox1.Image;
                LuminanceSource luminanceSource = new ZXing.Windows.Compatibility.BitmapLuminanceSource(image);
                Result res = reader.Decode(luminanceSource);
                if (res != null)
                {
                    timer1.Stop();
                    labelMess.Text = "please check locker number " + res.ToString().Substring(1, 2);
                    readSignal(res.ToString());
                    buttonQRScan.Enabled = true;
                }
                else if (counter == 0)
                {
                    timer1.Stop();
                    labelMess.Text = "Time out! please try again";
                    buttonQRScan.Enabled = true;
                    pictureBox1.Hide();
                }
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            counter1++;
            if (counter1 == 3)
            {
                activeLocker1.BackColor = Color.Cornsilk;
                timer2.Stop();
            }
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            counter2++;
            if (counter2 == 3)
            {
                activeLocker2.BackColor = Color.Cornsilk;
                timer3.Stop();
            }
        }
    }
}
