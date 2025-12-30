using System;
using System.Drawing;
using System.Windows.Forms;
using WindowBasedLearningPlatform.WindowApp.Services;
using WindowBasedLearningPlatform.WindowApp.Models;
using WindowBasedLearningPlatform.WindowApp.Models.UserModel;

namespace WindowBasedLearningPlatform.WindowApp.App
{
    public partial class UC_Profile : UserControl
    {
        private UserResponseModel userModel;

        public UC_Profile(UserResponseModel model)
        {
            InitializeComponent(); // This calls the method in the Designer.cs file
            userModel = model;
            SetupProfileUI();
            LoadProfileData();
        }

        private void SetupProfileUI()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(245, 247, 250); // Light Grey Background
            this.Padding = new Padding(40);

            // 1. Header
            Label lblHeader = new Label();
            lblHeader.Text = "My Profile";
            lblHeader.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lblHeader.ForeColor = Color.FromArgb(64, 64, 64);
            lblHeader.Dock = DockStyle.Top;
            lblHeader.Height = 60;
            this.Controls.Add(lblHeader);

            // 2. Main Card Panel
            Panel card = new Panel();
            card.BackColor = Color.White;
            card.Size = new Size(600, 400);
            card.Location = new Point(40, 100);
            this.Controls.Add(card);

            // --- Inside the Card ---

            // Avatar Placeholder (Circle)
            Label lblAvatar = new Label();
            lblAvatar.Text = "JD"; // Initials
            lblAvatar.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblAvatar.ForeColor = Color.White;
            lblAvatar.BackColor = ColorTranslator.FromHtml("#fdd23f"); // Brand Color
            lblAvatar.TextAlign = ContentAlignment.MiddleCenter;
            lblAvatar.Size = new Size(80, 80);
            lblAvatar.Location = new Point(30, 30);
            card.Controls.Add(lblAvatar);

            // Name Label
            Label lblName = new Label();
            lblName.Name = "lblName";
            lblName.Text = "Loading...";
            lblName.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblName.Location = new Point(130, 40);
            lblName.AutoSize = true;
            card.Controls.Add(lblName);

            // Role/Subtitle
            Label lblRole = new Label();
            lblRole.Text = "Student";
            lblRole.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblRole.ForeColor = Color.Gray;
            lblRole.Location = new Point(130, 75);
            lblRole.AutoSize = true;
            card.Controls.Add(lblRole);

            // Divider
            Panel divider = new Panel();
            divider.BackColor = Color.LightGray;
            divider.Size = new Size(540, 1);
            divider.Location = new Point(30, 130);
            card.Controls.Add(divider);

            // Details Section
            AddDetailRow(card, "Username:", "lblUsername", 150);
            AddDetailRow(card, "Email:", "lblEmail", 190);
            AddDetailRow(card, "Member Since:", "lblDate", 230);
        }

        private void AddDetailRow(Panel parent, string label, string valueControlName, int yPos)
        {
            Label lbl = new Label();
            lbl.Text = label;
            lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lbl.ForeColor = Color.Gray;
            lbl.Location = new Point(30, yPos);
            lbl.AutoSize = true;
            parent.Controls.Add(lbl);

            Label val = new Label();
            val.Name = valueControlName;
            val.Text = "-";
            val.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            val.ForeColor = Color.Black;
            val.Location = new Point(200, yPos - 2);
            val.AutoSize = true;
            parent.Controls.Add(val);
        }

        private void LoadProfileData()
        {
            // MOCK DATA for now
            string mockName = userModel.UserName;
            string mockDate = userModel.CreatedDateTime.ToShortDateString();

            Control[] cName = this.Controls.Find("lblName", true);
            if (cName.Length > 0) cName[0].Text = mockName;

            Control[] cUser = this.Controls.Find("lblUsername", true);
            if (cUser.Length > 0) cUser[0].Text = mockName;

            Control[] cDate = this.Controls.Find("lblDate", true);
            if (cDate.Length > 0) cDate[0].Text = mockDate;
        }
    }
}