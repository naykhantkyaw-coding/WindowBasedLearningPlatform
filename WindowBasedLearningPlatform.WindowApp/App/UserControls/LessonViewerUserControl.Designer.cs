namespace WindowBasedLearningPlatform.WindowApp.App.UserControls
{
    partial class LessonViewerUserControl
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
            menuPanel = new Panel();
            btn_menuTitle = new Button();
            lessonsPanel = new Panel();
            lessonsWebView = new Microsoft.Web.WebView2.WinForms.WebView2();
            titlepanel = new Panel();
            menuPanel.SuspendLayout();
            lessonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lessonsWebView).BeginInit();
            SuspendLayout();
            // 
            // menuPanel
            // 
            menuPanel.BackColor = Color.FromArgb(31, 41, 55);
            menuPanel.Controls.Add(btn_menuTitle);
            menuPanel.Dock = DockStyle.Left;
            menuPanel.Location = new Point(0, 0);
            menuPanel.Name = "menuPanel";
            menuPanel.Size = new Size(219, 908);
            menuPanel.TabIndex = 0;
            // 
            // btn_menuTitle
            // 
            btn_menuTitle.BackColor = Color.Transparent;
            btn_menuTitle.Dock = DockStyle.Top;
            btn_menuTitle.FlatStyle = FlatStyle.Flat;
            btn_menuTitle.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_menuTitle.ForeColor = Color.White;
            btn_menuTitle.ImageAlign = ContentAlignment.MiddleLeft;
            btn_menuTitle.Location = new Point(0, 0);
            btn_menuTitle.Name = "btn_menuTitle";
            btn_menuTitle.Size = new Size(219, 77);
            btn_menuTitle.TabIndex = 16;
            btn_menuTitle.UseVisualStyleBackColor = false;
            // 
            // lessonsPanel
            // 
            lessonsPanel.Controls.Add(titlepanel);
            lessonsPanel.Controls.Add(lessonsWebView);
            lessonsPanel.Dock = DockStyle.Left;
            lessonsPanel.Location = new Point(219, 0);
            lessonsPanel.Name = "lessonsPanel";
            lessonsPanel.Size = new Size(821, 908);
            lessonsPanel.TabIndex = 1;
            // 
            // lessonsWebView
            // 
            lessonsWebView.AllowExternalDrop = true;
            lessonsWebView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lessonsWebView.CreationProperties = null;
            lessonsWebView.DefaultBackgroundColor = Color.White;
            lessonsWebView.Location = new Point(3, 83);
            lessonsWebView.Name = "lessonsWebView";
            lessonsWebView.Size = new Size(812, 611);
            lessonsWebView.TabIndex = 0;
            lessonsWebView.ZoomFactor = 1D;
            // 
            // titlepanel
            // 
            titlepanel.Dock = DockStyle.Top;
            titlepanel.Location = new Point(0, 0);
            titlepanel.Name = "titlepanel";
            titlepanel.Size = new Size(821, 74);
            titlepanel.TabIndex = 1;
            // 
            // LessonViewerUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 23, 42);
            Controls.Add(lessonsPanel);
            Controls.Add(menuPanel);
            Name = "LessonViewerUserControl";
            Size = new Size(1046, 908);
            menuPanel.ResumeLayout(false);
            lessonsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)lessonsWebView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel menuPanel;
        private Panel lessonsPanel;
        private Microsoft.Web.WebView2.WinForms.WebView2 lessonsWebView;
        private Button btn_menuTitle;
        private Panel titlepanel;
    }
}
