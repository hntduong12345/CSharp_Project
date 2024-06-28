namespace PRN211_windows_layout
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
            components = new System.ComponentModel.Container();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            clearToolStripMenuItem = new ToolStripMenuItem();
            changeImageToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog1 = new OpenFileDialog();
            panel1 = new Panel();
            clock = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            button1 = new Button();
            groupBox1 = new GroupBox();
            button3 = new Button();
            button2 = new Button();
            tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(1, 134);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1033, 378);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1025, 345);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Student";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1025, 345);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Topic";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1025, 345);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Group";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(131, 39);
            label1.Name = "label1";
            label1.Size = new Size(680, 50);
            label1.TabIndex = 1;
            label1.Text = "PRN211 Student Manegement System";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.BackColor = SystemColors.MenuHighlight;
            pictureBox1.ContextMenuStrip = contextMenuStrip1;
            pictureBox1.InitialImage = PRN211_winform_layout.Properties.Resources._742320;
            pictureBox1.Location = new Point(26, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(166, 113);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { clearToolStripMenuItem, changeImageToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(175, 52);
            contextMenuStrip1.Text = "Change Image";
            // 
            // clearToolStripMenuItem
            // 
            clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            clearToolStripMenuItem.Size = new Size(174, 24);
            clearToolStripMenuItem.Text = "Clear";
            clearToolStripMenuItem.Click += clearToolStripMenuItem_Click;
            // 
            // changeImageToolStripMenuItem
            // 
            changeImageToolStripMenuItem.Name = "changeImageToolStripMenuItem";
            changeImageToolStripMenuItem.Size = new Size(174, 24);
            changeImageToolStripMenuItem.Text = "Change Image";
            changeImageToolStripMenuItem.Click += changeImageToolStripMenuItem_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = " JPG Files|*.jpg|JPEG Files|*.jpeg|PNG Files|*.png";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(817, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(213, 125);
            panel1.TabIndex = 0;
            // 
            // clock
            // 
            clock.AutoSize = true;
            clock.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            clock.ForeColor = SystemColors.MenuHighlight;
            clock.Location = new Point(12, 15);
            clock.Name = "clock";
            clock.Size = new Size(119, 38);
            clock.TabIndex = 2;
            clock.Text = "00:00:00";
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // button1
            // 
            button1.Location = new Point(28, 26);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 3;
            button1.Text = "Attendance";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Location = new Point(293, 92);
            groupBox1.MaximumSize = new Size(400, 63);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(400, 63);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Action";
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.Location = new Point(290, 26);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 5;
            button3.Text = "Close";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top;
            button2.Location = new Point(150, 26);
            button2.Name = "button2";
            button2.Size = new Size(117, 29);
            button2.TabIndex = 4;
            button2.Text = "Take a Break";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1033, 513);
            Controls.Add(groupBox1);
            Controls.Add(clock);
            Controls.Add(label1);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Label label1;
        private PictureBox pictureBox1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ToolStripMenuItem changeImageToolStripMenuItem;
        private OpenFileDialog openFileDialog1;
        private Panel panel1;
        private Label clock;
        private System.Windows.Forms.Timer timer1;
        private Button button1;
        private GroupBox groupBox1;
        private Button button2;
        private Button button3;
    }
}