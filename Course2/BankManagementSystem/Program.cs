using BankManagementSystem.Models;
using Microsoft.OpenApi.Models;


var client = new Client();
client.DoWork();
var type = client.GetActualType();
Console.WriteLine(type);

var worker = new Worker();
worker.DoWork();

client.Age = 20;
var person = (Person)client;
person.Age = 25;

Console.WriteLine("Client Age: " + client.Age);
Console.WriteLine("Person Age: " + person.Age);

/*
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

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
app.MapControllers();

app.Run();
*/