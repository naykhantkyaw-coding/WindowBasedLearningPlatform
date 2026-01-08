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
            lessonsPanel = new Panel();
            lessonsWebView = new Microsoft.Web.WebView2.WinForms.WebView2();
            menuWebView = new Microsoft.Web.WebView2.WinForms.WebView2();
            menuPanel.SuspendLayout();
            lessonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lessonsWebView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)menuWebView).BeginInit();
            SuspendLayout();
            // 
            // menuPanel
            // 
            menuPanel.BackColor = Color.FromArgb(31, 41, 55);
            menuPanel.Controls.Add(menuWebView);
            menuPanel.Dock = DockStyle.Left;
            menuPanel.Location = new Point(0, 0);
            menuPanel.Name = "menuPanel";
            menuPanel.Size = new Size(219, 908);
            menuPanel.TabIndex = 0;
            // 
            // lessonsPanel
            // 
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
            lessonsWebView.CreationProperties = null;
            lessonsWebView.DefaultBackgroundColor = Color.White;
            lessonsWebView.Dock = DockStyle.Top;
            lessonsWebView.Location = new Point(0, 0);
            lessonsWebView.Name = "lessonsWebView";
            lessonsWebView.Size = new Size(821, 611);
            lessonsWebView.TabIndex = 0;
            lessonsWebView.ZoomFactor = 1D;
            // 
            // menuWebView
            // 
            menuWebView.AllowExternalDrop = true;
            menuWebView.CreationProperties = null;
            menuWebView.DefaultBackgroundColor = Color.White;
            menuWebView.Dock = DockStyle.Fill;
            menuWebView.Location = new Point(0, 0);
            menuWebView.Name = "menuWebView";
            menuWebView.Size = new Size(219, 908);
            menuWebView.TabIndex = 0;
            menuWebView.ZoomFactor = 1D;
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
            ((System.ComponentModel.ISupportInitialize)menuWebView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel menuPanel;
        private Microsoft.Web.WebView2.WinForms.WebView2 menuWebView;
        private Panel lessonsPanel;
        private Microsoft.Web.WebView2.WinForms.WebView2 lessonsWebView;
    }
}
