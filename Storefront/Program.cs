var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://0.0.0.0:8080");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("AdminApi", client =>
{
    client.BaseAddress = new Uri("http://host.docker.internal:8081");
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Witaj w Storefront API!");

app.MapGet("/admin-products", async (IHttpClientFactory httpClientFactory) =>
{
    var client = httpClientFactory.CreateClient("AdminApi");
    var response = await client.GetAsync("/products");
    response.EnsureSuccessStatusCode();

    var products = await response.Content.ReadFromJsonAsync<List<string>>();
    return Results.Ok(products);
})
.WithName("GetAdminProducts")
.WithOpenApi();

app.Run();