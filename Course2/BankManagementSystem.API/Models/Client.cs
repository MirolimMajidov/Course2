namespace BankManagementSystem.API.Models;

public class Client : Person
{
    public string Email { get; set; }

    public string Password { get; set;}

    public string UserName { get; set;}

    public Client()
    {
        UserName = Guid.NewGuid().ToString();
    }

    public override void DoWork()
    {
        Console.WriteLine("Client is doing work...");
    }
}