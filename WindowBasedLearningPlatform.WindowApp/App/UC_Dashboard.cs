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
    public partial class UC_Dashboard : UserControl
    {
        public UC_Dashboard()
        {
            InitializeComponent();
            SetupDashboardUI();
            LoadMockData();
        }
        private void SetupDashboardUI()
        {
            // 1. Base Styling
            this.BackColor = Color.FromArgb(245, 247, 250); // Light Grey Background
            this.Padding = new Padding(30);

            // 2. Title Label (Welcome Message)
            Label lblWelcome = new Label();
            lblWelcome.Text = "Welcome back, Student!";
            lblWelcome.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblWelcome.ForeColor = Color.FromArgb(64, 64, 64);
            lblWelcome.AutoSize = true;
            lblWelcome.Dock = DockStyle.Top;
            lblWelcome.Padding = new Padding(0, 0, 0, 20); // Spacing below title
            this.Controls.Add(lblWelcome);

            // 3. Stats Container (FlowLayoutPanel for responsive cards)
            FlowLayoutPanel panelStats = new FlowLayoutPanel();
            panelStats.Dock = DockStyle.Top;
            panelStats.Height = 160;
            panelStats.AutoSize = false;
            panelStats.FlowDirection = FlowDirection.LeftToRight;
            panelStats.WrapContents = false; // Keep in one line
            this.Controls.Add(panelStats);
            panelStats.BringToFront(); // Ensure it sits below the title

            // 4. Create Cards Programmatically
            // (Title, Value, Icon Color)
            AddStatCard(panelStats, "Courses in Progress", "3", Color.FromArgb(100, 181, 246)); // Blue
            AddStatCard(panelStats, "Lessons Completed", "12", Color.FromArgb(129, 199, 132)); // Green
            AddStatCard(panelStats, "Quiz Average", "85%", Color.FromArgb(255, 183, 77));  // Orange
            AddStatCard(panelStats, "Total Hours", "5.2h", Color.FromArgb(186, 104, 200)); // Purple

            // 5. Recent Activity Section
            Label lblRecent = new Label();
            lblRecent.Text = "Recent Activity";
            lblRecent.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblRecent.ForeColor = Color.FromArgb(64, 64, 64);
            lblRecent.Dock = DockStyle.Top;
            lblRecent.Padding = new Padding(0, 30, 0, 10); // Spacing above
            this.Controls.Add(lblRecent);
            lblRecent.BringToFront();
        }

        // Helper Method to create beautiful cards
        private void AddStatCard(FlowLayoutPanel parent, string title, string value, Color accentColor)
        {
            Panel card = new Panel();
            card.Size = new Size(220, 120);
            card.BackColor = Color.White;
            card.Margin = new Padding(0, 0, 20, 0); // Spacing between cards

            // Colored strip on the left
            Panel accent = new Panel();
            accent.Dock = DockStyle.Left;
            accent.Width = 5;
            accent.BackColor = accentColor;
            card.Controls.Add(accent);

            // Value Label (Big Number)
            Label lblValue = new Label();
            lblValue.Text = value;
            lblValue.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lblValue.ForeColor = Color.FromArgb(40, 40, 40);
            lblValue.Location = new Point(20, 20);
            lblValue.AutoSize = true;
            card.Controls.Add(lblValue);

            // Title Label (Small Text)
            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblTitle.ForeColor = Color.Gray;
            lblTitle.Location = new Point(22, 70);
            lblTitle.AutoSize = true;
            card.Controls.Add(lblTitle);

            parent.Controls.Add(card);
        }

        private void LoadMockData()
        {
            // In the future, this is where we will query the database
            // and update the labels with real numbers.
        }
    }
}
