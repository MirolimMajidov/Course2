using System.Text.Json.Serialization;
using BankManagementSystem.Database;
using BankManagementSystem.Extensions;
using BankManagementSystem.Mappers;
using BankManagementSystem.Middlewares;
using BankManagementSystem.Models;
using BankManagementSystem.Repositories;
using BankManagementSystem.Services;
using BankManagementSystem.Validations;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddOpenApi();

var databaseConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BankContext>(options =>
{
    options.UseSqlServer(databaseConnectionString);
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IWorkerRepository, WorkerRepository>();

builder.Services.AddScoped<IClientService, ClientService>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bank application APIs", Version = "v1" });
});
builder.Services.AddAutoMapper(op=>
{
    op.AddMaps(typeof(ClientProfile).Assembly);
});
builder.Services.AddMapster();
builder.Services.AddValidatorsFromAssemblyContaining<CreateClientValidator>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<BankContext>();
    dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated();

    var branch = new Branch
    {
        Id = Guid.NewGuid(),
        Name = "Main Branch",
        Location = "Khujand",
    };
    
    var worker = new Worker
    {
        Id = Guid.NewGuid(),
        FirstName = "John",
        LastName = "Doe",
        BranchId = branch.Id
    };
    var worker2 = new Worker
    {
        Id = Guid.NewGuid(),
        FirstName = "Jane",
        LastName = "Smith",
        BranchId = branch.Id
    };

    dbContext.Add(branch);
    dbContext.AddRange(worker, worker2);

    dbContext.SaveChanges();
}

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
