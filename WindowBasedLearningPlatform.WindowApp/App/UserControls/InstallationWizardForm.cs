using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowBasedLearningPlatform.WindowApp.Services;

namespace WindowBasedLearningPlatform.WindowApp.App
{
    /// <summary>
    /// A modern, step-by-step wizard for first-time application setup.
    /// </summary>
    public partial class InstallationWizard : Form
    {
        private int _currentStep = 1;
        private const int TotalSteps = 3;

        private Panel contentPanel;
        private Button btnNext;
        private Button btnBack;
        private Label lblTitle;
        private Label lblDescription;
        private ProgressBar progressBar;

        public InstallationWizard()
        {
            InitializeWizardUI();
            UpdateStepUI();
        }

        private void InitializeWizardUI()
        {
            this.Text = "Learning Platform Setup";
            this.Size = new Size(600, 450);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;

            contentPanel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(20) };

            Panel bottomPanel = new Panel { Dock = DockStyle.Bottom, Height = 60, BackColor = Color.FromArgb(240, 240, 240) };

            btnNext = new Button { Text = "Next", Size = new Size(100, 35), Location = new Point(470, 12), FlatStyle = FlatStyle.Flat };
            btnBack = new Button { Text = "Back", Size = new Size(100, 35), Location = new Point(360, 12), FlatStyle = FlatStyle.Flat, Enabled = false };

            btnNext.Click += BtnNext_Click;
            btnBack.Click += BtnBack_Click;

            bottomPanel.Controls.Add(btnNext);
            bottomPanel.Controls.Add(btnBack);

            lblTitle = new Label { Location = new Point(20, 20), Size = new Size(540, 40), Font = new Font("Segoe UI", 16, FontStyle.Bold) };
            lblDescription = new Label { Location = new Point(25, 70), Size = new Size(530, 200), Font = new Font("Segoe UI", 10) };

            progressBar = new ProgressBar { Location = new Point(20, 300), Size = new Size(540, 20), Maximum = 100 };

            contentPanel.Controls.Add(lblTitle);
            contentPanel.Controls.Add(lblDescription);
            contentPanel.Controls.Add(progressBar);

            this.Controls.Add(contentPanel);
            this.Controls.Add(bottomPanel);
        }

        private void UpdateStepUI()
        {
            btnBack.Enabled = _currentStep > 1;
            btnNext.Text = _currentStep == TotalSteps ? "Finish" : "Next";

            switch (_currentStep)
            {
                case 1:
                    lblTitle.Text = "Welcome to Learning Platform";
                    lblDescription.Text = "This wizard will help you set up the environment, including the local AI services required for your personalized learning experience.\n\nClick Next to begin.";
                    progressBar.Value = 10;
                    break;
                case 2:
                    lblTitle.Text = "Local AI Configuration";
                    lblDescription.Text = "We are configuring Ollama and the Phi4-Mini model. This allows the platform to provide offline coding assistance and explanations.\n\nRequirement: Ollama must be installed on your system.";
                    progressBar.Value = 50;
                    break;
                case 3:
                    lblTitle.Text = "Ready to Launch";
                    lblDescription.Text = "Configuration is complete. The application will now start the local services automatically.\n\nClick Finish to enter the platform.";
                    progressBar.Value = 100;
                    break;
            }
        }

        private async void BtnNext_Click(object sender, EventArgs e)
        {
            if (_currentStep == 2)
            {
                btnNext.Enabled = false;
                lblDescription.Text = "Initializing Ollama and checking for phi4-mini... Please wait.";
                await OllamaServiceManager.InitializeOllamaAsync();
                btnNext.Enabled = true;
            }

            if (_currentStep < TotalSteps)
            {
                _currentStep++;
                UpdateStepUI();
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            if (_currentStep > 1)
            {
                _currentStep--;
                UpdateStepUI();
            }
        }
    }
}
