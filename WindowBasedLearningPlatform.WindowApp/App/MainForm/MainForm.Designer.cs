namespace WindowBasedLearningPlatform.WindowApp.App
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panelContent = new Panel();
            progressBar1 = new ProgressBar();
            panel1 = new Panel();
            panelSidebar = new GradientPanel();
            button1 = new Button();
            btn_profile = new Button();
            btn_dashboard = new Button();
            btn_Courses = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panelContent.SuspendLayout();
            panelSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // panelContent
            // 
            panelContent.Controls.Add(progressBar1);
            panelContent.Controls.Add(panel1);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(229, 0);
            panelContent.Margin = new Padding(3, 2, 3, 2);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(955, 681);
            panelContent.TabIndex = 2;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(486, 26);
            progressBar1.Margin = new Padding(3, 2, 3, 2);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(88, 17);
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Location = new Point(378, 103);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(18, 15, 18, 15);
            panel1.Size = new Size(262, 112);
            panel1.TabIndex = 0;
            // 
            // panelSidebar
            // 
            panelSidebar.ColorBottom = Color.FromArgb(147, 51, 234);
            panelSidebar.ColorTop = Color.FromArgb(219, 39, 119);
            panelSidebar.Controls.Add(button1);
            panelSidebar.Controls.Add(btn_profile);
            panelSidebar.Controls.Add(btn_dashboard);
            panelSidebar.Controls.Add(btn_Courses);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(229, 681);
            panelSidebar.TabIndex = 2;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.Dock = DockStyle.Bottom;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(0, 649);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(229, 32);
            button1.TabIndex = 14;
            button1.Text = "Sign Out";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btn_signout_Click;
            // 
            // btn_profile
            // 
            btn_profile.BackColor = Color.Transparent;
            btn_profile.Dock = DockStyle.Top;
            btn_profile.FlatStyle = FlatStyle.Popup;
            btn_profile.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_profile.ForeColor = Color.White;
            btn_profile.Image = (Image)resources.GetObject("btn_profile.Image");
            btn_profile.ImageAlign = ContentAlignment.MiddleLeft;
            btn_profile.Location = new Point(0, 64);
            btn_profile.Margin = new Padding(3, 2, 3, 2);
            btn_profile.Name = "btn_profile";
            btn_profile.Size = new Size(229, 32);
            btn_profile.TabIndex = 13;
            btn_profile.Text = "Profile";
            btn_profile.UseVisualStyleBackColor = false;
            btn_profile.Click += btn_profile_Click;
            // 
            // btn_dashboard
            // 
            btn_dashboard.BackColor = Color.Transparent;
            btn_dashboard.Dock = DockStyle.Top;
            btn_dashboard.FlatStyle = FlatStyle.Popup;
            btn_dashboard.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_dashboard.ForeColor = Color.White;
            btn_dashboard.Image = (Image)resources.GetObject("btn_dashboard.Image");
            btn_dashboard.ImageAlign = ContentAlignment.MiddleLeft;
            btn_dashboard.Location = new Point(0, 32);
            btn_dashboard.Margin = new Padding(3, 2, 3, 2);
            btn_dashboard.Name = "btn_dashboard";
            btn_dashboard.Size = new Size(229, 32);
            btn_dashboard.TabIndex = 12;
            btn_dashboard.Text = "Dashboard";
            btn_dashboard.UseVisualStyleBackColor = false;
            btn_dashboard.Click += btn_dashboard_Click;
            // 
            // btn_Courses
            // 
            btn_Courses.BackColor = Color.Transparent;
            btn_Courses.Dock = DockStyle.Top;
            btn_Courses.FlatStyle = FlatStyle.Popup;
            btn_Courses.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Courses.ForeColor = Color.White;
            btn_Courses.Image = (Image)resources.GetObject("btn_Courses.Image");
            btn_Courses.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Courses.Location = new Point(0, 0);
            btn_Courses.Margin = new Padding(3, 2, 3, 2);
            btn_Courses.Name = "btn_Courses";
            btn_Courses.Size = new Size(229, 32);
            btn_Courses.TabIndex = 11;
            btn_Courses.Text = "Courses";
            btn_Courses.UseVisualStyleBackColor = false;
            btn_Courses.Click += btn_courses_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(1184, 681);
            Controls.Add(panelContent);
            Controls.Add(panelSidebar);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Learning Platform";
            panelContent.ResumeLayout(false);
            panelSidebar.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel1;
        private GradientPanel panelSidebar;
        private Button button1;
        private Button btn_profile;
        private Button btn_dashboard;
        private Button btn_Courses;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}