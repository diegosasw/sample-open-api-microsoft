using System.Reflection;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var isOpenApiExecution = Assembly.GetEntryAssembly()?.GetName().Name == "GetDocument.Insider"; // See workaround https://github.com/dotnet/aspnetcore/issues/54698#issuecomment-2312500285
Console.WriteLine($"Is OpenApi: {isOpenApiExecution}");
if (!isOpenApiExecution)
{
    throw new Exception("Sample exception to demonstrate that Api Description build should skip this");
}

builder.Services.AddOpenApi();

builder.Services.AddCors(
    options =>
        options
            .AddPolicy(
                "AllowAll",
                policy =>
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()));

var app = builder.Build();

app.UseCors("AllowAll");
app.MapGet("/", () => "Hello World!");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.Run();