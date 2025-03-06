namespace MyFirstApp.Models;

public class User
{
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
        }
    }

    public required string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int Age { get; set; }

    public User(int id)
    {
        Id = id;
    }

    public User(int id, string email) : this(id)
    {
        Email = email;
    }

    public void DoWork()
    {
        
    }

    ~User()
    {
    }
}

public class TestClass(int Id, string FirstName, string LastName, string Email, string Password);