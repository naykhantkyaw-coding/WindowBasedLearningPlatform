using System;
using System.Windows.Forms;
using WindowBasedLearningPlatform.WindowApp.App;
using WindowBasedLearningPlatform.WindowApp.Services;

namespace WindowBasedLearningPlatform.WindowApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. Check if first run (Wizard logic)
            // In a production app, check a setting in customsetting.json
            bool isFirstRun = true;

            if (isFirstRun)
            {
                using (var wizard = new InstallationWizard())
                {
                    if (wizard.ShowDialog() != DialogResult.OK)
                    {
                        return; // User cancelled setup
                    }
                }
            }

            // 2. Start AI Service Automatically
            // This ensures service is up even if wizard was already completed
            // Call the async initializer synchronously from the entry point.
            OllamaServiceManager.InitializeOllamaAsync().GetAwaiter().GetResult();

            // 3. Launch Main Form
            Application.Run(new MainForm());
        }
    }
}