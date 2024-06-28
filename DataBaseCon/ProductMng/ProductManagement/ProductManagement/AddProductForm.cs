using ProductManagement.Repo.Models;
using ProductManagement.Repo.Repo;
using System;
using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductManagementApp
{
    public partial class AddProductForm : Form
    {
        private List<Category> categories;
        private ProductRepo productRepo;

        //public AddProductForm()
        //{
        //    InitializeComponent();
        //    //Add under initiallize!

        //}

        public AddProductForm(List<Category> cats, ProductRepo proRepo)
        {
            InitializeComponent();
            categories = cats; //cats : parameters
            productRepo = proRepo;

            LoadCategoryComboBox();
        }

        private void LoadCategoryComboBox()
        {
            cmbCategory.DataSource = categories;
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "Id";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private bool ValidationFromData()   

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string priceText = txtPrice.Text;
                //double price = Convert.ToDouble(priceText);
                double price = double.Parse(priceText);

                Product product = new Product()
                {
                    Name = txtProductName.Text,
                    Price = price,
                    CatId = (int)cmbCategory.SelectedValue
                };

                productRepo.AddProduct(product);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
