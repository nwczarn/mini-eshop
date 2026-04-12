using AIService.Models;
using AIService.Prompts;
using AIService.Services;

namespace AIService.Endpoints;

public static class GenerateEndpointApi
{
    public static void MapGenerateEndpoint(this WebApplication app)
    {
        app.MapPost("/generate-endpoint", async (
            GenerateEndpointRequest req,
            OllamaService aiService) =>
        {
            try
            {
                var path = Path.Combine(
                    "specs",
                    req.SpecName
                );

                if (!File.Exists(path))
                {
                    return Results.BadRequest($"Spec {path} not found.");
                }

                var spec = await File.ReadAllTextAsync(path);

                var prompt = GenerateEndpointPrompt.Build(spec);

                var result = await aiService.GenerateAsync(prompt);

                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        });
    }
}