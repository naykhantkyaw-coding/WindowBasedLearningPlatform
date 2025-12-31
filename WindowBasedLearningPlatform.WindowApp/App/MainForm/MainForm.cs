using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowBasedLearningPlatform.WindowApp.App.UserControls;
using WindowBasedLearningPlatform.WindowApp.Models.UserModel;

namespace WindowBasedLearningPlatform.WindowApp.App
{
    public partial class MainForm : Form
    {
        private UserResponseModel userModel;

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
            if (headerPanal != null) headerPanal.Visible = false;

            if (contentPanel != null)
            {
                contentPanel.Controls.Clear();
                LoginUserControl loginPage = new LoginUserControl();
                loginPage.LoginSuccess += OnLoginSuccess;
                loginPage.Dock = DockStyle.Fill;
                contentPanel.Controls.Add(loginPage);
            }
        }

        private void OnLoginSuccess(object? sender, UserResponseModel model)
        {
            userModel = model;
            Control? sidebar = this.Controls.Find("panelSidebar", true).FirstOrDefault();
            if (sidebar != null) sidebar.Visible = true;
            ShowDashboard();
        }

        private void ShowDashboard()
        {
            UC_Dashboard dashboard = new UC_Dashboard();
            dashboard.RequestOpenProfile += (s, e) => ShowPage(new UC_Profile(userModel));
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
            // 1. Create the Courses listing page
            UC_Courses coursesPage = new UC_Courses();

            // 2. LISTEN FOR THE SELECTION
            // When "Start Learning" is clicked in UC_Courses, this lambda function runs.
            coursesPage.CourseSelected += (s, languageName) =>
            {
                // 3. Create the Lesson Viewer for the selected language (e.g., "C#")
                UC_LessonViewer lessonViewer = new UC_LessonViewer(languageName);

                // 4. Switch the main view to show the lessons
                ShowPage(lessonViewer);
            };

            // 5. Show the courses list initially
            ShowPage(coursesPage);
        }
        private void btn_profile_Click(object sender, EventArgs e)
        {
            ShowPage(new UC_Profile(userModel));
        }

        private void btn_signout_Click(object sender, EventArgs e)
        {
            userModel.UserId = 0;
            ShowLogin();
        }
    }
}