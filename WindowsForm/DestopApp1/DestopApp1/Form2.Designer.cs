namespace DestopApp1
{
    partial class Form2
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
            boxGender = new GroupBox();
            rbtnOther = new RadioButton();
            rbtnFemale = new RadioButton();
            rbtnMale = new RadioButton();
            cbBoxMajor = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnClear = new Button();
            btnSubmit = new Button();
            txtFulName = new TextBox();
            birthday = new DateTimePicker();
            txtEmail = new TextBox();
            numSemester = new TextBox();
            boxGender.SuspendLayout();
            SuspendLayout();
            // 
            // boxGender
            // 
            boxGender.Controls.Add(rbtnOther);
            boxGender.Controls.Add(rbtnFemale);
            boxGender.Controls.Add(rbtnMale);
            boxGender.Location = new Point(217, 101);
            boxGender.Name = "boxGender";
            boxGender.Size = new Size(331, 87);
            boxGender.TabIndex = 2;
            boxGender.TabStop = false;
            boxGender.Text = "Gender:";
            // 
            // rbtnOther
            // 
            rbtnOther.AutoSize = true;
            rbtnOther.Location = new Point(264, 51);
            rbtnOther.Name = "rbtnOther";
            rbtnOther.Size = new Size(67, 24);
            rbtnOther.TabIndex = 2;
            rbtnOther.TabStop = true;
            rbtnOther.Text = "Other";
            rbtnOther.UseVisualStyleBackColor = true;
            // 
            // rbtnFemale
            // 
            rbtnFemale.AutoSize = true;
            rbtnFemale.Location = new Point(141, 51);
            rbtnFemale.Name = "rbtnFemale";
            rbtnFemale.Size = new Size(78, 24);
            rbtnFemale.TabIndex = 1;
            rbtnFemale.TabStop = true;
            rbtnFemale.Text = "Female";
            rbtnFemale.UseVisualStyleBackColor = true;
            // 
            // rbtnMale
            // 
            rbtnMale.AutoSize = true;
            rbtnMale.Location = new Point(18, 51);
            rbtnMale.Name = "rbtnMale";
            rbtnMale.Size = new Size(63, 24);
            rbtnMale.TabIndex = 0;
            rbtnMale.TabStop = true;
            rbtnMale.Text = "Male";
            rbtnMale.UseVisualStyleBackColor = true;
            // 
            // cbBoxMajor
            // 
            cbBoxMajor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBoxMajor.FormattingEnabled = true;
            cbBoxMajor.Items.AddRange(new object[] { "SE", "AI", "IA" });
            cbBoxMajor.Location = new Point(325, 359);
            cbBoxMajor.Name = "cbBoxMajor";
            cbBoxMajor.Size = new Size(223, 28);
            cbBoxMajor.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(217, 61);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 0;
            label1.Text = "Full Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(217, 212);
            label2.Name = "label2";
            label2.Size = new Size(97, 20);
            label2.TabIndex = 0;
            label2.Text = "Date of Birth:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(217, 261);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 0;
            label3.Text = "Email:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(217, 312);
            label4.Name = "label4";
            label4.Size = new Size(73, 20);
            label4.TabIndex = 0;
            label4.Text = "Semester:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(217, 363);
            label5.Name = "label5";
            label5.Size = new Size(51, 20);
            label5.TabIndex = 0;
            label5.Text = "Major:";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(217, 448);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(110, 39);
            btnClear.TabIndex = 7;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(438, 448);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(110, 39);
            btnSubmit.TabIndex = 8;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // txtFulName
            // 
            txtFulName.Location = new Point(325, 59);
            txtFulName.Name = "txtFulName";
            txtFulName.Size = new Size(223, 27);
            txtFulName.TabIndex = 1;
            // 
            // birthday
            // 
            birthday.CustomFormat = "dd/MM/yyyy";
            birthday.Format = DateTimePickerFormat.Custom;
            birthday.ImeMode = ImeMode.NoControl;
            birthday.Location = new Point(325, 207);
            birthday.Name = "birthday";
            birthday.Size = new Size(223, 27);
            birthday.TabIndex = 3;
            birthday.Value = new DateTime(2023, 5, 17, 0, 0, 0, 0);
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(325, 259);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(223, 27);
            txtEmail.TabIndex = 4;
            // 
            // numSemester
            // 
            numSemester.Location = new Point(325, 309);
            numSemester.Name = "numSemester";
            numSemester.Size = new Size(223, 27);
            numSemester.TabIndex = 5;
            numSemester.KeyPress += numSemester_KeyPress;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(771, 512);
            Controls.Add(numSemester);
            Controls.Add(txtEmail);
            Controls.Add(birthday);
            Controls.Add(txtFulName);
            Controls.Add(btnSubmit);
            Controls.Add(btnClear);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cbBoxMajor);
            Controls.Add(boxGender);
            Name = "Form2";
            Text = "Form2";
            FormClosed += Form2_FormClosed;
            boxGender.ResumeLayout(false);
            boxGender.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox boxGender;
        private RadioButton rbtnOther;
        private RadioButton rbtnFemale;
        private RadioButton rbtnMale;
        private ComboBox cbBoxMajor;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnClear;
        private Button btnSubmit;
        private TextBox txtFulName;
        private DateTimePicker birthday;
        private TextBox txtEmail;
        private TextBox numSemester;
    }
}