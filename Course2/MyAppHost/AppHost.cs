var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.BankManagementSystem>("BankSystem");
builder.AddProject<Projects.EmptyWebApplication>("EmptyWebApp");

builder.Build().Run();