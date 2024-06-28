using BookManagement_HuynhNguyenThaiDuong.Repo.Models;
using BookManagement_HuynhNguyenThaiDuong.Repo.Repo;

namespace BookManagement_HuynhNguyenThaiDuong
{
    public partial class Login : Form
    {
        private BookManagement2023DBContext context;
        private BookManagementMemberRepo bookManagementMemberRepo;

        public Login()
        {
            InitializeComponent();
            Utils utils = new Utils();
            string ConnectionStr = utils.GetConnectionString();
            context  = new BookManagement2023DBContext(ConnectionStr);
            bookManagementMemberRepo = new BookManagementMemberRepo(context);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text;
                string pass = txtPass.Text;
                int check = bookManagementMemberRepo.CheckLogin(email, pass);

                if (check == 1){
                    BookManagement bookManagement = new BookManagement(context);
                    bookManagement.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("You have no permission to access this function");
                }

            }catch (Exception ex)
            {
                MessageBox.Show("Invalid Input");
            }
        }
    }
}