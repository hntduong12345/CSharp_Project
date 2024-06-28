using Microsoft.AspNetCore.Http;
using Nancy.Json;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace TestFunction
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            // ID Formater
            //Initalize data
            StringBuilder sb = new StringBuilder("O");
            Random random = new Random();

            //Set the Middle and End Part of ID
            int dateValue = DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year;
            int randomEndNumber = random.Next(1000000, 9999999);

            sb.Append(dateValue);
            sb.Append(randomEndNumber);


            txtResult.Text = sb.ToString();



            //var test = txtBox.Text.Length == 0 ? 
            //    "A1" :
            //    Regex.Replace(txtBox.Text, "\\d+", n => (int.Parse(n.Value)+1).ToString(new string('0', n.Value.Length)));
            //txtBox.Text = test;
        }
    }
}