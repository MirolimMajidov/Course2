namespace MyFirstApp.Models;

internal class User
{
    public static EventHandler<DoWorkEventArgs> UserCreated;
    public EventHandler OnStartingWork;

    public int Id { get; }

    private string _firstName;

    public string FirstName
    {
        get
        {
            if (_firstName == null)
                return "Ali";

            return _firstName;
        }
        set
        {
            if (value == null)
            {
                _firstName = "User";
            }

            _firstName = value;
        }
    }

    public string LastName { get; set; }
    public string Email { get; set; }

    public string Password { get; set; }
    public int Age { get; set; }

    public int? Level { get; set; }

    public static int Counter { get; set; }

    public int Balance { get; set; }

    public User()
    {
        Email = "User";
        //FirstName = "Ali";
        Counter++;

        var eventArgs = new DoWorkEventArgs
        {
            UserName = Email
        };

        UserCreated?.Invoke(this, eventArgs);
    }

    // public User(Notifier notifier)
    // {
    //     Email = "User";
    //     Counter++;
    //
    //     // switch (type)
    //     // {
    //     //     case "sms":
    //     //         MyNotifier.SmsSender("sd");
    //     //         break;
    //     //     case "telegram":
    //     //         MyNotifier.TelegramNotifier("sd");
    //     //     break;
    //     // }
    //
    //     notifier("User created.");
    // }

    public User(int id)
    {
        Id = id;
    }

    public User(int id, string name) : this(id)
    {
        FirstName = name;
    }

    public void DoWork()
    {
        OnStartingWork?.Invoke(this, null);
    }

    ~User()
    {
    }
    
    Lock _lockBalance = new Lock();
    public void Withdraw(int amount)
    {
        lock (_lockBalance)
        {
            if (Balance > 0)
            {
                if (Balance >= amount)
                {
                    Balance -= amount;
                }
                else
                {
                    throw new Exception("Not enough balance.");
                }
            }
        }
    }
}

public class TestClass(int Id, string FirstName, string LastName, string Email, string Password);

public class SmsSender
{
    public static void Send(string message)
    {
    }

    public void Send2(string message)
    {
    }
}