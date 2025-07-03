namespace BankManagementSystem.Domain.Models;

public class Worker : Person
{
    public Guid BranchId { get; set; }
    
    public virtual Branch Branch { get; set; }
    
    public decimal Salary { get; set; }
}