using System.Text.Json.Serialization;
using BankManagementSystem.Extensions;
using BankManagementSystem.Infrastructure.Database;
using BankManagementSystem.Infrastructure.Interceptors;
using BankManagementSystem.Infrastructure.Repositories;
using BankManagementSystem.Mappers;
using BankManagementSystem.Middlewares;
using BankManagementSystem.Models;
using BankManagementSystem.Services;
using BankManagementSystem.Validations;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(op=>
{
    op.AddConsole(ops =>
    {
        ops.IncludeScopes = true;
        ops.TimestampFormat = "yyyy-MM-dd HH:mm:ss ";
    });
   
    op.AddFilter("Microsoft.AspNetCore.*", LogLevel.Warning);
    //op.AddFilter("System", LogLevel.Warning);
    //op.AddFilter("Default", LogLevel.Information);
});
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddOpenApi();
builder.Services.AddSingleton<AvoidDeletingPersonInterceptor>();

var databaseConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BankContext>((sp, options) =>
{
    options.UseSqlServer(databaseConnectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        //.UseLazyLoadingProxies()
        .AddInterceptors(sp.GetRequiredService<AvoidDeletingPersonInterceptor>())
        ;
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IWorkerRepository, WorkerRepository>();;
builder.Services.AddScoped<IBranchRepository, BranchRepository>();

builder.Services.AddScoped<IClientService, ClientService>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bank application APIs", Version = "v1" });
});
builder.Services.AddAutoMapper(op => { op.AddMaps(typeof(ClientProfile).Assembly); });
builder.Services.AddMapster();
builder.Services.AddValidatorsFromAssemblyContaining<CreateClientValidator>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<BankContext>();
    dbContext.Database.Migrate();
    if (!dbContext.Clients.Any())
    {
        var branch = new Branch
        {
            Id = Guid.NewGuid(),
            FullName = "Main Branch",
            Address = "Khujand",
            CreatedOn = new DateTimeOffset(DateTime.Now, TimeSpan.FromHours(5))
        };
        var branch2 = new Branch
        {
            Id = Guid.NewGuid(),
            FullName = "Isfara Branch",
            Address = "Isfara",
            //CreatedOn = new DateTimeOffset(DateTime.Now, TimeSpan.FromHours(3))
        };
        var branch3 = new Branch
        {
            Id = Guid.NewGuid(),
            FullName = "Isfara Branch",
            Address = "Dushanbe",
            // CreatedOn = new DateTimeOffset(DateTime.Now, TimeSpan.FromHours(-2))
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
            BranchId = branch.Id,
            IsDeleted = true
        };

        var client1 = new Client
        {
            Id = Guid.NewGuid(),
            FirstName = "John",
            LastName = "Doe"
        };
        var client2 = new Client
        {
            Id = Guid.NewGuid(),
            FirstName = "Jane",
            LastName = "Smith",
            IsDeleted = true
        };

        dbContext.AddRange(branch, branch2, branch3);
        dbContext.AddRange(worker, worker2);
        dbContext.AddRange(client1, client2);

        dbContext.SaveChanges();
    }
}

if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options => { options.EnableTryItOutByDefault(); });
}

app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapAllMinimalAPIs();
app.MapControllers();

app.Run();