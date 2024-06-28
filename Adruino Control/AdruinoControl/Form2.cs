using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using ZXing.Windows.Compatibility;

namespace AdruinoControl
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            getButtons();
        }
        List<Button> buttonList = new List<Button>();
        List<int> buttonState = new List<int>();
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[2].MonikerString);
            videoCaptureDevice.NewFrame += videoCaptureDevice_newFrame;
            videoCaptureDevice.Start();
            timer1.Start();
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
        private void comboDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void videoCaptureDevice_newFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }
        private void Form2_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if ((videoCaptureDevice != null) && (videoCaptureDevice.IsRunning))
            {
                videoCaptureDevice.SignalToStop();
                videoCaptureDevice = null;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1 != null)
            {
                BarcodeReader reader = new BarcodeReader();
                Result res = reader.Decode((Bitmap)pictureBox1.Image);
                if (res != null)
                {
                    if ((videoCaptureDevice != null) && (videoCaptureDevice.IsRunning))
                    {
                        videoCaptureDevice.SignalToStop();
                        videoCaptureDevice = null;
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }
    }
}
