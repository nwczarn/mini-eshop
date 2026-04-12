using AIService.Endpoints;
using AIService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<OllamaService>();

builder.Configuration["Ollama:BaseUrl"] ??= "http://ollama:11434";

builder.WebHost.UseUrls("http://0.0.0.0:8090");

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/health", () => Results.Ok("OK"));

app.MapGenerateEndpoint();
app.MapAnalyzeError();

app.Run();