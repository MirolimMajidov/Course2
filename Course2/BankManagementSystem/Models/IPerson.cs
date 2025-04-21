namespace BankManagementSystem.Models;

public interface IPerson
{
    Guid Id { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    public int Age { get; set; }
}