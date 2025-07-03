namespace BankManagementSystem.Domain.Models;

public class Branch : IEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public string FullName { get; set; }
    
    public string Address { get; set; }
    
    public virtual List<Worker> Workers { get; set; } = new();
    
    public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;
} 