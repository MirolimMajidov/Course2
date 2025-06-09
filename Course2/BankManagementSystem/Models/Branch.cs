namespace BankManagementSystem.Models;

public class Branch : IEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public string Name { get; set; }
    
    public string Location { get; set; }
    
    public virtual List<Worker> Workers { get; set; } = new();
    
    public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;
} 