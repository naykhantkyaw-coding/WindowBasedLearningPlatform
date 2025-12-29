using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowBasedLearningPlatform.WindowApp.App.UserControls;

namespace WindowBasedLearningPlatform.WindowApp.App
{
    public partial class MainForm : Form
    {
        private int _currentStudentId;

        public MainForm()
        {
            InitializeComponent();

            // --- FIX FOR GRADIENT SIDEBAR ---
            // 1. Enable double buffering to prevent flicker
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            // 2. Find the sidebar (It might be null if not initialized yet, but InitComponent handles it)
            Control? sidebar = this.Controls.Find("panelSidebar", true).FirstOrDefault();

            // 3. Force a repaint if it exists
            if (sidebar != null)
            {
                sidebar.Invalidate();
            }

            // Start at Login Screen
            ShowLogin();
        }

        // --- NAVIGATION HELPERS ---

        private void ShowLogin()
        {
            Control? contentPanel = this.Controls.Find("panelContent", true).FirstOrDefault();
            Control? sidebar = this.Controls.Find("panelSidebar", true).FirstOrDefault();
            Control? headerPanal = this.Controls.Find("panelHeader", true).FirstOrDefault();

            // Hide sidebar during login
            if (sidebar != null) sidebar.Visible = false;
            if(headerPanal != null) headerPanal.Visible = false;
            if (contentPanel != null)
            {
                contentPanel.Controls.Clear();
                //UC_Login loginPage = new UC_Login();
                LoginUserControl loginPage = new LoginUserControl();
               // loginPage.LoginSuccess += OnLoginSuccess;
                loginPage.Dock = DockStyle.Fill;
                contentPanel.Controls.Add(loginPage);
            }
        }

        private void OnLoginSuccess(object? sender, int studentId)
        {
            _currentStudentId = studentId;
            Control? sidebar = this.Controls.Find("panelSidebar", true).FirstOrDefault();
            if (sidebar != null) sidebar.Visible = true;
            ShowDashboard();
        }

        private void ShowDashboard()
        {
            UC_Dashboard dashboard = new UC_Dashboard();
            dashboard.RequestOpenProfile += (s, e) => ShowPage(new UC_Profile(_currentStudentId));
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

        // --- BUTTON EVENT HANDLERS ---

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            ShowDashboard();
        }

        private void btn_courses_Click(object? sender, EventArgs e)
        {
            UC_Courses coursesPage = new UC_Courses();
            coursesPage.CourseSelected += (s, languageName) =>
            {
                MessageBox.Show($"Starting {languageName} lessons...");
            };
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