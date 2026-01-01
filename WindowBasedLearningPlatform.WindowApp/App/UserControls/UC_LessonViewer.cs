using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WindowBasedLearningPlatform.WindowApp.App.UserControls
{
    public partial class UC_LessonViewer : UserControl
    {
        private string _language;
        // Using SplitContainer is the best way to prevent overlap
        private SplitContainer _layoutContainer;
        private Label _contentTitle;
        private WebBrowser _contentBrowser;

        public UC_LessonViewer(string language)
        {
            InitializeComponent();
            _language = language;
            SetupUI();
            LoadLessons();
        }

        private void SetupUI()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;

            // 1. Initialize SplitContainer
            // This creates a physical separation between Sidebar and Content
            _layoutContainer = new SplitContainer();
            _layoutContainer.Dock = DockStyle.Fill;
            _layoutContainer.FixedPanel = FixedPanel.Panel1; // Keep sidebar width fixed
            _layoutContainer.IsSplitterFixed = true;         // Optional: Prevent resizing
            _layoutContainer.SplitterDistance = 250;         // Width of sidebar
            _layoutContainer.SplitterWidth = 1;              // Minimal visual divider
            _layoutContainer.Panel1.BackColor = Color.FromArgb(245, 247, 250); // Sidebar Color
            _layoutContainer.Panel2.BackColor = Color.White; // Content Color

            this.Controls.Add(_layoutContainer);

            // 2. Setup Sidebar (Panel1)
            Panel sidebarPanel = _layoutContainer.Panel1;
            sidebarPanel.Padding = new Padding(10);

            // Sidebar Header
            Label lblListHeader = new Label();
            lblListHeader.Text = $"{_language} Lessons";
            lblListHeader.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblListHeader.ForeColor = Color.FromArgb(64, 64, 64);
            lblListHeader.Dock = DockStyle.Top;
            lblListHeader.Height = 40;
            sidebarPanel.Controls.Add(lblListHeader);

            // 3. Setup Content Area (Panel2)
            Panel contentPanel = _layoutContainer.Panel2;
            contentPanel.Padding = new Padding(30);

            // Content Title
            _contentTitle = new Label();
            _contentTitle.Text = "Select a lesson to start";
            _contentTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            _contentTitle.ForeColor = Color.FromArgb(33, 33, 33);
            _contentTitle.Dock = DockStyle.Top;
            _contentTitle.Height = 50;
            contentPanel.Controls.Add(_contentTitle);

            // Content Browser
            _contentBrowser = new WebBrowser();
            _contentBrowser.Dock = DockStyle.Fill;
            _contentBrowser.IsWebBrowserContextMenuEnabled = false;
            contentPanel.Controls.Add(_contentBrowser);
            _contentBrowser.BringToFront();
        }

        private void LoadLessons()
        {
            // Mock Data
            var lessons = new List<(string Title, string Content)>
            {
                ("1. Introduction", "<h1>Introduction</h1><p>Welcome to <b>" + _language + "</b>. It is a powerful language...</p>"),
                ("2. Variables", "<h1>Variables</h1><p>Variables store data...</p>"),
                ("3. Control Flow", "<h1>Control Flow</h1><p>If/Else statements...</p>"),
                ("4. Functions", "<h1>Functions</h1><p>Reusable blocks of code...</p>")
            };

            int yPos = 50;
            // Important: Add buttons to the SplitContainer's Panel1 (Sidebar)
            Panel sidebarPanel = _layoutContainer.Panel1;

            foreach (var lesson in lessons)
            {
                Button btnLesson = new Button();
                btnLesson.Text = lesson.Title;
                btnLesson.TextAlign = ContentAlignment.MiddleLeft;
                btnLesson.FlatStyle = FlatStyle.Flat;
                btnLesson.FlatAppearance.BorderSize = 0;
                btnLesson.BackColor = Color.Transparent;
                btnLesson.Font = new Font("Segoe UI", 10);
                btnLesson.ForeColor = Color.FromArgb(64, 64, 64);
                btnLesson.Size = new Size(230, 40);
                btnLesson.Location = new Point(10, yPos);
                btnLesson.Cursor = Cursors.Hand;

                btnLesson.Click += (s, e) => DisplayLesson(lesson.Title, lesson.Content);

                sidebarPanel.Controls.Add(btnLesson);
                yPos += 45;
            }

            if (lessons.Count > 0) DisplayLesson(lessons[0].Title, lessons[0].Content);
        }

        private void DisplayLesson(string title, string htmlContent)
        {
            _contentTitle.Text = title;
            string styledHtml = $@"
                <html>
                <body style='font-family: Segoe UI, sans-serif; color: #333; padding: 10px; margin: 0;'>
                    {htmlContent}
                </body>
                </html>";
            _contentBrowser.DocumentText = styledHtml;
        }
    }
}