var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://0.0.0.0:8081");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Witaj w Admin Service!");

var products = new List<string> { "Mysz", "Klawiatura", "Monitor" };

app.MapGet("/products", () => products);

app.Run();