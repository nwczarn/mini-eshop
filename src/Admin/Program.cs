using Admin.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.WebHost.UseUrls("http://0.0.0.0:8081");

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapAdminEndpoints();

app.Run();