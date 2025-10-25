using Scalar.AspNetCore;
using SimpleSubscription.API.Endpoints;
using SimpleSubscription.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiServices();

builder.Services.AddOpenApi();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapSubscriptionEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

await app.RunAsync();

