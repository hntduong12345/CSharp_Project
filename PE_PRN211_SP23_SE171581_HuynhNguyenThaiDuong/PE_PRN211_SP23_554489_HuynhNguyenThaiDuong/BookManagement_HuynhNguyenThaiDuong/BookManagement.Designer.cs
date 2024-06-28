namespace BookManagement_HuynhNguyenThaiDuong
{
    partial class BookManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            dataGridView1 = new DataGridView();
            bookIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bookNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            releaseDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            quantityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            priceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            authorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            BookGenreType = new DataGridViewTextBoxColumn();
            bookBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bookBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(221, 23);
            label1.Name = "label1";
            label1.Size = new Size(382, 54);
            label1.TabIndex = 0;
            label1.Text = "Book Management";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(778, 121);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add New";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(878, 121);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(978, 121);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { bookIdDataGridViewTextBoxColumn, bookNameDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn, releaseDateDataGridViewTextBoxColumn, quantityDataGridViewTextBoxColumn, priceDataGridViewTextBoxColumn, authorDataGridViewTextBoxColumn, BookGenreType });
            dataGridView1.DataSource = bookBindingSource;
            dataGridView1.Location = new Point(22, 156);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1050, 199);
            dataGridView1.TabIndex = 4;
            // 
            // bookIdDataGridViewTextBoxColumn
            // 
            bookIdDataGridViewTextBoxColumn.DataPropertyName = "BookId";
            bookIdDataGridViewTextBoxColumn.HeaderText = "BookId";
            bookIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            bookIdDataGridViewTextBoxColumn.Name = "bookIdDataGridViewTextBoxColumn";
            bookIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // bookNameDataGridViewTextBoxColumn
            // 
            bookNameDataGridViewTextBoxColumn.DataPropertyName = "BookName";
            bookNameDataGridViewTextBoxColumn.HeaderText = "BookName";
            bookNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            bookNameDataGridViewTextBoxColumn.Name = "bookNameDataGridViewTextBoxColumn";
            bookNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            descriptionDataGridViewTextBoxColumn.MinimumWidth = 6;
            descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            descriptionDataGridViewTextBoxColumn.Width = 125;
            // 
            // releaseDateDataGridViewTextBoxColumn
            // 
            releaseDateDataGridViewTextBoxColumn.DataPropertyName = "ReleaseDate";
            releaseDateDataGridViewTextBoxColumn.HeaderText = "ReleaseDate";
            releaseDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            releaseDateDataGridViewTextBoxColumn.Name = "releaseDateDataGridViewTextBoxColumn";
            releaseDateDataGridViewTextBoxColumn.Width = 125;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            quantityDataGridViewTextBoxColumn.MinimumWidth = 6;
            quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            quantityDataGridViewTextBoxColumn.Width = 125;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            priceDataGridViewTextBoxColumn.HeaderText = "Price";
            priceDataGridViewTextBoxColumn.MinimumWidth = 6;
            priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            priceDataGridViewTextBoxColumn.Width = 125;
            // 
            // authorDataGridViewTextBoxColumn
            // 
            authorDataGridViewTextBoxColumn.DataPropertyName = "Author";
            authorDataGridViewTextBoxColumn.HeaderText = "Author";
            authorDataGridViewTextBoxColumn.MinimumWidth = 6;
            authorDataGridViewTextBoxColumn.Name = "authorDataGridViewTextBoxColumn";
            authorDataGridViewTextBoxColumn.Width = 125;
            // 
            // BookGenreType
            // 
            BookGenreType.HeaderText = "BookGenreType";
            BookGenreType.MinimumWidth = 6;
            BookGenreType.Name = "BookGenreType";
            BookGenreType.Width = 125;
            // 
            // bookBindingSource
            // 
            bookBindingSource.DataSource = typeof(Repo.Models.Book);
            // 
            // BookManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1097, 450);
            Controls.Add(dataGridView1);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(label1);
            Name = "BookManagement";
            Text = "BookManagement";
            FormClosing += BookManagement_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bookBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn bookIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn bookNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn releaseDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn authorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn BookGenreType;
        private BindingSource bookBindingSource;
    }
}