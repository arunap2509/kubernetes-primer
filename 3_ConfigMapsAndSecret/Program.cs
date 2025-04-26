
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.Configure<Config>(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/name", (IOptions<Config> options) =>
{
    var job = Environment.GetEnvironmentVariable("JOB_ENV_VARIABLE");
    return $"{options.Value.Name} and i am an {job}";
});

app.Run();

internal class Config
{
    public string Name { get; set; } = "";
    public string Job { get; set; } = "";
}
