namespace BankManagementSystem.Models;

public sealed class Client : Person
{
    public string Email { get; set; }

    public string Nickname { get; }
    
    public new double Age { get; set; }

    public Client(Guid? id = null) : base(id)
    {
        Nickname = Guid.NewGuid().ToString();
    }

    public Client(Guid id, string email) : this(id)
    {
        Id = id;
        Email = email;
    }

    public override string GetActualType()
    {
        return nameof(Client);
    }

    public override void DoWork()
    {
        // base.DoWork();
        //
        // if (Email != null)
        // {
        //     //Do something with Email
        // }
        Console.WriteLine("Client is doing work...");
    }
}