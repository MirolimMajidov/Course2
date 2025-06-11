using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankManagementSystem.Models;

public abstract class Person : IPerson, IWork
{
    // [Key]
    public Guid Id { get; set; }

    // [MaxLength(30), Column("Name"), Required]
    public string FirstName { get; set; }

    // [NotMapped]
    public string LastName { get; set; }
    
    public string FullName { get; set; }

    public int Age { get; set; }
    
    public bool IsDeleted { get; set; }
    
    int IPerson.Age
    {
        get => (int)Age * 2;
        set => Age = value;
    }

    public Person(Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
    }

    public virtual void DoWork()
    {
        Console.WriteLine("Doing work...");
    }
}