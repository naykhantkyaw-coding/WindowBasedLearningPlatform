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
            iconPanel = new Panel();
            iconLabel = new Label();
            loginPanel.SuspendLayout();
            iconPanel.SuspendLayout();
            SuspendLayout();
            // 
            // loginPanel
            // 
            loginPanel.Anchor = AnchorStyles.None;
            loginPanel.BackColor = Color.FromArgb(31, 41, 55);
            loginPanel.Controls.Add(iconPanel);
            loginPanel.Location = new Point(300, 151);
            loginPanel.Name = "loginPanel";
            loginPanel.Size = new Size(420, 480);
            loginPanel.TabIndex = 0;
            // 
            // iconPanel
            // 
            iconPanel.BackColor = Color.FromArgb(147, 51, 234);
            iconPanel.Controls.Add(iconLabel);
            iconPanel.Location = new Point(166, 34);
            iconPanel.Name = "iconPanel";
            iconPanel.Size = new Size(80, 80);
            iconPanel.TabIndex = 0;
            iconPanel.Paint += iconPanel_Paint;
            // 
            // iconLabel
            // 
            iconLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            iconLabel.AutoSize = true;
            iconLabel.Font = new Font("Segoe UI", 32F);
            iconLabel.ForeColor = Color.White;
            iconLabel.Location = new Point(-10, 1);
            iconLabel.Name = "iconLabel";
            iconLabel.Size = new Size(104, 72);
            iconLabel.TabIndex = 0;
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
            iconPanel.ResumeLayout(false);
            iconPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel loginPanel;
        private Panel iconPanel;
        private Label iconLabel;
    }
}
