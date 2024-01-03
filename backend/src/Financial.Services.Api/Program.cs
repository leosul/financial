using Financial.Services.Api.Configurations;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath);
builder.Configuration.AddJsonFile("appsettings.json", true, true);
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true);
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddApiConfiguration(builder.Configuration);
builder.Services.AddSwaggerConfig();

var app = builder.Build();

app.UseSwaggerConfig(app.Services.GetRequiredService<IApiVersionDescriptionProvider>());
app.UseApiConfiguration(builder.Environment);

app.Run();
