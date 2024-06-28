namespace ProductManagementApp
{
    partial class UpdateProductForm
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
            txtProductId = new TextBox();
            label3 = new Label();
            label4 = new Label();
            cmbCategory = new ComboBox();
            label5 = new Label();
            txtProductName = new TextBox();
            txtPrice = new TextBox();
            btnUpdate = new Button();
            btnClose = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 107);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 0;
            label1.Text = "Product Id:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(126, 32);
            label2.Name = "label2";
            label2.Size = new Size(223, 38);
            label2.TabIndex = 1;
            label2.Text = "Update Product";
            // 
            // txtProductId
            // 
            txtProductId.Location = new Point(223, 104);
            txtProductId.Name = "txtProductId";
            txtProductId.ReadOnly = true;
            txtProductId.Size = new Size(79, 27);
            txtProductId.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 170);
            label3.Name = "label3";
            label3.Size = new Size(107, 20);
            label3.TabIndex = 3;
            label3.Text = "Product Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(39, 232);
            label4.Name = "label4";
            label4.Size = new Size(44, 20);
            label4.TabIndex = 4;
            label4.Text = "Price:";
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(223, 296);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(197, 28);
            cmbCategory.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(39, 299);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 6;
            label5.Text = "Category";
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(223, 167);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(197, 27);
            txtProductName.TabIndex = 7;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(223, 229);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(197, 27);
            txtPrice.TabIndex = 8;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(83, 367);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(276, 367);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 29);
            btnClose.TabIndex = 10;
            btnClose.Text = "Cancel";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // UpdateProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 450);
            Controls.Add(btnClose);
            Controls.Add(btnUpdate);
            Controls.Add(txtPrice);
            Controls.Add(txtProductName);
            Controls.Add(label5);
            Controls.Add(cmbCategory);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtProductId);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UpdateProductForm";
            Text = "UpdateProductForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtProductId;
        private Label label3;
        private Label label4;
        private ComboBox cmbCategory;
        private Label label5;
        private TextBox txtProductName;
        private TextBox txtPrice;
        private Button btnUpdate;
        private Button btnClose;
    }
}