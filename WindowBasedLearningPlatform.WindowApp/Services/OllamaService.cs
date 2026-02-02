using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq; // Ensure Newtonsoft.Json is referenced

namespace WindowBasedLearningPlatform.WindowApp.Services
{
    public class OllamaService
    {
        private readonly HttpClient _httpClient;
        // Use 127.0.0.1 instead of localhost to avoid IPv6 resolution issues on some Windows machines
        private const string OllamaBaseUrl = "http://127.0.0.1:11434";
        private readonly string _modelName;

        public OllamaService(string modelName = "codellama")
        {
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromMinutes(2); // Local models can take time
            _modelName = modelName;
        }

        /// <summary>
        /// Checks if Ollama is running and accessible.
        /// </summary>
        public async Task<bool> IsRunningAsync()
        {
            try
            {
                // Simple GET to the base URL usually returns "Ollama is running"
                var response = await _httpClient.GetAsync(OllamaBaseUrl);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<string> GetCodeExplanationAsync(string code)
        {
            var endpoint = $"{OllamaBaseUrl}/api/generate";

            var payload = new
            {
                model = _modelName,
                prompt = $"[INST] You are a C# Expert. Explain this code simply and fix any bugs: \n{code} [/INST]",
                stream = false
            };

            var jsonContent = JsonConvert.SerializeObject(payload);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(endpoint, content);

                if (!response.IsSuccessStatusCode)
                {
                    return $"Error: Ollama returned status {response.StatusCode}. Ensure model '{_modelName}' is pulled.";
                }

                var jsonResponse = await response.Content.ReadAsStringAsync();

                // Deserialize the specific Ollama response format
                var jsonObject = JObject.Parse(jsonResponse);
                return jsonObject["response"]?.ToString() ?? "No response text found.";
            }
            catch (HttpRequestException)
            {
                return "Error: Could not connect to Ollama. \n\n1. Is Ollama installed? \n2. Is 'ollama serve' running? \n3. Did you run 'ollama pull codellama'?";
            }
            catch (Exception ex)
            {
                return $"Unexpected Error: {ex.Message}";
            }
        }
    }
}