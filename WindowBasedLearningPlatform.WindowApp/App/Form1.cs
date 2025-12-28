using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowBasedLearningPlatform.WindowApp.App
{
    public partial class Form1 : Form
    {
        // Store the logged-in user ID so we can track who is using the app
        private int _currentStudentId;

        public Form1()
        {
            InitializeComponent();

            // STARTUP: Show Login Screen instead of Dashboard immediately
            ShowLogin();
        }

        private void ShowLogin()
        {
            // 1. Find the necessary panels safely
            Control? contentPanel = this.Controls.Find("panelContent", true).FirstOrDefault();
            Control? sidebar = this.Controls.Find("panelSidebar", true).FirstOrDefault();

            // 2. Hide the sidebar while logging in (Cleaner look for login screen)
            if (sidebar != null) sidebar.Visible = false;

            if (contentPanel != null)
            {
                contentPanel.Controls.Clear();

                // Create the Login Page instance
                UC_Login loginPage = new UC_Login();

                // 3. THE CRITICAL STEP: Subscribe to the "Success" event
                // This connects the "Sign In" button click in UC_Login to the logic here
                loginPage.LoginSuccess += OnLoginSuccess;

                loginPage.Dock = DockStyle.Fill;
                contentPanel.Controls.Add(loginPage);
            }
            else
            {
                MessageBox.Show("Error: 'panelContent' not found. Please check your Designer names.");
            }
        }

        // This method runs automatically when UC_Login says "Success"
        private void OnLoginSuccess(object? sender, int studentId)
        {
            _currentStudentId = studentId;

            // 1. Show the Sidebar again so the user can navigate
            Control? sidebar = this.Controls.Find("panelSidebar", true).FirstOrDefault();
            if (sidebar != null) sidebar.Visible = true;

            // 2. Load the Dashboard
            ShowPage(new UC_Dashboard());
        }

        // General Helper to switch content pages (Dashboard, Courses, etc.)
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
            else
            {
                MessageBox.Show("Error: 'panelContent' not found. Please check your Designer names.");
            }
        }

        // --- Sidebar Navigation Button Events ---
        // Ensure these are linked in your Form Designer (properties -> events -> click)

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            ShowPage(new UC_Dashboard());
        }

        private void btn_courses_Click(object sender, EventArgs e)
        {
            // Placeholder until UC_Courses is created
            MessageBox.Show("Courses Page coming soon!");

            // Once you create UC_Courses.cs, uncomment the line below:
            // ShowPage(new UC_Courses());
        }
    }
}