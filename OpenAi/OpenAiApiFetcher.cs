using OpenAi.Models;
using System.Text;
using System.Text.Json;

namespace OpenAi
{
    public class OpenAiApiFetcher : IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly MessageModel _system;
        private readonly MessageModel _user;
        private string _model = GptModels.Gpt35T;
        public string Model { get => _model; 
                                set => _model = value; 
        }

        /// <summary>
        /// Does something interesting when called.
        /// </summary>
        /// <param name="parameter">A description of the parameter this function takes.</param>
        /// <returns>A description of what this function returns.</returns>
        public OpenAiApiFetcher(string apiKey, string instruction,  string input)
        {

            _system = new MessageModel(MessageModel.Role.system, instruction);
            _user = new MessageModel(MessageModel.Role.user, input);

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.openai.com/"),
                
            };
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
        }

        // Fetches and deserializes the response into a ChatCompletionResponse object
        public async Task<GptResponse> FetchCompletionsAsync()
        {
            string jsonResponse = await FetchCompletionsJsonAsync();
            return JsonSerializer.Deserialize<GptResponse>(jsonResponse, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        }

        // Fetches the raw JSON response string
        public async Task<string> FetchCompletionsJsonAsync()
        {
            var requestData = new
            {
                model = this.Model,
                messages = new[] { _system.ToRequestMessage(), _user.ToRequestMessage() },
                temperature = 0,
                max_tokens = 256
            };

            string json = JsonSerializer.Serialize(requestData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("v1/chat/completions", content);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                // Handle the error
                throw new HttpRequestException($"Error: {response.StatusCode}", null, response.StatusCode);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
