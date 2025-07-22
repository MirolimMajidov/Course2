using EventBus.RabbitMQ.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRabbitMqEventBus(builder.Configuration, assemblies: [typeof(Program).Assembly]);

builder.Services.AddRabbitMqEventBus(builder.Configuration,
    assemblies: [typeof(Program).Assembly],
    defaultOptions: options =>
    {
        options.HostName = "localhost";
        options.UserName = "admin";
        options.Password = "admin123";
        options.HostPort = 5672;
        options.UseInbox = false;
    }
    // eventStoreOptions: options =>
    // {
    //     options.Inbox.IsEnabled = false;
    //     options.Outbox.IsEnabled = false;
    // }
    //
);
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();