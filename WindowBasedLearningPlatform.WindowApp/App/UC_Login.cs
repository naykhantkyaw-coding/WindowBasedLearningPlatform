using System;
using System.Drawing;
using System.Windows.Forms;
using WindowBasedLearningPlatform.WindowApp.Services;

namespace WindowBasedLearningPlatform.WindowApp.App
{
    public partial class UC_Login : UserControl
    {
        // Inputs
        private TextBox txtUser;
        private TextBox txtPass;
        private Label lblError;

        // Event to tell Form1 that login worked
        public event EventHandler<int> LoginSuccess;

        public UC_Login()
        {
            InitializeComponent();
            SetupLoginUI();
        }

        private void SetupLoginUI()
        {
            // 1. Background
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(240, 242, 245); // Lighter, cleaner grey background

            // 2. The Center Card (Panel)
            Panel card = new Panel();
            card.Size = new Size(380, 450); // Slightly larger for better spacing
            card.BackColor = Color.White;
            // Center the card manually since standard Docking doesn't do "Center" easily
            card.Location = new Point((this.Width - card.Width) / 2, (this.Height - card.Height) / 2);
            card.Anchor = AnchorStyles.None; // Keeps it centered on resize
            this.Controls.Add(card);

            // Center Helper Logic
            this.Resize += (s, e) => {
                card.Location = new Point((this.Width - card.Width) / 2, (this.Height - card.Height) / 2);
            };

            // 3. Title
            Label lblTitle = new Label();
            lblTitle.Text = "Welcome Back";
            lblTitle.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 33, 33); // Dark Grey/Black
            lblTitle.AutoSize = true;
            // Center title in card
            lblTitle.Location = new Point((card.Width - 210) / 2, 40);
            card.Controls.Add(lblTitle);

            Label lblSubtitle = new Label();
            lblSubtitle.Text = "Please login to your account";
            lblSubtitle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblSubtitle.ForeColor = Color.Gray;
            lblSubtitle.AutoSize = true;
            lblSubtitle.Location = new Point((card.Width - 180) / 2, 80);
            card.Controls.Add(lblSubtitle);

            // 4. Username Field
            Label lblUser = new Label() { Text = "Username", Location = new Point(40, 130), Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.FromArgb(64, 64, 64), AutoSize = true };
            card.Controls.Add(lblUser);

            txtUser = new TextBox();
            txtUser.Font = new Font("Segoe UI", 11);
            txtUser.Location = new Point(40, 155);
            txtUser.Size = new Size(300, 30);
            txtUser.BackColor = Color.FromArgb(250, 250, 250); // Very light grey input bg
            card.Controls.Add(txtUser);

            // 5. Password Field
            Label lblPass = new Label() { Text = "Password", Location = new Point(40, 200), Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.FromArgb(64, 64, 64), AutoSize = true };
            card.Controls.Add(lblPass);

            txtPass = new TextBox();
            txtPass.Font = new Font("Segoe UI", 11);
            txtPass.Location = new Point(40, 225);
            txtPass.Size = new Size(300, 30);
            txtPass.PasswordChar = '•'; // Hide password
            txtPass.BackColor = Color.FromArgb(250, 250, 250);
            card.Controls.Add(txtPass);

            // 6. Error Label (Hidden initially)
            lblError = new Label();
            lblError.Text = "Invalid username or password.";
            lblError.ForeColor = Color.Red;
            lblError.Font = new Font("Segoe UI", 9);
            lblError.Location = new Point(40, 265);
            lblError.AutoSize = true;
            lblError.Visible = false;
            card.Controls.Add(lblError);

            // 7. Login Button with BRAND COLOR #fdd23f
            Button btnLogin = new Button();
            btnLogin.Text = "Sign In";
            // Use ColorTranslator to use the specific hex code
            btnLogin.BackColor = ColorTranslator.FromHtml("#fdd23f");
            btnLogin.ForeColor = Color.FromArgb(30, 30, 30); // Dark text for contrast on yellow
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnLogin.Size = new Size(300, 45);
            btnLogin.Location = new Point(40, 300);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.Click += BtnLogin_Click;
            card.Controls.Add(btnLogin);
        }

        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            string u = txtUser.Text.Trim();
            string p = txtPass.Text.Trim();

            if (string.IsNullOrEmpty(u) || string.IsNullOrEmpty(p))
            {
                ShowError("Please fill in all fields.");
                return;
            }

            // --- TEMPORARY: UI Testing Mode (No Database) ---
            // Simulating a database call. 
            // We'll accept "admin" / "admin" as valid credentials for now.

            int? studentId = null;

            if (u == "admin" && p == "admin")
            {
                studentId = 1; // Mock Student ID
            }

            // To test failure, enter anything else.
            // ------------------------------------------------

            if (studentId.HasValue)
            {
                // Success! Fire the event so Form1 knows.
                LoginSuccess?.Invoke(this, studentId.Value);
            }
            else
            {
                ShowError("Invalid username or password. (For testing: use admin/admin)");
            }
        }

        private void ShowError(string msg)
        {
            lblError.Text = msg;
            lblError.Visible = true;
        }

        // Removed the conflicting Designer Code block
        // InitializeComponent() and components are already defined in UC_Login.Designer.cs
    }
}