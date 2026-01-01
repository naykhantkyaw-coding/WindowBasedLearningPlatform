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
            btn_Title = new Button();
            btn_SignOut = new Button();
            btn_dashboard = new Button();
            btn_profile = new Button();
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
            panelContent.Location = new Point(307, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1046, 908);
            panelContent.TabIndex = 2;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(555, 35);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(101, 23);
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Location = new Point(432, 137);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(21, 20, 21, 20);
            panel1.Size = new Size(299, 149);
            panel1.TabIndex = 0;
            // 
            // panelSidebar
            // 
            panelSidebar.ColorBottom = Color.FromArgb(26, 5, 16);
            panelSidebar.ColorTop = Color.FromArgb(144, 12, 63);
            panelSidebar.Controls.Add(btn_Title);
            panelSidebar.Controls.Add(btn_SignOut);
            panelSidebar.Controls.Add(btn_dashboard);
            panelSidebar.Controls.Add(btn_profile);
            panelSidebar.Controls.Add(btn_Courses);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Margin = new Padding(3, 4, 3, 4);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(307, 908);
            panelSidebar.TabIndex = 2;
            // 
            // btn_Title
            // 
            btn_Title.BackColor = Color.Transparent;
            btn_Title.Dock = DockStyle.Top;
            btn_Title.FlatStyle = FlatStyle.Flat;
            btn_Title.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Title.ForeColor = Color.White;
            btn_Title.Image = (Image)resources.GetObject("btn_Title.Image");
            btn_Title.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Title.Location = new Point(0, 0);
            btn_Title.Name = "btn_Title";
            btn_Title.Size = new Size(307, 77);
            btn_Title.TabIndex = 15;
            btn_Title.Text = "CODE LEARNER";
            btn_Title.UseVisualStyleBackColor = false;
            // 
            // btn_SignOut
            // 
            btn_SignOut.BackColor = Color.Transparent;
            btn_SignOut.Cursor = Cursors.Hand;
            btn_SignOut.Dock = DockStyle.Bottom;
            btn_SignOut.FlatStyle = FlatStyle.Popup;
            btn_SignOut.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_SignOut.ForeColor = Color.White;
            btn_SignOut.Image = (Image)resources.GetObject("btn_SignOut.Image");
            btn_SignOut.ImageAlign = ContentAlignment.MiddleLeft;
            btn_SignOut.Location = new Point(0, 831);
            btn_SignOut.Name = "btn_SignOut";
            btn_SignOut.Size = new Size(307, 77);
            btn_SignOut.TabIndex = 14;
            btn_SignOut.Text = "Sign Out";
            btn_SignOut.UseVisualStyleBackColor = false;
            btn_SignOut.Click += btn_signout_Click;
            // 
            // btn_dashboard
            // 
            btn_dashboard.BackColor = Color.Transparent;
            btn_dashboard.Cursor = Cursors.Hand;
            btn_dashboard.FlatAppearance.BorderSize = 0;
            btn_dashboard.FlatStyle = FlatStyle.Popup;
            btn_dashboard.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_dashboard.ForeColor = Color.White;
            btn_dashboard.Image = (Image)resources.GetObject("btn_dashboard.Image");
            btn_dashboard.ImageAlign = ContentAlignment.MiddleLeft;
            btn_dashboard.Location = new Point(0, 83);
            btn_dashboard.Name = "btn_dashboard";
            btn_dashboard.Size = new Size(307, 77);
            btn_dashboard.TabIndex = 12;
            btn_dashboard.Text = "Dashboard";
            btn_dashboard.UseVisualStyleBackColor = false;
            btn_dashboard.Click += btn_dashboard_Click;
            // 
            // btn_profile
            // 
            btn_profile.BackColor = Color.Transparent;
            btn_profile.Cursor = Cursors.Hand;
            btn_profile.FlatStyle = FlatStyle.Popup;
            btn_profile.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_profile.ForeColor = Color.White;
            btn_profile.Image = (Image)resources.GetObject("btn_profile.Image");
            btn_profile.ImageAlign = ContentAlignment.MiddleLeft;
            btn_profile.Location = new Point(0, 166);
            btn_profile.Name = "btn_profile";
            btn_profile.Size = new Size(307, 77);
            btn_profile.TabIndex = 13;
            btn_profile.Text = "Profile";
            btn_profile.UseVisualStyleBackColor = false;
            btn_profile.Click += btn_profile_Click;
            // 
            // btn_Courses
            // 
            btn_Courses.BackColor = Color.Transparent;
            btn_Courses.Cursor = Cursors.Hand;
            btn_Courses.FlatStyle = FlatStyle.Popup;
            btn_Courses.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Courses.ForeColor = Color.White;
            btn_Courses.Image = (Image)resources.GetObject("btn_Courses.Image");
            btn_Courses.ImageAlign = ContentAlignment.MiddleLeft;
            btn_Courses.Location = new Point(0, 249);
            btn_Courses.Name = "btn_Courses";
            btn_Courses.Size = new Size(307, 77);
            btn_Courses.TabIndex = 11;
            btn_Courses.Text = "Courses";
            btn_Courses.UseVisualStyleBackColor = false;
            btn_Courses.Click += btn_courses_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(1353, 908);
            Controls.Add(panelContent);
            Controls.Add(panelSidebar);
            Margin = new Padding(3, 4, 3, 4);
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
        private Button btn_SignOut;
        private Button btn_profile;
        private Button btn_dashboard;
        private Button btn_Courses;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button btn_Title;
    }
}