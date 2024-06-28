namespace ChooseExelFolder
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
            btnChooseFolder = new Button();
            txtFolderName = new TextBox();
            label1 = new Label();
            folderBrowserDialog1 = new FolderBrowserDialog();
            listBox1 = new ListBox();
            btnView = new Button();
            dataGridView1 = new DataGridView();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnChooseFolder
            // 
            btnChooseFolder.Location = new Point(630, 41);
            btnChooseFolder.Name = "btnChooseFolder";
            btnChooseFolder.Size = new Size(94, 29);
            btnChooseFolder.TabIndex = 0;
            btnChooseFolder.Text = "Choose";
            btnChooseFolder.UseVisualStyleBackColor = true;
            btnChooseFolder.Click += btnChooseFolder_Click;
            // 
            // txtFolderName
            // 
            txtFolderName.Location = new Point(176, 42);
            txtFolderName.Name = "txtFolderName";
            txtFolderName.Size = new Size(413, 27);
            txtFolderName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(58, 45);
            label1.Name = "label1";
            label1.Size = new Size(98, 20);
            label1.TabIndex = 2;
            label1.Text = "Folder Name:";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(58, 111);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(673, 244);
            listBox1.TabIndex = 3;
            // 
            // btnView
            // 
            btnView.Location = new Point(637, 390);
            btnView.Name = "btnView";
            btnView.Size = new Size(94, 29);
            btnView.TabIndex = 4;
            btnView.Text = "View";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(58, 111);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(673, 244);
            dataGridView1.TabIndex = 5;
            dataGridView1.RowPostPaint += dataGridView1_RowPostPaint;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(58, 390);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 29);
            btnClose.TabIndex = 6;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClose);
            Controls.Add(dataGridView1);
            Controls.Add(btnView);
            Controls.Add(listBox1);
            Controls.Add(label1);
            Controls.Add(txtFolderName);
            Controls.Add(btnChooseFolder);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnChooseFolder;
        private TextBox txtFolderName;
        private Label label1;
        private FolderBrowserDialog folderBrowserDialog1;
        private ListBox listBox1;
        private Button btnView;
        private DataGridView dataGridView1;
        private Button btnClose;
    }
}