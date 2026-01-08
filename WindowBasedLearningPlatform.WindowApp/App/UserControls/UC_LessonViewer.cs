using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WindowBasedLearningPlatform.WindowApp.App.UserControls
{
    public partial class UC_LessonViewer : UserControl
    {
        private string _language;
        private SplitContainer _layoutContainer;
        private Label _contentTitle;
        private WebBrowser _contentBrowser;
        // Track the playground control
        private UC_CodePlayground _activePlayground;

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

            _layoutContainer = new SplitContainer();
            _layoutContainer.Dock = DockStyle.Fill;
            _layoutContainer.FixedPanel = FixedPanel.Panel1;
            _layoutContainer.IsSplitterFixed = true;
            _layoutContainer.SplitterDistance = 250;
            _layoutContainer.SplitterWidth = 1;
            //_layoutContainer.Panel1.BackColor = Color.FromArgb(245, 247, 250);
            //_layoutContainer.Panel2.BackColor = Color.White;

            this.Controls.Add(_layoutContainer);

            // --- Sidebar (Panel1) ---
            Panel sidebarPanel = _layoutContainer.Panel1;
            sidebarPanel.Padding = new Padding(10);

            Label lblListHeader = new Label();
            lblListHeader.Text = $"{_language} Lessons";
            lblListHeader.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblListHeader.ForeColor = Color.FromArgb(64, 64, 64);
            lblListHeader.Dock = DockStyle.Top;
            lblListHeader.Height = 40;
            sidebarPanel.Controls.Add(lblListHeader);

            // --- Content Area (Panel2) ---
            Panel contentPanel = _layoutContainer.Panel2;
            contentPanel.Padding = new Padding(30);

            // 1. Header Title
            _contentTitle = new Label();
            _contentTitle.Text = "Select a lesson to start";
            _contentTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            _contentTitle.ForeColor = Color.FromArgb(33, 33, 33);
            _contentTitle.Dock = DockStyle.Top;
            _contentTitle.Height = 50;
            contentPanel.Controls.Add(_contentTitle);

            // 2. Practice Button (New!)
            // We add it to the top (under title) or bottom. Let's put it at the bottom of the content panel
            // so it's always accessible.
            Button btnPractice = new Button();
            btnPractice.Text = "💻 Open Code Playground";
            btnPractice.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnPractice.BackColor = ColorTranslator.FromHtml("#fdd23f"); // Brand Yellow
            btnPractice.ForeColor = Color.Black;
            btnPractice.FlatStyle = FlatStyle.Flat;
            btnPractice.FlatAppearance.BorderSize = 0;
            btnPractice.Height = 40;
            btnPractice.Dock = DockStyle.Bottom;
            btnPractice.Cursor = Cursors.Hand;
            btnPractice.Click += BtnPractice_Click;
            contentPanel.Controls.Add(btnPractice);

            // 3. Browser (Fills the middle)
            _contentBrowser = new WebBrowser();
            _contentBrowser.Dock = DockStyle.Fill;
            _contentBrowser.IsWebBrowserContextMenuEnabled = false;
            contentPanel.Controls.Add(_contentBrowser);
            _contentBrowser.BringToFront();
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
                ((Button)sender).Text = "💻 Open Code Playground";
            }
            else
            {
                // Open Playground
                _activePlayground = new UC_CodePlayground();
                _activePlayground.Dock = DockStyle.Fill;

                // Hide browser temporarily
                _contentBrowser.Visible = false;

                // Add playground to panel (it will fill the space between title and button)
                contentPanel.Controls.Add(_activePlayground);
                _activePlayground.BringToFront();

                ((Button)sender).Text = "⬅ Back to Lesson";
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
            // If playground is open, close it when switching lessons? 
            // Optional: for now let's keep it if open, or reset. 
            // Let's reset to show the new lesson content.
            if (_activePlayground != null)
            {
                // Find the practice button to reset text
                foreach (Control c in _layoutContainer.Panel2.Controls)
                {
                    if (c is Button b && b.Text.Contains("Back")) b.Text = "💻 Open Code Playground";
                }

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