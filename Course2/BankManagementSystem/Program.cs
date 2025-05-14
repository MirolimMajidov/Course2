using BankManagementSystem.Extensions;
using BankManagementSystem.Mappers;
using BankManagementSystem.Middlewares;
using BankManagementSystem.Repositories;
using BankManagementSystem.Services;
using BankManagementSystem.Validations;
using FluentValidation;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddSingleton<IClientRepository, ClientRepository>();
builder.Services.AddSingleton<IWorkerRepository, WorkerRepository>();

builder.Services.AddScoped<IClientService, ClientService>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bank application APIs", Version = "v1" });
});
builder.Services.AddAutoMapper(op=>
{
    op.AddMaps(typeof(ClientProfile).Assembly);
    //op.AddProfile<ClientProfile>();
});
builder.Services.AddMapster();
builder.Services.AddValidatorsFromAssemblyContaining<CreateClientValidator>();

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

app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapAllMinimalAPIs();
app.MapControllers();

app.Run();
