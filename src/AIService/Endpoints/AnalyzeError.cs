using AIService.Models;
using AIService.Prompts;
using AIService.Services;

namespace AIService.Endpoints;

public static class AnalyzeErrorApi
{
    public static void MapAnalyzeError(this WebApplication app)
    {
        app.MapPost("/analyze-error", async (
            AnalyzeErrorRequest req,
            OllamaService aiService) =>
        {
            try
            {
                if (string.IsNullOrWhiteSpace(req.Error))
                    return Results.BadRequest("Error is required");

                var prompt = AnalyzeErrorPrompt.Build(req.Error);

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