namespace BankManagementSystem.Models;

public class Client : Person
{
    public string Email { get; set; }

    public string Nickname { get; }

    public Client()
    {
        Nickname = Guid.NewGuid().ToString();
    }

    public override void DoWork()
    {
        Console.WriteLine("Client is doing work...");
    }
}