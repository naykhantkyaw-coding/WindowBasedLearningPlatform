using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowBasedLearningPlatform.WindowApp.App
{
    public partial class MainForm : Form
    {
        // Store the logged-in user ID so we can track who is using the app
        private int _currentStudentId;

        public MainForm()
        {
            InitializeComponent();

            // Sidebar Gradient Logic
            Control? sidebar = this.Controls.Find("panelSidebar", true).FirstOrDefault();
            if (sidebar is Panel p)
            {
                p.Paint += Sidebar_Paint;
                p.Resize += (s, e) => p.Invalidate();
            }

            ShowLogin();
        }

        private void Sidebar_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Panel panel)
            {
                Color colorTop = ColorTranslator.FromHtml("#323246");
                Color colorBottom = ColorTranslator.FromHtml("#141423");

                using (LinearGradientBrush brush = new LinearGradientBrush(panel.ClientRectangle, colorTop, colorBottom, 90F))
                {
                    e.Graphics.FillRectangle(brush, panel.ClientRectangle);
                }
            }
        }

        private void ShowLogin()
        {
            Control? contentPanel = this.Controls.Find("panelContent", true).FirstOrDefault();
            Control? sidebar = this.Controls.Find("panelSidebar", true).FirstOrDefault();

            if (sidebar != null) sidebar.Visible = false;

            if (contentPanel != null)
            {
                contentPanel.Controls.Clear();
                UC_Login loginPage = new UC_Login();
                loginPage.LoginSuccess += OnLoginSuccess;
                loginPage.Dock = DockStyle.Fill;
                contentPanel.Controls.Add(loginPage);
            }
        }

        private void OnLoginSuccess(object? sender, int studentId)
        {
            _currentStudentId = studentId;
            Control? sidebar = this.Controls.Find("panelSidebar", true).FirstOrDefault();
            if (sidebar != null) sidebar.Visible = true;

            // Load Dashboard using the new helper method to ensure buttons work
            ShowDashboard();
        }

        // --- NEW HELPER: Creates Dashboard and Connects Events ---
        private void ShowDashboard()
        {
            UC_Dashboard dashboard = new UC_Dashboard();

            // 1. Connect "View Profile" button to the Profile Page
            dashboard.RequestOpenProfile += (s, e) => ShowPage(new UC_Profile(_currentStudentId));

            // 2. Connect "Resume Learning" button to the Courses logic
            dashboard.RequestOpenCourses += (s, e) => btn_courses_Click(s, e);

            ShowPage(dashboard);
        }

        private void ShowPage(UserControl page)
        {
            Control? contentPanel = this.Controls.Find("panelContent", true).FirstOrDefault();
            if (contentPanel != null)
            {
                contentPanel.Controls.Clear();
                page.Dock = DockStyle.Fill;
                contentPanel.Controls.Add(page);
                page.BringToFront();
            }
        }

        // --- Event Handlers ---

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            ShowDashboard(); // Use the helper here too!
        }

        private void btn_courses_Click(object? sender, EventArgs e) // Made sender nullable to be safe
        {
            // 1. Create the Courses Page
            UC_Courses coursesPage = new UC_Courses();

            // 2. Listen for selection (Placeholder logic for now)
            coursesPage.CourseSelected += (s, languageName) =>
            {
                MessageBox.Show($"Starting {languageName} lessons... (Lesson Viewer coming next!)");
            };

            // 3. Show the page
            ShowPage(coursesPage);
        }

        private void btn_profile_Click(object sender, EventArgs e)
        {
            ShowPage(new UC_Profile(_currentStudentId));
        }

        private void btn_signout_Click(object sender, EventArgs e)
        {
            _currentStudentId = 0;
            ShowLogin();
        }
    }
}