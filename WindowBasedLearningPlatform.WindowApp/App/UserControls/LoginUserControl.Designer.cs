namespace WindowBasedLearningPlatform.WindowApp.App.UserControls
{
    partial class LoginUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            loginPanel = new Panel();
            label5 = new Label();
            panelButton = new WindowBasedLearningPlatform.WindowApp.App.UI_Elements.HorizentalGradientPanelHelper();
            btnLogin = new Button();
            label4 = new Label();
            label3 = new Label();
            panelPassword = new Panel();
            txtPassword = new TextBox();
            panelUserName = new Panel();
            txtUserName = new TextBox();
            label2 = new Label();
            label1 = new Label();
            iconPanel = new GradientPanel();
            iconLabel = new Label();
            loginPanel.SuspendLayout();
            panelButton.SuspendLayout();
            panelPassword.SuspendLayout();
            panelUserName.SuspendLayout();
            iconPanel.SuspendLayout();
            SuspendLayout();
            // 
            // loginPanel
            // 
            loginPanel.Anchor = AnchorStyles.None;
            loginPanel.BackColor = Color.FromArgb(31, 41, 55);
            loginPanel.Controls.Add(label5);
            loginPanel.Controls.Add(panelButton);
            loginPanel.Controls.Add(label4);
            loginPanel.Controls.Add(label3);
            loginPanel.Controls.Add(panelPassword);
            loginPanel.Controls.Add(panelUserName);
            loginPanel.Controls.Add(label2);
            loginPanel.Controls.Add(label1);
            loginPanel.Controls.Add(iconPanel);
            loginPanel.Location = new Point(287, 132);
            loginPanel.Name = "loginPanel";
            loginPanel.Size = new Size(420, 480);
            loginPanel.TabIndex = 0;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlDarkDark;
            label5.Location = new Point(132, 440);
            label5.Name = "label5";
            label5.Size = new Size(167, 20);
            label5.TabIndex = 8;
            label5.Text = "Group-4 Project © 2026";
            // 
            // panelButton
            // 
            panelButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelButton.ColorBottom = Color.FromArgb(147, 51, 234);
            panelButton.ColorTop = Color.FromArgb(219, 39, 119);
            panelButton.Controls.Add(btnLogin);
            panelButton.Location = new Point(29, 379);
            panelButton.Name = "panelButton";
            panelButton.Size = new Size(368, 44);
            panelButton.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(3, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(359, 36);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(29, 286);
            label4.Name = "label4";
            label4.Size = new Size(80, 23);
            label4.TabIndex = 7;
            label4.Text = "Password";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(26, 200);
            label3.Name = "label3";
            label3.Size = new Size(95, 23);
            label3.TabIndex = 6;
            label3.Text = "User Name";
            // 
            // panelPassword
            // 
            panelPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelPassword.BackColor = Color.FromArgb(17, 24, 39);
            panelPassword.Controls.Add(txtPassword);
            panelPassword.Location = new Point(26, 312);
            panelPassword.Name = "panelPassword";
            panelPassword.Size = new Size(368, 44);
            panelPassword.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = Color.White;
            txtPassword.Location = new Point(3, 10);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(362, 24);
            txtPassword.TabIndex = 0;
            // 
            // panelUserName
            // 
            panelUserName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelUserName.BackColor = Color.FromArgb(17, 24, 39);
            panelUserName.Controls.Add(txtUserName);
            panelUserName.Location = new Point(26, 226);
            panelUserName.Name = "panelUserName";
            panelUserName.Size = new Size(368, 44);
            panelUserName.TabIndex = 4;
            // 
            // txtUserName
            // 
            txtUserName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtUserName.BorderStyle = BorderStyle.None;
            txtUserName.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtUserName.ForeColor = Color.White;
            txtUserName.Location = new Point(3, 10);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(362, 24);
            txtUserName.TabIndex = 0;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(100, 162);
            label2.Name = "label2";
            label2.Size = new Size(216, 23);
            label2.TabIndex = 3;
            label2.Text = "Windows Desktop Platform";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(134, 124);
            label1.Name = "label1";
            label1.Size = new Size(156, 38);
            label1.TabIndex = 2;
            label1.Text = "User Login";
            // 
            // iconPanel
            // 
            iconPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            iconPanel.ColorBottom = Color.FromArgb(147, 51, 234);
            iconPanel.ColorTop = Color.FromArgb(219, 39, 119);
            iconPanel.Controls.Add(iconLabel);
            iconPanel.Location = new Point(167, 29);
            iconPanel.Name = "iconPanel";
            iconPanel.Size = new Size(80, 80);
            iconPanel.TabIndex = 1;
            // 
            // iconLabel
            // 
            iconLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            iconLabel.AutoSize = true;
            iconLabel.Font = new Font("Segoe UI", 20F);
            iconLabel.ForeColor = Color.White;
            iconLabel.Location = new Point(7, 17);
            iconLabel.Name = "iconLabel";
            iconLabel.Size = new Size(67, 46);
            iconLabel.TabIndex = 2;
            iconLabel.Text = "🎓";
            // 
            // LoginUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 23, 42);
            Controls.Add(loginPanel);
            Name = "LoginUserControl";
            Size = new Size(1067, 828);
            loginPanel.ResumeLayout(false);
            loginPanel.PerformLayout();
            panelButton.ResumeLayout(false);
            panelPassword.ResumeLayout(false);
            panelPassword.PerformLayout();
            panelUserName.ResumeLayout(false);
            panelUserName.PerformLayout();
            iconPanel.ResumeLayout(false);
            iconPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel loginPanel;
        private GradientPanel iconPanel;
        private Label iconLabel;
        private Label label1;
        private Label label2;
        private Panel panelUserName;
        private TextBox txtUserName;
        private Panel panelPassword;
        private TextBox txtPassword;
        private Label label4;
        private Label label3;
        private UI_Elements.HorizentalGradientPanelHelper panelButton;
        private Button btnLogin;
        private Label label5;
    }
}
