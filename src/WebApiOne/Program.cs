using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// var isOpenApiExecution = builder.Environment.IsEnvironment("ApiDescription");
// if (!isOpenApiExecution)
// {
//     throw new Exception("Sample exception to demonstrate that Api Description build should skip this");
// }

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