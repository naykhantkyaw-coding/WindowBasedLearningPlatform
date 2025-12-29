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
            btn_profile = new Button();
            btn_signout = new Button();
            btn_dashboard = new Button();
            progressBar1 = new ProgressBar();
            panel1 = new Panel();
            panelContent.SuspendLayout();
            panelSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // panelContent
            // 
            panelContent.Controls.Add(panelSidebar);
            panelContent.Controls.Add(progressBar1);
            panelContent.Controls.Add(panel1);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1184, 681);
            panelContent.TabIndex = 2;
            // 
            // panelSidebar
            // 
            panelSidebar.ColorBottom = Color.FromArgb(20, 20, 35);
            panelSidebar.ColorTop = Color.FromArgb(50, 50, 70);
            panelSidebar.Controls.Add(lbl_CodeLearn);
            panelSidebar.Controls.Add(btn_Courses);
            panelSidebar.Controls.Add(btn_profile);
            panelSidebar.Controls.Add(btn_signout);
            panelSidebar.Controls.Add(btn_dashboard);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(299, 681);
            panelSidebar.TabIndex = 5;
            // 
            // lbl_CodeLearn
            // 
            lbl_CodeLearn.AutoSize = true;
            lbl_CodeLearn.BackColor = Color.Transparent;
            lbl_CodeLearn.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_CodeLearn.ForeColor = Color.White;
            lbl_CodeLearn.Location = new Point(53, 210);
            lbl_CodeLearn.Name = "lbl_CodeLearn";
            lbl_CodeLearn.Padding = new Padding(20, 20, 0, 0);
            lbl_CodeLearn.Size = new Size(155, 52);
            lbl_CodeLearn.TabIndex = 9;
            lbl_CodeLearn.Text = "CodeLearn";
            // 
            // btn_Courses
            // 
            btn_Courses.Dock = DockStyle.Top;
            btn_Courses.FlatAppearance.BorderSize = 0;
            btn_Courses.FlatStyle = FlatStyle.Flat;
            btn_Courses.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_Courses.ForeColor = Color.White;
            btn_Courses.Location = new Point(0, 100);
            btn_Courses.Name = "btn_Courses";
            btn_Courses.Padding = new Padding(20, 0, 0, 0);
            btn_Courses.Size = new Size(299, 50);
            btn_Courses.TabIndex = 8;
            btn_Courses.Text = "Courses";
            btn_Courses.TextAlign = ContentAlignment.MiddleLeft;
            btn_Courses.UseVisualStyleBackColor = true;
            // 
            // btn_profile
            // 
            btn_profile.Dock = DockStyle.Top;
            btn_profile.FlatAppearance.BorderSize = 0;
            btn_profile.FlatStyle = FlatStyle.Flat;
            btn_profile.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_profile.ForeColor = Color.White;
            btn_profile.Location = new Point(0, 50);
            btn_profile.Name = "btn_profile";
            btn_profile.Padding = new Padding(20, 0, 0, 0);
            btn_profile.Size = new Size(299, 50);
            btn_profile.TabIndex = 7;
            btn_profile.Text = "Profile";
            btn_profile.TextAlign = ContentAlignment.MiddleLeft;
            btn_profile.UseVisualStyleBackColor = true;
            // 
            // btn_signout
            // 
            btn_signout.Dock = DockStyle.Bottom;
            btn_signout.FlatAppearance.BorderSize = 0;
            btn_signout.FlatStyle = FlatStyle.Flat;
            btn_signout.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_signout.ForeColor = Color.White;
            btn_signout.Location = new Point(0, 631);
            btn_signout.Name = "btn_signout";
            btn_signout.Padding = new Padding(20, 0, 0, 0);
            btn_signout.Size = new Size(299, 50);
            btn_signout.TabIndex = 6;
            btn_signout.Text = "Sign Out";
            btn_signout.TextAlign = ContentAlignment.MiddleLeft;
            btn_signout.UseVisualStyleBackColor = true;
            // 
            // btn_dashboard
            // 
            btn_dashboard.Dock = DockStyle.Top;
            btn_dashboard.FlatAppearance.BorderSize = 0;
            btn_dashboard.FlatStyle = FlatStyle.Flat;
            btn_dashboard.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_dashboard.ForeColor = Color.White;
            btn_dashboard.Location = new Point(0, 0);
            btn_dashboard.Name = "btn_dashboard";
            btn_dashboard.Padding = new Padding(20, 0, 0, 0);
            btn_dashboard.Size = new Size(299, 50);
            btn_dashboard.TabIndex = 5;
            btn_dashboard.Text = "Dashboard";
            btn_dashboard.TextAlign = ContentAlignment.MiddleLeft;
            btn_dashboard.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(853, 197);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(100, 23);
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Location = new Point(413, 136);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(20);
            panel1.Size = new Size(300, 150);
            panel1.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(1184, 681);
            Controls.Add(panelContent);
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
        private Button btn_profile;
        private Button btn_signout;
        private Button btn_dashboard;
    }
}