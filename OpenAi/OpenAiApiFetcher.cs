using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace OpenAi
{
    public class OpenAiApiFetcher
    {
        private readonly HttpClient _httpClient;
        private readonly MessageModel _system;
        private readonly MessageModel _user;


        public OpenAiApiFetcher(string apiKey, string instruction,  string input)
        {

            _system = new MessageModel
            {
                role = "system", // API expects a string "system"
                content = instruction
            };
            _user = new MessageModel
            {
                role = "user", // API expects a string "user"
                content = input
            };

            _httpClient = new HttpClient();


            // Set up HttpClient headers
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
