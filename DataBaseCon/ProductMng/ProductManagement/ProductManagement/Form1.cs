using ProductManagement.Repo.Models;
using ProductManagement.Repo.Repo;
using ProductManagementApp;
using System.Configuration;

namespace ProductManagement
{
    public partial class Form1 : Form
    {
        private List<Category> categories;

        private string connectionString;
        private ProductDb1Context db1Context;
        private CategoryRepo categoryRepo;
        private ProductRepo productRepo;

        public Form1()
        {
            InitializeComponent();
            Config();
        }

        private void Config()
        {
            //connectionString = ConfigurationManager.ConnectionStrings["ProductDB1"].ConnectionString;
            connectionString = Util.GetConnectionString();
            db1Context = new ProductDb1Context(connectionString);
            categoryRepo = new CategoryRepo(db1Context);
            productRepo = new ProductRepo(db1Context);
        }

        private void LoadCategoryToComboBox()
        {
            categories = categoryRepo.GetCategories().ToList();
            cmbCategory.DataSource = categories;
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "Id";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Config();
            LoadCategoryToComboBox();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Check selected value is a number;
            if (cmbCategory.SelectedValue is int)
            {
                LoadProduct();
            }
        }

        private void LoadProduct()
        {
            int catId = (int)cmbCategory.SelectedValue;
            var products = productRepo.GetProductByCatId(catId);
            dataGridView1.DataSource = products;
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm(categories, productRepo);
            addProductForm.ShowDialog();
            LoadProduct();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure to delete?", "Confirm", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var productId = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                    productRepo.DetachProduct(productId);
                    LoadProduct();
                }
            }
            else
            {
                MessageBox.Show("Please Select Product To Delete", "Error");
            }
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                var productID = (int)dataGridView1.SelectedRows[0].Cells[0].Value;

                UpdateProductForm updateProductForm = 
                    new UpdateProductForm(categories, productRepo, productID);

                updateProductForm.ShowDialog();
                LoadProduct();
            }
            else
            {
                MessageBox.Show("Please select product to update", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}