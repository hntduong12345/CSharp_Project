using System.Diagnostics;

namespace PRN211_windows_layout
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            timer1.Start();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void changeImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clock.Text = DateTime.UtcNow.ToString("HH:mm:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", "https://fap.fpt.edu.vn/");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("\"C:\\Users\\M S I\\AppData\\Local\\Programs\\Zalo\\Zalo.exe\"");
        }
    }
}