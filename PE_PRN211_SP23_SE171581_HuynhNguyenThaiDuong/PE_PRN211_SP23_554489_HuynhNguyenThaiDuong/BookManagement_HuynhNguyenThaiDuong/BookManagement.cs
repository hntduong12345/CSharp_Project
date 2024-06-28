using BookManagement_HuynhNguyenThaiDuong.Repo.Models;
using BookManagement_HuynhNguyenThaiDuong.Repo.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManagement_HuynhNguyenThaiDuong
{
    public partial class BookManagement : Form
    {
        private BookManagement2023DBContext dBContext;
        private BookRepo BookRepo;
        private BookCategoryRepo BookCategoryRepo;

        public BookManagement(BookManagement2023DBContext context)
        {
            InitializeComponent();
            dBContext = context;
            BookCategoryRepo = new BookCategoryRepo(context);
            BookRepo = new BookRepo(context);

            Load();
        }

        private void Load()
        {
            List<Book> books = BookRepo.GetBooks();
            dataGridView1.DataSource = books;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void BookManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
