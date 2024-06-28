using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DestopApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Checking gender
            string gender = string.Empty;
            if (rbtnMale.Checked)
            {
                gender = rbtnMale.Text;
            }
            else if (rbtnFemale.Checked)
            {
                gender = rbtnFemale.Text;
            }
            else if (rbtnOther.Checked)
            {
                gender = rbtnOther.Text;
            }
            else
            {
                MessageBox.Show("Please Choose Your Gender!", "Warning");
                return;
            }

            //Check format of email
            string pattern = @"([^\s.]+)@fpt.edu.vn";
            Regex regex = new Regex(pattern);

            if (!regex.IsMatch(txtEmail.Text))
            {
                MessageBox.Show("Wrong Email Format!", "Warning");
                return;
            }




            MessageBox.Show(
$@"{"Full Name:",-17} {txtFulName.Text}
{"Gender:",-18} {gender}
{"Date Of Birth:",-16} {birthday.Text}
{"Email:",-20} {txtEmail.Text}
{"Semester:",-17} {numSemester.Text}
{"Major:",-19} {cbBoxMajor.Text}", "STUDENT'S INFORMATION");
        }

        private void numSemester_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
                && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFulName.Text = string.Empty;
            rbtnMale.Checked = false;
            rbtnFemale.Checked = false;
            rbtnOther.Checked = false;
            birthday.Value = DateTime.Now;
            txtEmail.Text = string.Empty;
            numSemester.Text = string.Empty;
            cbBoxMajor.SelectedIndex = -1;
        }
    }
}
