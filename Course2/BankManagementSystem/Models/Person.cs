namespace BankManagementSystem.Models;

public abstract class Person
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Age { get; set; }

    public Person(Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
    }

    public virtual void DoWork()
    {
        Console.WriteLine("Doing work...");
    }

    public abstract string GetActualType();
}