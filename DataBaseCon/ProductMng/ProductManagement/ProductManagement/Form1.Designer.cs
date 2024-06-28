namespace ProductManagement
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbCategory = new ComboBox();
            dataGridView1 = new DataGridView();
            btnAddProduct = new Button();
            label1 = new Label();
            btnDelete = new Button();
            btnUpdateProduct = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(134, 51);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(151, 28);
            cmbCategory.TabIndex = 0;
            cmbCategory.SelectedIndexChanged += cmbCategory_SelectedIndexChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(50, 115);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(698, 304);
            dataGridView1.TabIndex = 1;
            // 
            // btnAddProduct
            // 
            btnAddProduct.Location = new Point(327, 50);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(120, 29);
            btnAddProduct.TabIndex = 2;
            btnAddProduct.Text = "Add Product";
            btnAddProduct.UseVisualStyleBackColor = true;
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 54);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 3;
            label1.Text = "Category";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(628, 51);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 29);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete Product";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdateProduct
            // 
            btnUpdateProduct.Location = new Point(476, 51);
            btnUpdateProduct.Name = "btnUpdateProduct";
            btnUpdateProduct.Size = new Size(128, 29);
            btnUpdateProduct.TabIndex = 5;
            btnUpdateProduct.Text = "Update Product";
            btnUpdateProduct.UseVisualStyleBackColor = true;
            btnUpdateProduct.Click += btnUpdateProduct_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnUpdateProduct);
            Controls.Add(btnDelete);
            Controls.Add(label1);
            Controls.Add(btnAddProduct);
            Controls.Add(dataGridView1);
            Controls.Add(cmbCategory);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbCategory;
        private DataGridView dataGridView1;
        private Button btnAddProduct;
        private Label label1;
        private Button btnDelete;
        private Button btnUpdateProduct;
    }
}