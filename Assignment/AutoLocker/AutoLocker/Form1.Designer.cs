namespace AutoLocker
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
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            button4 = new Button();
            button3 = new Button();
            label1 = new Label();
            button2 = new Button();
            button1 = new Button();
            label5 = new Label();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(84, 236);
            label4.Name = "label4";
            label4.Size = new Size(54, 20);
            label4.TabIndex = 15;
            label4.Text = "Lock 2:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(84, 309);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 14;
            label3.Text = "Lock 3:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(84, 377);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 13;
            label2.Text = "Lock 4:";
            // 
            // button4
            // 
            button4.Location = new Point(164, 373);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 12;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(164, 300);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 11;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(84, 160);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 10;
            label1.Text = "Lock 1:";
            // 
            // button2
            // 
            button2.Location = new Point(164, 227);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 9;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(164, 151);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 8;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(22, 41);
            label5.Name = "label5";
            label5.Size = new Size(308, 54);
            label5.TabIndex = 16;
            label5.Text = "Lock Controller";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(352, 450);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private Label label3;
        private Label label2;
        private Button button4;
        private Button button3;
        private Label label1;
        private Button button2;
        private Button button1;
        private Label label5;
    }
}