namespace BankManagementSystem.API.Models;

public interface IPerson : IEntity
{
    string FirstName { get; set; }
    string LastName { get; set; }
    public int Age { get; set; }
}