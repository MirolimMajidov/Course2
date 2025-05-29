namespace BankManagementSystem.Models;

public sealed class Worker : Person
{
    public Guid BranchId { get; set; }
    
    public Branch Branch { get; set; }
    
    public decimal Salary { get; set; }
}