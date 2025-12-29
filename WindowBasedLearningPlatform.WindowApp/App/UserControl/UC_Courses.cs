using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WindowBasedLearningPlatform.WindowApp.App
{
    public partial class UC_Courses : UserControl
    {
        // Event to notify MainForm when a course is selected
        // We pass the "Language" name (e.g., "C#") back to the main form
        public event EventHandler<string> CourseSelected;

        public UC_Courses()
        {
            InitializeComponent();
            SetupUI();
            LoadCourses();
        }

        private void SetupUI()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(245, 247, 250); // Light Grey
            this.Padding = new Padding(30);

            // 1. Header
            Label lblTitle = new Label();
            lblTitle.Text = "Available Courses";
            lblTitle.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(64, 64, 64);
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Height = 60;
            this.Controls.Add(lblTitle);

            // 2. Course Container (Flow Layout)
            FlowLayoutPanel panelCourses = new FlowLayoutPanel();
            panelCourses.Dock = DockStyle.Fill;
            panelCourses.AutoScroll = true;
            panelCourses.FlowDirection = FlowDirection.LeftToRight;
            panelCourses.WrapContents = true;
            // Name it so we can find it later if needed
            panelCourses.Name = "panelCourses";
            this.Controls.Add(panelCourses);
            panelCourses.BringToFront();
        }

        private void LoadCourses()
        {
            // In a real app, you would fetch: SELECT DISTINCT LanguageType FROM Tbl_CourseLesson
            // For now, we mock the available courses.

            var courses = new List<(string Name, string Description, string Icon)>
            {
                ("C#", "Master Windows development with C# and .NET.", "CS"),
                ("Python", "Learn data science and automation with Python.", "PY"),
                ("Java", "Build robust enterprise applications with Java.", "JV")
            };

            Control? container = this.Controls.Find("panelCourses", true).FirstOrDefault();
            if (container is FlowLayoutPanel panel)
            {
                panel.Controls.Clear();
                foreach (var course in courses)
                {
                    AddCourseCard(panel, course.Name, course.Description, course.Icon);
                }
            }
        }

        private void AddCourseCard(FlowLayoutPanel parent, string title, string description, string iconText)
        {
            Panel card = new Panel();
            card.Size = new Size(300, 180);
            card.BackColor = Color.White;
            card.Margin = new Padding(0, 0, 20, 20);

            // 1. Icon Box (Colored Square with Initials)
            Label lblIcon = new Label();
            lblIcon.Text = iconText;
            lblIcon.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblIcon.ForeColor = Color.White;
            lblIcon.TextAlign = ContentAlignment.MiddleCenter;
            lblIcon.Size = new Size(50, 50);
            lblIcon.Location = new Point(20, 20);

            // Assign specific colors based on language
            if (title == "C#") lblIcon.BackColor = Color.FromArgb(104, 33, 122); // Purple
            else if (title == "Python") lblIcon.BackColor = Color.FromArgb(55, 118, 171); // Blue
            else lblIcon.BackColor = Color.FromArgb(231, 111, 0); // Orange (Java)

            card.Controls.Add(lblIcon);

            // 2. Title
            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 33, 33);
            lblTitle.Location = new Point(80, 25);
            lblTitle.AutoSize = true;
            card.Controls.Add(lblTitle);

            // 3. Description
            Label lblDesc = new Label();
            lblDesc.Text = description;
            lblDesc.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblDesc.ForeColor = Color.Gray;
            lblDesc.Location = new Point(20, 80);
            lblDesc.Size = new Size(260, 40); // Fixed size for wrapping
            card.Controls.Add(lblDesc);

            // 4. Start Button
            Button btnStart = new Button();
            btnStart.Text = "Start Learning";
            btnStart.BackColor = ColorTranslator.FromHtml("#fdd23f"); // Brand Yellow
            btnStart.ForeColor = Color.Black;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnStart.Size = new Size(120, 35);
            btnStart.Location = new Point(20, 130);
            btnStart.Cursor = Cursors.Hand;

            // Event: Click triggers the custom event
            btnStart.Click += (s, e) => CourseSelected?.Invoke(this, title);

            card.Controls.Add(btnStart);

            parent.Controls.Add(card);
        }
    }
}
