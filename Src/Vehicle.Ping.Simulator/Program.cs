using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Http;
using Vehicle.Ping.Simulator;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<Worker>();

builder.Services.AddHttpClient();

// After all AddHttpClient registrations.
builder.Services.RemoveAll<IHttpMessageHandlerBuilderFilter>();

var app = builder.Build();

app.MapGet("/", () => "Hello World");

app.Run();