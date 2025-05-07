using BankManagementSystem.Extensions;
using BankManagementSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddSingleton<IClientRepository, ClientRepository>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bank application APIs", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.EnableTryItOutByDefault();
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapAllMinimalAPIs();
app.MapControllers();

app.Run();
