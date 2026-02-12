using System;
using System.Diagnostics; // Added for timing
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic; // Required for IAsyncEnumerable
using System.IO; // Required for Stream reading
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WindowBasedLearningPlatform.WindowApp.Services
{
    public class OllamaService
    {
        // STATIC HttpClient is best practice to prevent socket exhaustion in Windows
        private static readonly HttpClient _httpClient = new HttpClient();

        // 127.0.0.1 is the loopback address. It is physically impossible for this IP 
        // to route to an external server. It always resolves to THIS machine.
        private const string OllamaBaseUrl = "http://127.0.0.1:11434";
        private readonly string _modelName;

        static OllamaService()
        {
            // Set timeout once for the shared client
            _httpClient.Timeout = TimeSpan.FromMinutes(5); // Increased for larger models
        }

        // UPGRADE NOTE: Default changed from "codellama" to "qwen2.5-coder"
        // Qwen 2.5 Coder is the SOTA open-weight model for 2025/2026.
        // It is faster, smarter, and hallucinates less than CodeLlama.
        public OllamaService(string modelName = "qwen2.5-coder")
        {
            _modelName = modelName;
        }

        /// <summary>
        /// Checks if Ollama is running locally on port 11434.
        /// </summary>
        public async Task<bool> IsRunningAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(OllamaBaseUrl);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Standard non-streaming request. Optimized with better prompts and token limits.
        /// </summary>
        public async Task<string> GetCodeExplanationAsync(string code)
        {
            // 1. Setup Request
            var endpoint = $"{OllamaBaseUrl}/api/generate";

            // PROMPT OPTIMIZATION: 
            // 1. Assign a Persona (Senior Architect).
            // 2. Ask for "Concise" output. Less text = Faster generation.
            string systemPrompt = "You are a Senior C# Architect. Explain the code concisely and fix any critical bugs. Do not ramble.";

            var payload = new
            {
                model = _modelName,
                prompt = $"[INST] {systemPrompt} \n\nCode to review:\n{code} [/INST]",
                stream = false,
                // PARAMETER OPTIMIZATION:
                options = new
                {
                    num_predict = 512, // Hard limit on response size for speed
                    temperature = 0.1, // Near-zero creativity for maximum coding accuracy
                    top_k = 20,        // Focused sampling
                    top_p = 0.9
                }
            };

            var jsonContent = JsonConvert.SerializeObject(payload);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // 2. Measure Execution Time (Proof of Work)
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            try
            {
                var response = await _httpClient.PostAsync(endpoint, content);

                stopwatch.Stop();
                var elapsedSeconds = stopwatch.Elapsed.TotalSeconds;

                if (!response.IsSuccessStatusCode)
                {
                    // Specific error guidance for the new model
                    return $"Error: Ollama status {response.StatusCode}. \n\n" +
                           $"MISSING MODEL: Please run this command in terminal: \n" +
                           $"ollama pull {_modelName}";
                }

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var jsonObject = JObject.Parse(jsonResponse);

                string aiText = jsonObject["response"]?.ToString() ?? "No response text found.";

                return $"{aiText}\n\n(Generated locally by {_modelName} in {elapsedSeconds:F1}s)";
            }
            catch (HttpRequestException)
            {
                return "Connection Failed: Could not find Ollama at http://127.0.0.1:11434. \n" +
                       "Please ensure 'ollama serve' is running.";
            }
            catch (Exception ex)
            {
                return $"Unexpected Error: {ex.Message}";
            }
        }

        /// <summary>
        /// Streaming method for instant visual feedback.
        /// </summary>
        public async IAsyncEnumerable<string> GetCodeExplanationStreamAsync(string code)
        {
            var endpoint = $"{OllamaBaseUrl}/api/generate";

            var payload = new
            {
                model = _modelName,
                prompt = $"[INST] You are a C# Expert. Fix bugs and explain this code simply: \n{code} [/INST]",
                stream = true,
                options = new
                {
                    num_predict = 512,
                    temperature = 0.1
                }
            };

            var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
            request.Content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

            using var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync();
            using var reader = new StreamReader(stream);

            while (!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync();
                if (string.IsNullOrWhiteSpace(line)) continue;

                JObject json;
                try
                {
                    json = JObject.Parse(line);
                }
                catch
                {
                    continue;
                }

                var token = json["response"]?.ToString();
                if (!string.IsNullOrEmpty(token))
                {
                    yield return token;
                }

                if (json["done"]?.Value<bool>() == true)
                {
                    yield break;
                }
            }
        }
    }
}