using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowBasedLearningPlatform.WindowApp.App.UserControls
{
    public partial class UC_LessonViewer : UserControl
    {
        private string _language;
        private UC_CodePlayground _activePlayground;

        public UC_LessonViewer(string language)
        {
            InitializeComponent();
            _language = language;

            // Set dynamic text here since Designer handles static initialization
            _lblListHeader.Text = $"{_language} Lessons";

            LoadLessons();
        }

        private void BtnPractice_Click(object sender, EventArgs e)
        {
            Panel contentPanel = _layoutContainer.Panel2;

            // If playground is already open, close it (toggle)
            if (_activePlayground != null && contentPanel.Controls.Contains(_activePlayground))
            {
                contentPanel.Controls.Remove(_activePlayground);
                _activePlayground = null;
                _contentBrowser.Visible = true; // Show lesson again
                _btnPractice.Text = "💻 Open Code Playground";
            }
            else
            {
                // Open Playground
                _activePlayground = new UC_CodePlayground();
                _activePlayground.Dock = DockStyle.Fill;

                // Hide browser temporarily
                _contentBrowser.Visible = false;

                // Add playground to panel
                contentPanel.Controls.Add(_activePlayground);
                _activePlayground.BringToFront();

                _btnPractice.Text = "⬅ Back to Lesson";
            }
        }

        private void LoadLessons()
        {
            var lessons = new List<(string Title, string Content)>
            {
                ("1. Introduction", "<h1>Introduction</h1><p>Welcome to <b>" + _language + "</b>...</p>"),
                ("2. Variables", "<h1>Variables</h1><p>Variables store data...</p>"),
                ("3. Control Flow", "<h1>Control Flow</h1><p>If/Else statements...</p>"),
                ("4. Functions", "<h1>Functions</h1><p>Reusable blocks of code...</p>")
            };

            int yPos = 50;
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

            // Reset Playground if open when switching lessons
            if (_activePlayground != null)
            {
                // Use the field directly now
                _btnPractice.Text = "💻 Open Code Playground";

                _layoutContainer.Panel2.Controls.Remove(_activePlayground);
                _activePlayground = null;
                _contentBrowser.Visible = true;
            }

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