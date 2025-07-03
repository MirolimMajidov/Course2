var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.BankManagementSystem_API>("BankSystem");
builder.AddProject<Projects.EmptyWebApplication>("EmptyWebApp");

builder.Build().Run();