using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowBasedLearningPlatform.WindowApp.Services
{
    /// <summary>
    /// Handles the lifecycle of the Ollama local AI service process.
    /// </summary>
    public class OllamaServiceManager
    {
        private const string OllamaProcessName = "ollama";
        // On Windows, it is often "ollama.exe" or "ollama app.exe", checking process name is safer
        private const string DefaultModel = "phi4-mini";
        private static readonly HttpClient _httpClient = new HttpClient();

        /// <summary>
        /// Lightweight check to ensure the Ollama API is reachable. If not reachable,
        /// attempt to start the process and retry a few times.
        /// </summary>
        public static async Task EnsureServiceRunningAsync()
        {
            // Build candidate health URLs: configured endpoint (if any), localhost and 127.0.0.1
            string[] healthCandidates = new[] { "http://localhost:11434", "http://127.0.0.1:11434" };
            try
            {
                var cfg = new ConfigurationService();
                var ep = cfg.GetAiEndpoint();
                if (!string.IsNullOrWhiteSpace(ep))
                {
                    // Put configured endpoint first
                    healthCandidates = new[] { ep.TrimEnd('/') }.Concat(healthCandidates).ToArray();
                }
            }
            catch { /* ignore config errors */ }

            // Try each candidate once quickly. If we get any HTTP response (even 404), the server is reachable.
            foreach (var baseUrl in healthCandidates)
            {
                var healthUrl = baseUrl.TrimEnd('/') + "/api/tags";
                try
                {
                    var resp = await _httpClient.GetAsync(healthUrl);
                    // If the request completes (no exception) the HTTP server is present even if endpoint returned 404.
                    return;
                }
                catch { /* try next candidate */ }
            }

            // If no HTTP server responded, try to ensure a process is running and start it if needed.
            if (!IsOllamaRunning())
            {
                bool started = StartOllamaProcess();
                if (started)
                {
                    // Give the local server a moment to bind to the port
                    await Task.Delay(2000);
                }
            }

            // Retry contacting the API a few times before giving up. Try all candidates each iteration.
            const int maxRetries = 5;
            for (int i = 0; i < maxRetries; i++)
            {
                foreach (var baseUrl in healthCandidates)
                {
                    var healthUrl = baseUrl.TrimEnd('/') + "/api/tags";
                    try
                    {
                        var resp = await _httpClient.GetAsync(healthUrl);
                        // Any response means the HTTP server is reachable (even 404)
                        return;
                    }
                    catch { /* try next candidate */ }
                }

                await Task.Delay(1000);
            }
        }

        /// <summary>
        /// Checks if the Ollama process is currently active.
        /// </summary>
        private static bool IsOllamaRunning()
        {
            try
            {
                // Be more tolerant: check all processes and look for names that contain "ollama".
                foreach (var p in Process.GetProcesses())
                {
                    try
                    {
                        if (p.ProcessName.IndexOf(OllamaProcessName, StringComparison.OrdinalIgnoreCase) >= 0)
                            return true;
                    }
                    catch { /* ignored for processes we can't access */ }
                }
            }
            catch { }

            return false;
        }

        /// <summary>
        /// Attempts to start the 'ollama serve' command.
        /// </summary>
        private static bool StartOllamaProcess()
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "ollama", // Assumes 'ollama' is in system PATH
                    Arguments = "serve",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                Process.Start(startInfo);
                return true;
            }
            catch (Exception)
            {
                // Silently fail here; the UI (IsRunningAsync) will catch the connection error later
                // and show a user-friendly message.
                Debug.WriteLine("Could not auto-start Ollama.");
                return false;
            }
        }

        public static async Task InitializeOllamaAsync()
        {
            await EnsureServiceRunningAsync();
            // Optional: Check/Pull model in background
        }
    }
}