using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WindowBasedLearningPlatform.WindowApp.App
{
    public partial class UC_LessonViewer : UserControl
    {
        private string _language;
        private Panel _lessonListPanel;
        private Panel _contentPanel;
        private Label _contentTitle;
        private WebBrowser _contentBrowser; // Using WebBrowser for rich HTML content

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

            // 1. Sidebar for Lesson List (Left)
            _lessonListPanel = new Panel();
            _lessonListPanel.Dock = DockStyle.Left;
            _lessonListPanel.Width = 250;
           // _lessonListPanel.BackColor = Color.FromArgb(245, 247, 250);
            _lessonListPanel.Padding = new Padding(10);
            this.Controls.Add(_lessonListPanel);

            // Header for Sidebar
            Label lblListHeader = new Label();
            lblListHeader.Text = $"{_language} Lessons";
            lblListHeader.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblListHeader.ForeColor = Color.FromArgb(64, 64, 64);
            lblListHeader.Dock = DockStyle.Top;
            lblListHeader.Height = 40;
            _lessonListPanel.Controls.Add(lblListHeader);

            // 2. Main Content Area (Fill)
            _contentPanel = new Panel();
            _contentPanel.Dock = DockStyle.Fill;
            _contentPanel.Padding = new Padding(30);
            this.Controls.Add(_contentPanel);

            // Content Title
            _contentTitle = new Label();
            _contentTitle.Text = "Select a lesson to start";
            _contentTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            _contentTitle.ForeColor = Color.FromArgb(33, 33, 33);
            _contentTitle.Dock = DockStyle.Top;
            _contentTitle.Height = 50;
            _contentPanel.Controls.Add(_contentTitle);

            // Content Browser (for Code blocks and formatted text)
            _contentBrowser = new WebBrowser();
            _contentBrowser.Dock = DockStyle.Fill;
            _contentBrowser.IsWebBrowserContextMenuEnabled = false;
            _contentPanel.Controls.Add(_contentBrowser);
            _contentPanel.BringToFront();
        }

        private void LoadLessons()
        {
            // Mock Data - In real app, fetch from Tbl_CourseLesson where LanguageType = _language
            var lessons = new List<(string Title, string Content)>
            {
                ("1. Introduction", "<h1>Introduction</h1><p>Welcome to <b>" + _language + "</b>. It is a powerful language...</p>"),
                ("2. Variables", "<h1>Variables</h1><p>Variables store data...</p><pre style='background:#eee;padding:10px'>int x = 5;</pre>"),
                ("3. Control Flow", "<h1>Control Flow</h1><p>If/Else statements allow you to make decisions...</p>")
            };

            // Create buttons for each lesson
            int yPos = 50; // Start below header
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

                // Load content on click
                btnLesson.Click += (s, e) => DisplayLesson(lesson.Title, lesson.Content);

                _lessonListPanel.Controls.Add(btnLesson);
                yPos += 45;
            }

            // Auto-load first lesson
            if (lessons.Count > 0) DisplayLesson(lessons[0].Title, lessons[0].Content);
        }

        private void DisplayLesson(string title, string htmlContent)
        {
            _contentTitle.Text = title;
            // Add some basic styling to the HTML
            string styledHtml = $@"
                <html>
                <body style='font-family: Segoe UI, sans-serif; color: #333; padding: 10px;'>
                    {htmlContent}
                </body>
                </html>";
            _contentBrowser.DocumentText = styledHtml;
        }
    }
}