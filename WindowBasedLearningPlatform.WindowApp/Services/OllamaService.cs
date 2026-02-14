using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WindowBasedLearningPlatform.WindowApp.Services
{
    public class OllamaService
    {
        // STATIC HttpClient is best practice to prevent socket exhaustion in Windows
        private static readonly HttpClient _httpClient = new HttpClient();

        private readonly string _modelName;
        private readonly string _generateEndpoint;
        private readonly string _baseUrl;

        static OllamaService()
        {
            // Set timeout once for the shared client
            // Generous timeout for larger models or slower hardware
            _httpClient.Timeout = TimeSpan.FromMinutes(5);
        }

        /// <summary>
        /// Initializes the Ollama Service with configuration settings.
        /// </summary>
        /// <param name="modelName">The name of the model (e.g., phi-4-mini)</param>
        /// <param name="endpointUrl">The full generation endpoint (e.g., http://localhost:11434/api/generate)</param>
        public OllamaService(string modelName, string endpointUrl)
        {
            _modelName = modelName;
            _generateEndpoint = endpointUrl;

            // Derive base URL for the health check (removing /api/generate)
            try
            {
                var uri = new Uri(endpointUrl);
                _baseUrl = $"{uri.Scheme}://{uri.Host}:{uri.Port}";
            }
            catch
            {
                // Fallback if URL parsing fails
                _baseUrl = "http://127.0.0.1:11434";
            }
        }

        /// <summary>
        /// Checks if Ollama is running locally.
        /// </summary>
        public async Task<bool> IsRunningAsync()
        {
            try
            {
                // Check the root URL (usually returns "Ollama is running")
                var response = await _httpClient.GetAsync(_baseUrl);
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
                var response = await _httpClient.PostAsync(_generateEndpoint, content);

                stopwatch.Stop();
                var elapsedSeconds = stopwatch.Elapsed.TotalSeconds;

                if (!response.IsSuccessStatusCode)
                {
                    // Specific error guidance
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
                return $"Connection Failed: Could not connect to {_baseUrl}. \n" +
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

            var request = new HttpRequestMessage(HttpMethod.Post, _generateEndpoint);
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