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
using ProductManagement.Repo.Models;
using ProductManagement.Repo.Repo;

namespace ProductManagementApp
{
    public partial class UpdateProductForm : Form
    {
        private List<Category> categories;
        private ProductRepo productRepo;

        private Product product;

        public UpdateProductForm(List<Category> cats, ProductRepo proRepo, int productId)
        {
            InitializeComponent();
            categories = cats; //cats : parameters
            productRepo = proRepo;

            product = productRepo.GetProductByPId(productId);
            txtProductId.Text = product.Id.ToString();
            txtProductName.Text = product.Name;
            txtPrice.Text = product.Price.ToString();
            cmbCategory.SelectedValue = product.CatId;


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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //Set product attribute value
                product.Name = txtProductName.Text;
                product.Price = double.Parse(txtPrice.Text);
                product.CatId = (int)cmbCategory.SelectedValue;

                //Update product
                productRepo.UpdateProduct(product);

                this.Close();

            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
