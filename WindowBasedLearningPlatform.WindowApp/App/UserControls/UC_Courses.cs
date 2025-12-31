using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WindowBasedLearningPlatform.WindowApp.App
{
    public partial class UC_Courses : UserControl
    {
        // 1. DEFINE THE EVENT
        // This event sends a string (the language name) back to MainForm
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
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.Padding = new Padding(30);

            // Header
            Label lblTitle = new Label();
            lblTitle.Text = "Available Courses";
            lblTitle.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(64, 64, 64);
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Height = 60;
            this.Controls.Add(lblTitle);

            // Course Container
            FlowLayoutPanel panelCourses = new FlowLayoutPanel();
            panelCourses.Dock = DockStyle.Fill;
            panelCourses.AutoScroll = true;
            panelCourses.FlowDirection = FlowDirection.LeftToRight;
            panelCourses.WrapContents = true;
            panelCourses.Name = "panelCourses";
            this.Controls.Add(panelCourses);
            panelCourses.BringToFront();
        }

        private void LoadCourses()
        {
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

            // Icon
            Label lblIcon = new Label();
            lblIcon.Text = iconText;
            lblIcon.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblIcon.ForeColor = Color.White;
            lblIcon.TextAlign = ContentAlignment.MiddleCenter;
            lblIcon.Size = new Size(50, 50);
            lblIcon.Location = new Point(20, 20);

            if (title == "C#") lblIcon.BackColor = Color.FromArgb(104, 33, 122);
            else if (title == "Python") lblIcon.BackColor = Color.FromArgb(55, 118, 171);
            else lblIcon.BackColor = Color.FromArgb(231, 111, 0);

            card.Controls.Add(lblIcon);

            // Title
            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 33, 33);
            lblTitle.Location = new Point(80, 25);
            lblTitle.AutoSize = true;
            card.Controls.Add(lblTitle);

            // Description
            Label lblDesc = new Label();
            lblDesc.Text = description;
            lblDesc.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblDesc.ForeColor = Color.Gray;
            lblDesc.Location = new Point(20, 80);
            lblDesc.Size = new Size(260, 40);
            card.Controls.Add(lblDesc);

            // Start Button
            Button btnStart = new Button();
            btnStart.Text = "Start Learning";
            btnStart.BackColor = ColorTranslator.FromHtml("#fdd23f");
            btnStart.ForeColor = Color.Black;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnStart.Size = new Size(120, 35);
            btnStart.Location = new Point(20, 130);
            btnStart.Cursor = Cursors.Hand;

            // 2. FIRE THE EVENT ON CLICK
            // When clicked, we invoke 'CourseSelected' and pass the 'title' (e.g. "C#")
            btnStart.Click += (s, e) => CourseSelected?.Invoke(this, title);

            card.Controls.Add(btnStart);
            parent.Controls.Add(card);
        }
    }
}