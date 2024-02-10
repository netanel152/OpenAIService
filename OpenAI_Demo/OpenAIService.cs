using System.Text;
using System.Text.Json;

namespace OpenAI_Demo
{
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

    public async Task<string> GetResponseAsync(string prompt, string model = "gpt-3.5-turbo", double temperature = 0.5, int maxTokens = 100)
    {
      var data = new
      {
        model = model,
        prompt = prompt,
        temperature = temperature,
        max_tokens = maxTokens
      };

      var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
      var response = await _httpClient.PostAsync("https://api.openai.com/v1/completions", content);

      if (response.IsSuccessStatusCode)
      {
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<dynamic>(responseString);
        return result.choices[0].text.ToString();
      }
      else
      {
        throw new Exception("Error calling OpenAI API");
      }
    }
  }
}
