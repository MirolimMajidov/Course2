using BankManagementSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BankManagementSystem.Infrastructure.Interceptors;

public class AvoidDeletingPersonInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context is not null)
            UpdateEntities(eventData.Context);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        if (eventData.Context is not null)
            UpdateEntities(eventData.Context);
        
        return base.SavingChanges(eventData, result);
    }

    private static void UpdateEntities(DbContext context)
    {
        var entities = context.ChangeTracker.Entries<Person>().ToList();

        foreach (EntityEntry<Person> entry in entities)
        {
            if (entry.State == EntityState.Deleted)
            {
                if(entry.Entity.LastName == "Admin" || entry.Entity.FirstName == "Admin")
                {
                    entry.State = EntityState.Detached;
                }
                else
                {
                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted = true;
                }
            }
        }
    }
}