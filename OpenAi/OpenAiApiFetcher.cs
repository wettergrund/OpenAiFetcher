using System.Text;

namespace OpenAi
{
    public class OpenAiApiFetcher
    {
        private readonly HttpClient _httpClient;
        private readonly MessageModel _system;
        private readonly MessageModel _user;


        public OpenAiApiFetcher(string apiKey, string instruction,  string input)
        {

            _system = new MessageModel(MessageModel.Role.System, instruction);
            _user = new MessageModel(MessageModel.Role.User, input);

            _httpClient = new HttpClient();


            _httpClient.BaseAddress = new Uri("https://api.openai.com/");
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
        }

        public async Task<string> FetchCompletionsAsync()
        {
            var requestData = new
            {
                model = "gpt-3.5-turbo",
                messages = new[] { _system, _user },
                temperature = 0.0,
                max_tokens = 256
            };

            string json = System.Text.Json.JsonSerializer.Serialize(requestData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("v1/chat/completions", content);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                // Handle the error
                Console.WriteLine($"Error: {response.StatusCode}");
                return null;
            }
        }
    }
}
