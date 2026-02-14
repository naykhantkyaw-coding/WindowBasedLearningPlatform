using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowBasedLearningPlatform.WindowApp.Services
{
    public class ConfigurationService
    {
        public static string GetDbConnection()
        {
            string connectionString = string.Empty;
            JObject obj = new JObject();
            try
            {
                string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "customsetting.json");
                if (File.Exists(jsonPath))
                {
                    string json = File.ReadAllText(jsonPath);
                    obj = JObject.Parse(json);

                    connectionString = obj["ConnectionStrings"]["DbConnection"].ToString();
                }
            }
            catch (Exception ex)
            {
            }

            return connectionString;
        }

        // Expose AI model configuration as an instance property
        public string AiModel
        {
            get
            {
                try
                {
                    string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "customsetting.json");
                    if (File.Exists(jsonPath))
                    {
                        string json = File.ReadAllText(jsonPath);
                        var obj = JObject.Parse(json);

                        if (obj["AiModel"] != null)
                            return obj["AiModel"].ToString();

                        if (obj["AI"] != null && obj["AI"]["Model"] != null)
                            return obj["AI"]["Model"].ToString();
                    }
                }
                catch
                {
                }

                // Fallback default
                return "deepseek-coder-v2:lite";
            }
        }

        // Convenience method to match existing callers that expect GetAiModel()
        public string GetAiModel()
        {
            return this.AiModel;
        }

        // Returns full generate endpoint for Ollama. Tries multiple config locations and falls back to localhost.
        public string GetAiEndpoint()
        {
            try
            {
                string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "customsetting.json");
                if (File.Exists(jsonPath))
                {
                    string json = File.ReadAllText(jsonPath);
                    var obj = JObject.Parse(json);

                    if (obj["AiEndpoint"] != null)
                        return obj["AiEndpoint"].ToString();

                    if (obj["AI"] != null && obj["AI"]["Endpoint"] != null)
                        return obj["AI"]["Endpoint"].ToString();

                    if (obj["AI"] != null && obj["AI"]["Url"] != null)
                        return obj["AI"]["Url"].ToString();

                    if (obj["AI"] != null && obj["AI"]["BaseUrl"] != null)
                        return obj["AI"]["BaseUrl"].ToString();
                }
            }
            catch
            {
            }

            // Default Ollama generate endpoint
            return "http://127.0.0.1:11434/api/generate";
        }
    }
}
