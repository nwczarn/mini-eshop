using System.Text;
using System.Text.Json;

namespace AIService.Services;

public class OllamaService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public OllamaService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<string> GenerateAsync(string prompt)
    {
        var url = _configuration["Ollama:BaseUrl"] + "/api/generate";

        var payload = new
        {
            model = _configuration["Ollama:Model"],
            prompt = prompt,
            stream = false
        };

        var response = await _httpClient.PostAsJsonAsync(url, payload);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        using var doc = JsonDocument.Parse(json);

        return doc.RootElement.GetProperty("response").GetString() ?? "";
    }
}