using Newtonsoft.Json;
using OpenAIService.Models;
using System.Text;

namespace OpenAIService;
public class OpenAIService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public OpenAIService(string apiKey)
    {
        _apiKey = apiKey;
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
    }

    public async Task<ChatGptResponse> GetResponseAsync(ChatGptRequest request)
    {

        var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);

        if (response.IsSuccessStatusCode)
        {
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ChatGptResponse>(responseString);
            return result;
        }
        else
        {
            throw new Exception($"An error occurred: {response}");
        }
    }
}
