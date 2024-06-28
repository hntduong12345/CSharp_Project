namespace ReadCSVFile
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
            openFileDialog1 = new OpenFileDialog();
            btnChooseFolder = new Button();
            dataGridView1 = new DataGridView();
            txtFolderName = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnChooseFolder
            // 
            btnChooseFolder.Location = new Point(679, 33);
            btnChooseFolder.Name = "btnChooseFolder";
            btnChooseFolder.Size = new Size(94, 29);
            btnChooseFolder.TabIndex = 0;
            btnChooseFolder.Text = "Choose";
            btnChooseFolder.UseVisualStyleBackColor = true;
            btnChooseFolder.Click += btnOpen_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(32, 86);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(741, 352);
            dataGridView1.TabIndex = 1;
            // 
            // txtFolderName
            // 
            txtFolderName.Location = new Point(136, 33);
            txtFolderName.Name = "txtFolderName";
            txtFolderName.Size = new Size(522, 27);
            txtFolderName.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 33);
            label1.Name = "label1";
            label1.Size = new Size(98, 20);
            label1.TabIndex = 3;
            label1.Text = "Folder Name:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(txtFolderName);
            Controls.Add(dataGridView1);
            Controls.Add(btnChooseFolder);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private Button btnChooseFolder;
        private DataGridView dataGridView1;
        private TextBox txtFolderName;
        private Label label1;
    }
}