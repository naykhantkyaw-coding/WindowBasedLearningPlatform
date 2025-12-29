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
            panelSidebar = new Panel();
            btn_profile = new Button();
            btn_signout = new Button();
            btn_dashboard = new Button();
            lbl_CodeLearn = new Label();
            panelHeader = new Panel();
            panelContent = new Panel();
            progressBar1 = new ProgressBar();
            panel1 = new Panel();
            btn_Courses = new Button();
            panelSidebar.SuspendLayout();
            panelContent.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(50, 50, 70);
            panelSidebar.Controls.Add(btn_Courses);
            panelSidebar.Controls.Add(btn_profile);
            panelSidebar.Controls.Add(btn_signout);
            panelSidebar.Controls.Add(btn_dashboard);
            panelSidebar.Controls.Add(lbl_CodeLearn);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Margin = new Padding(3, 4, 3, 4);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(286, 908);
            panelSidebar.TabIndex = 0;
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
            btn_profile.Size = new Size(250, 50);
            btn_profile.TabIndex = 3;
            btn_profile.Text = "Profile";
            btn_profile.TextAlign = ContentAlignment.MiddleLeft;
            btn_profile.UseVisualStyleBackColor = true;
            btn_profile.Click += btn_profile_Click;
            // 
            // btn_signout
            // 
            btn_signout.Dock = DockStyle.Bottom;
            btn_signout.FlatAppearance.BorderSize = 0;
            btn_signout.FlatStyle = FlatStyle.Flat;
            btn_signout.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_signout.ForeColor = Color.White;
            btn_signout.Location = new Point(0, 841);
            btn_signout.Margin = new Padding(3, 4, 3, 4);
            btn_signout.Name = "btn_signout";
            btn_signout.Padding = new Padding(23, 0, 0, 0);
            btn_signout.Size = new Size(286, 67);
            btn_signout.TabIndex = 2;
            btn_signout.Text = "Sign Out";
            btn_signout.TextAlign = ContentAlignment.MiddleLeft;
            btn_signout.UseVisualStyleBackColor = true;
            btn_signout.Click += btn_signout_Click;
            // 
            // btn_dashboard
            // 
            btn_dashboard.Dock = DockStyle.Top;
            btn_dashboard.FlatAppearance.BorderSize = 0;
            btn_dashboard.FlatStyle = FlatStyle.Flat;
            btn_dashboard.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_dashboard.ForeColor = Color.White;
            btn_dashboard.Location = new Point(0, 0);
            btn_dashboard.Margin = new Padding(3, 4, 3, 4);
            btn_dashboard.Name = "btn_dashboard";
            btn_dashboard.Padding = new Padding(23, 0, 0, 0);
            btn_dashboard.Size = new Size(286, 67);
            btn_dashboard.TabIndex = 1;
            btn_dashboard.Text = "Dashboard";
            btn_dashboard.TextAlign = ContentAlignment.MiddleLeft;
            btn_dashboard.UseVisualStyleBackColor = true;
            btn_dashboard.Click += btn_dashboard_Click;
            // 
            // lbl_CodeLearn
            // 
            lbl_CodeLearn.AutoSize = true;
            lbl_CodeLearn.BackColor = Color.Transparent;
            lbl_CodeLearn.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_CodeLearn.ForeColor = Color.White;
            lbl_CodeLearn.Location = new Point(29, 743);
            lbl_CodeLearn.Name = "lbl_CodeLearn";
            lbl_CodeLearn.Padding = new Padding(23, 27, 0, 0);
            lbl_CodeLearn.Size = new Size(190, 68);
            lbl_CodeLearn.TabIndex = 0;
            lbl_CodeLearn.Text = "CodeLearn";
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.White;
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(286, 0);
            panelHeader.Margin = new Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1067, 80);
            panelHeader.TabIndex = 1;
            // 
            // panelContent
            // 
            panelContent.Controls.Add(progressBar1);
            panelContent.Controls.Add(panel1);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(286, 80);
            panelContent.Margin = new Padding(3, 4, 3, 4);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1067, 828);
            panelContent.TabIndex = 2;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(635, 47);
            progressBar1.Margin = new Padding(3, 4, 3, 4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(114, 31);
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Location = new Point(102, 119);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(23, 27, 23, 27);
            panel1.Size = new Size(343, 200);
            panel1.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(1353, 908);
            Controls.Add(panelContent);
            Controls.Add(panelHeader);
            Controls.Add(panelSidebar);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panelSidebar.ResumeLayout(false);
            panelSidebar.PerformLayout();
            panelContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSidebar;
        private Label lbl_CodeLearn;
        private Panel panelHeader;
        private Panel panelContent;
        private Button btn_dashboard;
        private ProgressBar progressBar1;
        private Panel panel1;
        private Button btn_signout;
        private Button btn_profile;
        private Button btn_Courses;
    }
}