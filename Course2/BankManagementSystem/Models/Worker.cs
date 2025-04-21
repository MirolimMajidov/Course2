namespace BankManagementSystem.Models;

public sealed class Worker : Person
{
    public override string GetActualType()
    {
        return nameof(Worker);
    }
}