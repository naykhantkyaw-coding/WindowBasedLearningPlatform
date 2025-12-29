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
            panelContent = new Panel();
            panelSidebar = new GradientPanel();
            lbl_CodeLearn = new Label();
            btn_Courses = new Button();
            progressBar1 = new ProgressBar();
            panel1 = new Panel();
            btn_dashboard = new Button();
            btn_profile = new Button();
            button1 = new Button();
            panelContent.SuspendLayout();
            panelSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // panelContent
            // 
            panelContent.Controls.Add(progressBar1);
            panelContent.Controls.Add(panel1);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(250, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(934, 681);
            panelContent.TabIndex = 2;
            // 
            // panelSidebar
            // 
            panelSidebar.ColorBottom = Color.FromArgb(20, 20, 35);
            panelSidebar.ColorTop = Color.FromArgb(50, 50, 70);
            panelSidebar.Controls.Add(button1);
            panelSidebar.Controls.Add(btn_profile);
            panelSidebar.Controls.Add(btn_dashboard);
            panelSidebar.Controls.Add(lbl_CodeLearn);
            panelSidebar.Controls.Add(btn_Courses);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(250, 681);
            panelSidebar.TabIndex = 0;
            // 
            // lbl_CodeLearn
            // 
            lbl_CodeLearn.AutoSize = true;
            lbl_CodeLearn.BackColor = Color.Transparent;
            lbl_CodeLearn.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_CodeLearn.ForeColor = Color.White;
            lbl_CodeLearn.Location = new Point(25, 557);
            lbl_CodeLearn.Name = "lbl_CodeLearn";
            lbl_CodeLearn.Padding = new Padding(20, 20, 0, 0);
            lbl_CodeLearn.Size = new Size(155, 52);
            lbl_CodeLearn.TabIndex = 0;
            lbl_CodeLearn.Text = "CodeLearn";
            // 
            // btn_Courses
            // 
            btn_Courses.Dock = DockStyle.Top;
            btn_Courses.Location = new Point(0, 0);
            btn_Courses.Margin = new Padding(3, 2, 3, 2);
            btn_Courses.Name = "btn_Courses";
            btn_Courses.Size = new Size(250, 43);
            btn_Courses.TabIndex = 1;
            btn_Courses.Text = "Courses";
            btn_Courses.Click += btn_courses_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(556, 35);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(100, 23);
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Location = new Point(89, 89);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(20, 20, 20, 20);
            panel1.Size = new Size(300, 150);
            panel1.TabIndex = 0;
            // 
            // btn_dashboard
            // 
            btn_dashboard.Dock = DockStyle.Top;
            btn_dashboard.Location = new Point(0, 43);
            btn_dashboard.Margin = new Padding(3, 2, 3, 2);
            btn_dashboard.Name = "btn_dashboard";
            btn_dashboard.Size = new Size(250, 43);
            btn_dashboard.TabIndex = 8;
            btn_dashboard.Text = "Dashboard";
            btn_dashboard.Click += btn_dashboard_Click;
            // 
            // btn_profile
            // 
            btn_profile.Dock = DockStyle.Top;
            btn_profile.Location = new Point(0, 86);
            btn_profile.Margin = new Padding(3, 2, 3, 2);
            btn_profile.Name = "btn_profile";
            btn_profile.Size = new Size(250, 43);
            btn_profile.TabIndex = 9;
            btn_profile.Text = "Profile";
            btn_profile.Click += btn_profile_Click;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Bottom;
            button1.Location = new Point(0, 638);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(250, 43);
            button1.TabIndex = 10;
            button1.Text = "Sign Out";
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
            panelSidebar.PerformLayout();
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel1;
        private GradientPanel panelSidebar;
        private Label lbl_CodeLearn;
        private Button btn_Courses;
        private Button button1;
        private Button btn_profile;
        private Button btn_dashboard;
    }
}