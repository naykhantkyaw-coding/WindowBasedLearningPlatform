using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace WindowBasedLearningPlatform.WindowApp.Services
{
    /// <summary>
    /// Service to manage application settings and AI model configurations.
    /// </summary>
    public class ConfigurationService
    {
        private readonly string _configPath;
        private JObject _settings;

        // Cache properties
        public string AiModel { get; private set; }
        public string AiEndpoint { get; private set; }
        public string ConnectionString { get; private set; }

        public ConfigurationService()
        {
            // Path to the configuration file in the execution directory (bin/Debug/...)
            _configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "customsetting.json");
            LoadSettings();
        }

        private void LoadSettings()
        {
            // 1. Set Hardcoded Defaults (The "Safety Net")
            // This ensures phi-4-mini is used even if the config file is missing or broken.
            AiModel = "phi-4-mini";
            AiEndpoint = "http://127.0.0.1:11434/api/generate";
            ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LearningPlatform;Integrated Security=True";

            // 2. Try to overwrite with file settings
            if (File.Exists(_configPath))
            {
                try
                {
                    string json = File.ReadAllText(_configPath);
                    _settings = JObject.Parse(json);

                    // Handle "AiTutor" section (matches your customsetting.json)
                    var aiSection = _settings["AiTutor"];
                    if (aiSection != null)
                    {
                        string model = aiSection["Model"]?.ToString();
                        if (!string.IsNullOrWhiteSpace(model))
                        {
                            AiModel = model;
                        }

                        string endpoint = aiSection["Endpoint"]?.ToString();
                        if (!string.IsNullOrWhiteSpace(endpoint))
                        {
                            AiEndpoint = endpoint;
                        }
                    }
                    // Fallback: Check legacy "AI" section if "AiTutor" is missing
                    else if (_settings["AI"] != null)
                    {
                        string model = _settings["AI"]["Model"]?.ToString();
                        if (!string.IsNullOrWhiteSpace(model)) AiModel = model;

                        string endpoint = _settings["AI"]["Endpoint"]?.ToString();
                        if (!string.IsNullOrWhiteSpace(endpoint)) AiEndpoint = endpoint;
                    }

                    // Handle "Database" section
                    var dbSection = _settings["Database"];
                    if (dbSection != null)
                    {
                        string conn = dbSection["ConnectionString"]?.ToString();
                        if (!string.IsNullOrWhiteSpace(conn))
                        {
                            ConnectionString = conn;
                        }
                    }
                }
                catch
                {
                    // If JSON is invalid, silent fail and stick to defaults set in step 1
                }
            }
        }

        public string GetAiModel()
        {
            return AiModel;
        }

        public string GetAiEndpoint()
        {
            return AiEndpoint;
        }

        public string GetConnectionString()
        {
            return ConnectionString;
        }
    }
}