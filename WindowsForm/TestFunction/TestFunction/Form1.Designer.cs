namespace TestFunction
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
            txtBox = new TextBox();
            btn1 = new Button();
            cbb1 = new ComboBox();
            txtResult = new TextBox();
            rtxtTest = new RichTextBox();
            SuspendLayout();
            // 
            // txtBox
            // 
            txtBox.Location = new Point(275, 72);
            txtBox.Name = "txtBox";
            txtBox.Size = new Size(264, 27);
            txtBox.TabIndex = 0;
            // 
            // btn1
            // 
            btn1.Location = new Point(545, 70);
            btn1.Name = "btn1";
            btn1.Size = new Size(94, 29);
            btn1.TabIndex = 1;
            btn1.Text = "button1";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += btn1_Click;
            // 
            // cbb1
            // 
            cbb1.DropDownStyle = ComboBoxStyle.DropDownList;
            cbb1.FormattingEnabled = true;
            cbb1.Items.AddRange(new object[] { "(All)", "Test 1", "Test 2" });
            cbb1.Location = new Point(142, 71);
            cbb1.Name = "cbb1";
            cbb1.Size = new Size(127, 28);
            cbb1.TabIndex = 2;
            // 
            // txtResult
            // 
            txtResult.Location = new Point(67, 118);
            txtResult.Name = "txtResult";
            txtResult.Size = new Size(665, 27);
            txtResult.TabIndex = 3;
            // 
            // rtxtTest
            // 
            rtxtTest.Location = new Point(157, 176);
            rtxtTest.Name = "rtxtTest";
            rtxtTest.Size = new Size(466, 141);
            rtxtTest.TabIndex = 4;
            rtxtTest.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rtxtTest);
            Controls.Add(txtResult);
            Controls.Add(cbb1);
            Controls.Add(btn1);
            Controls.Add(txtBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBox;
        private Button btn1;
        private ComboBox cbb1;
        private TextBox txtResult;
        private RichTextBox rtxtTest;
    }
}