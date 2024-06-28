namespace ProductManagementApp
{
    partial class AddProductForm
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
            label1 = new Label();
            label2 = new Label();
            txtProductName = new TextBox();
            label3 = new Label();
            cmbCategory = new ComboBox();
            btnAdd = new Button();
            btnClose = new Button();
            label4 = new Label();
            txtPrice = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(156, 21);
            label1.Name = "label1";
            label1.Size = new Size(249, 38);
            label1.TabIndex = 0;
            label1.Text = "Add New Product";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(92, 77);
            label2.Name = "label2";
            label2.Size = new Size(107, 20);
            label2.TabIndex = 0;
            label2.Text = "Product Name:";
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(235, 77);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(220, 27);
            txtProductName.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(92, 138);
            label3.Name = "label3";
            label3.Size = new Size(44, 20);
            label3.TabIndex = 1;
            label3.Text = "Price:";
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(235, 205);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(220, 28);
            cmbCategory.TabIndex = 5;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(141, 297);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(322, 297);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 29);
            btnClose.TabIndex = 7;
            btnClose.Text = "Cancel";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(92, 208);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 2;
            label4.Text = "Category:";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(235, 135);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(220, 27);
            txtPrice.TabIndex = 4;
            // 
            // AddProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(571, 450);
            Controls.Add(txtPrice);
            Controls.Add(label4);
            Controls.Add(btnClose);
            Controls.Add(btnAdd);
            Controls.Add(cmbCategory);
            Controls.Add(label3);
            Controls.Add(txtProductName);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddProductForm";
            Text = "AddProductForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtProductName;
        private Label label3;
        private ComboBox cmbCategory;
        private Button btnAdd;
        private Button btnClose;
        private Label label4;
        private TextBox txtPrice;
    }
}