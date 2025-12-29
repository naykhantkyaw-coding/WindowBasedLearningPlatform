using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D; // Required for Gradient Brushes
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

            // SETUP: Add Gradient to Sidebar
            Control? sidebar = this.Controls.Find("panelSidebar", true).FirstOrDefault();
            if (sidebar is Panel p)
            {
                // Attach the paint event that draws the gradient
                p.Paint += Sidebar_Paint;

                // Ensure the gradient redraws when the window is resized
                p.Resize += (s, e) => p.Invalidate();
            }

            // STARTUP: Show Login Screen instead of Dashboard immediately
            ShowLogin();
        }

        // Custom Paint Method for the Sidebar Gradient
        private void Sidebar_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Panel panel)
            {
                // Define your Gradient Colors
                // Color 1: Top (Lighter Navy)
                Color colorTop = ColorTranslator.FromHtml("#DB2777");
                // Color 2: Bottom (Darker/Black Navy)
                Color colorBottom = ColorTranslator.FromHtml("#9333EA");

                using (LinearGradientBrush brush = new LinearGradientBrush(panel.ClientRectangle, colorTop, colorBottom, 90F))
                {
                    e.Graphics.FillRectangle(brush, panel.ClientRectangle);
                }
            }
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
        private void btn_signout_Click(object sender, EventArgs e)
        {
            // 1. Clear the current session
            _currentStudentId = 0;

            // 2. Return to the Login Screen (this method automatically hides the sidebar)
            ShowLogin();
        }
    }
}