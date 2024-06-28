namespace DestopApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPassword.Text = string.Empty;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please input username or password!", "Warning");
            }
            else if (txtUserName.Text == "admin" && txtPassword.Text == "123456")
            {
                //Show form2
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Incorrect username or password", "Warning",
                    MessageBoxButtons.OK);
            }
        }
    }
}