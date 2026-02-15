using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WindowBasedLearningPlatform.WindowApp.Services
{
    /// <summary>
    /// Handles communication with the local Ollama API.
    /// </summary>
    public class OllamaService
    {
        private readonly string _modelName;
        private readonly string _endpoint;
        private readonly HttpClient _httpClient;

        public OllamaService(string modelName, string endpoint)
        {
            _modelName = !string.IsNullOrEmpty(modelName) ? modelName : "phi4-mini";

            // Normalize endpoint string
            if (string.IsNullOrEmpty(endpoint))
            {
                _endpoint = "http://localhost:11434";
            }
            else
            {
                _endpoint = endpoint.TrimEnd('/');
            }

            _httpClient = new HttpClient();
            // Set a reasonable timeout for AI generation (e.g., 2 minutes)
            _httpClient.Timeout = TimeSpan.FromMinutes(2);
        }

        /// <summary>
        /// Checks if the Ollama API is reachable.
        /// </summary>
        public async Task<bool> IsRunningAsync()
        {
            try
            {
                // Hitting the /api/tags endpoint is a lightweight way to check if the server is up.
                // Treat any HTTP response (including 404) as evidence the HTTP server is reachable;
                // only network/connection exceptions mean the server is not reachable.
                var response = await _httpClient.GetAsync($"{_endpoint}/api/tags");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Sends code to the LLM and retrieves an explanation.
        /// </summary>
        public async Task<string> GetCodeExplanationAsync(string code)
        {
            try
            {
                // Construct the prompt
                var prompt = $"You are a helpful programming tutor. Explain the following C# code simply and briefly:\n\n```csharp\n{code}\n```";

                var requestBody = new
                {
                    model = _modelName,
                    prompt = prompt,
                    stream = false // Disable streaming for simpler handling in WinForms
                };

                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Try multiple possible generation endpoints used by different Ollama versions.
                string[] genPaths = new[] {
                    "/api/generate",
                    "/v1/generate",
                    "/api/completions",
                    "/v1/completions",
                    "/api/responses",
                    "/v1/responses"
                };

                string lastBody = null;
                foreach (var p in genPaths)
                {
                    var url = _endpoint.TrimEnd('/') + p;
                    try
                    {
                        var response = await _httpClient.PostAsync(url, content);
                        var responseString = await response.Content.ReadAsStringAsync();

                        if (response.IsSuccessStatusCode)
                        {
                            // Parse the JSON response and try typical fields
                            try
                            {
                                var jsonResponse = JObject.Parse(responseString);
                                // Common fields: "response", "text", "result", "choices"
                                string responseText = jsonResponse["response"]?.ToString()
                                    ?? jsonResponse["text"]?.ToString()
                                    ?? jsonResponse["result"]?.ToString();

                                if (string.IsNullOrEmpty(responseText) && jsonResponse["choices"] is JArray choices && choices.Count > 0)
                                {
                                    responseText = choices[0]["text"]?.ToString();
                                }

                                return string.IsNullOrEmpty(responseText) ? "AI returned no content." : responseText;
                            }
                            catch
                            {
                                return responseString ?? "AI returned no content.";
                            }
                        }

                        // Save last body for diagnostics and if 404 try next candidate
                        lastBody = responseString;
                        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                        {
                            continue; // try next possible endpoint
                        }

                        // Other non-success status: return with diagnostic
                        return $"Error: Server returned {(int)response.StatusCode} {response.ReasonPhrase}. Response body: {responseString}.";
                    }
                    catch (HttpRequestException httpEx)
                    {
                        lastBody = httpEx.Message;
                        // try next endpoint
                    }
                }

                return $"Could not find a working generation endpoint. Last response/body: {lastBody}";
            }
            catch (HttpRequestException httpEx)
            {
                return $"Network Error: {httpEx.Message}. Is Ollama running?";
            }
            catch (Exception ex)
            {
                return $"An error occurred: {ex.Message}";
            }
        }
    }
}