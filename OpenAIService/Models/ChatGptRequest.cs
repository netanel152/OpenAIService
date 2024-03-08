namespace OpenAIService.Models;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Message
{
    public string content { get; set; }
    public string role { get; set; }
}

public class ChatGptRequest
{
    public string model { get; set; }
    public List<Message> messages { get; set; }
    public int max_tokens { get; set; }
    public int temperature { get; set; }
}