using BankManagementSystem.Database;
using BankManagementSystem.Models;

namespace BankManagementSystem.Repositories;

public class Repository<TEntity>(BankContext context) : IRepository<TEntity>
    where TEntity : class, IEntity
{
    public IQueryable<TEntity> GetAll()
    {
        return context.Set<TEntity>();
    }

    public TEntity GetById(Guid id)
    {
        var entity = context.Find<TEntity>(id);

        return entity;
    }

    public void Add(TEntity entity)
    {
        context.Add(entity);
        context.SaveChanges();
    }

    public bool TryUpdate(Guid id, TEntity entity)
    {
        context.Update(entity);
        
        return context.SaveChanges() > 0;
    }

    public TEntity Delete(Guid id)
    {
        var entity = GetById(id);
        if (entity is not null)
        {
            context.Remove(id);
            context.SaveChanges();
        }

        return entity;
    }
}