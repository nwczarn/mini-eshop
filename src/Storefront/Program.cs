using Storefront.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.WebHost.UseUrls("http://0.0.0.0:8080");

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapStorefrontEndpoints();

app.Run();