using System.Text.Json.Serialization;
using BankManagementSystem.Application.Auth;
using BankManagementSystem.Application.Repositories;
using BankManagementSystem.Application.Services;
using BankManagementSystem.Domain.Models;
using BankManagementSystem.Infrastructure.Database;
using BankManagementSystem.Infrastructure.Extensions;
using BankManagementSystem.Infrastructure.Interceptors;
using BankManagementSystem.Infrastructure.Mappers;
using BankManagementSystem.Infrastructure.Repositories;
using BankManagementSystem.Infrastructure.Validations;
using BankManagementSystem.Presentation.Extensions;
using BankManagementSystem.Presentation.Middlewares;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyServiceDefaults;
using Serilog;
using Serilog.Events;

try
{
    var logFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
    Log.Logger = new LoggerConfiguration()
        .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Error)
        .WriteTo.File($"{logFolder}/MyLogs.txt", rollingInterval: RollingInterval.Day)
        .WriteTo.File($"{logFolder}/MyErrorLogs.txt", restrictedToMinimumLevel: LogEventLevel.Error,
            rollingInterval: RollingInterval.Day)
        .CreateLogger();

    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddSerilog();
    builder.Services.AddMyAuth();

    builder.Services.AddLogging(op =>
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
    builder.AddServiceDefaults();
    builder.Services.AddControllers(options => { options.Filters.Add<ActionAndResultHandler>(); })
        .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

    builder.Services.AddOpenApi();
    builder.Services.AddSingleton<AvoidDeletingPersonInterceptor>();

    var databaseConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    // if (builder.Environment.IsEnvironment("Test"))
    // {
    //     builder.Services.AddDbContext<BankContext>(options => { options.UseInMemoryDatabase("InMemoryBankTest"); });
    // }
    // else
    // {
    builder.Services.AddDbContext<BankContext>((sp, options) =>
    {
        options.UseSqlServer(databaseConnectionString)
            //.LogTo(Console.WriteLine, LogLevel.Information)
            //.UseLazyLoadingProxies()
            .AddInterceptors(sp.GetRequiredService<AvoidDeletingPersonInterceptor>())
            ;
    });
    // }

    builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    builder.Services.AddScoped<IClientRepository, ClientRepository>();
    builder.Services.AddScoped<IWorkerRepository, WorkerRepository>();
    builder.Services.AddScoped<IBranchRepository, BranchRepository>();

    builder.Services.AddScoped<IClientService, ClientService>();

    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bank application APIs", Version = "v1" });

        // Add the JWT Bearer authentication scheme
        var securityScheme = new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Description = "JWT Authorization header using the Bearer scheme.",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
        };
        c.AddSecurityDefinition("Bearer", securityScheme);

        // Use the JWT Bearer authentication scheme globally
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            { securityScheme, new List<string>() }
        });
    });
    builder.Services.AddAutoMapper(op => { op.AddMaps(typeof(ClientProfile).Assembly); });
    builder.Services.AddMapster();
    builder.Services.AddValidatorsFromAssemblyContaining<CreateClientValidator>();

    var app = builder.Build();

    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<BankContext>();
        // if (app.Environment.IsEnvironment("Test"))
        // {
        //     dbContext.Database.EnsureCreated();
        // }
        // else
        // {
        dbContext.Database.Migrate();
        // }

        if (!dbContext.Clients.Any())
        {
            var localTime = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
            var offset = TimeZoneInfo.Local.GetUtcOffset(localTime);
            var dto = new DateTimeOffset(localTime, offset);

            var branch = new Branch
            {
                Id = Guid.NewGuid(),
                FullName = "Main Branch",
                Address = "Khujand",
                CreatedOn = dto
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
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapAllMinimalAPIs();
    app.MapControllers();

    app.Run();
}
catch (Exception ex) when (ex is not HostAbortedException)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}