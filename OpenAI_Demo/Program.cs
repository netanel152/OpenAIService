using System;
using System.Threading.Tasks;

namespace OpenAI_Demo
{
  class Program
  {
    static async Task Main(string[] args)
    {
      var apiKey = "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";
      var openAIService = new OpenAIService(apiKey);

      try
      {
        var response = await openAIService.GetResponseAsync("This is a test prompt for ChatGPT.");
        Console.WriteLine($"Response: {response}");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"An error occurred: {ex.Message}");
      }
    }
  }
}