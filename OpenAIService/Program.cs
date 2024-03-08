using Newtonsoft.Json.Linq;
using OpenAIService.Models;

namespace OpenAIService;

class Program
{
  static async Task Main(string[] args)
  {
    string json = File.ReadAllText("appsettings.json");
    var jsonObj = JObject.Parse(json);
    string apiKey = jsonObj["ApiKey"].ToString();
    var openAIService = new OpenAIService(apiKey);

    try
    {
      ChatGptRequest request = new ChatGptRequest()
      {
        max_tokens = 7,
        temperature = 0,
        messages = new List<Message>()
                    {
                         new() {
                             content = "what is the capital city of israel ?",
                             role = "system"
                         }
                    },
        model = "gpt-4"
      };
      var response = await openAIService.GetResponseAsync(request);
      Console.WriteLine($"Response: {response.choices[0].message.content}");
    }
    catch (Exception ex)
    {
      Console.WriteLine($"An error occurred: {ex.Message}");
    }
  }
}
