using DotNetEnv;
using Persistence.Extensions;


var builder = WebApplication.CreateBuilder(args);

Env.Load("../.env");

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.MapOpenApi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();