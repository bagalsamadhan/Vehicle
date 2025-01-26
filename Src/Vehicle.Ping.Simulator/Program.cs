using Vehicle.Ping.Simulator;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<Worker>();

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapGet("/", () => "Hello World");

app.Run();