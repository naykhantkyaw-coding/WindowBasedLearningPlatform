using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace WindowBasedLearningPlatform.WindowApp.Services
{
    public class ConfigurationService
    {
        private readonly string _configPath;

        public ConfigurationService()
        {
            // Centralize the path to avoid repetition and potential mismatch
            _configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "customsetting.json");
        }

        public static string GetDbConnection()
        {
            string connectionString = string.Empty;
            try
            {
                string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "customsetting.json");
                if (File.Exists(jsonPath))
                {
                    string json = File.ReadAllText(jsonPath);
                    var obj = JObject.Parse(json);

                    if (obj["ConnectionStrings"] != null && obj["ConnectionStrings"]["DbConnection"] != null)
                    {
                        connectionString = obj["ConnectionStrings"]["DbConnection"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Config Error (DB): {ex.Message}");
            }

            return connectionString;
        }

        /// <summary>
        /// Returns the AI Model name. 
        /// Priority: 1. AiModel key, 2. AI -> Model key, 3. Fallback to phi4-mini
        /// </summary>
        public string AiModel
        {
            get
            {
                try
                {
                    if (File.Exists(_configPath))
                    {
                        string json = File.ReadAllText(_configPath);
                        var obj = JObject.Parse(json);

                        // Priority 1: Direct key
                        if (obj["AiModel"] != null)
                            return obj["AiModel"].ToString();

                        // Priority 2: Nested object
                        if (obj["AI"] != null && obj["AI"]["Model"] != null)
                            return obj["AI"]["Model"].ToString();
                    }
                    else
                    {
                        Debug.WriteLine($"Config file not found at: {_configPath}. Using fallback.");
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Config Error (Model): {ex.Message}");
                }

                // CHANGED: Defaulting to phi4-mini instead of deepseek
                // Ensure this matches your 'ollama list' output (e.g., "phi4:latest" or "phi4-mini")
                return "phi4-mini";
            }
        }

        public string GetAiModel()
        {
            return this.AiModel;
        }

        /// <summary>
        /// Returns full generate endpoint for Ollama. 
        /// Falls back to localhost if not specified in config.
        /// </summary>
        public string GetAiEndpoint()
        {
            try
            {
                if (File.Exists(_configPath))
                {
                    string json = File.ReadAllText(_configPath);
                    var obj = JObject.Parse(json);

                    if (obj["AiEndpoint"] != null)
                        return obj["AiEndpoint"].ToString();

                    if (obj["AI"] != null)
                    {
                        var ai = obj["AI"];
                        if (ai["Endpoint"] != null) return ai["Endpoint"].ToString();
                        if (ai["Url"] != null) return ai["Url"].ToString();
                        if (ai["BaseUrl"] != null) return ai["BaseUrl"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Config Error (Endpoint): {ex.Message}");
            }

            // Default Ollama generate endpoint
            return "http://127.0.0.1:11434/api/generate";
        }
    }
}