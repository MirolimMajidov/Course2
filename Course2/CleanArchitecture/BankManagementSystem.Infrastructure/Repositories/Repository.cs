using BankManagementSystem.Application.Repositories;
using BankManagementSystem.Domain.Models;
using BankManagementSystem.Infrastructure.Database;

namespace BankManagementSystem.Infrastructure.Repositories;

public class Repository<TEntity>(BankContext context) : IRepository<TEntity>
    where TEntity : class, IEntity
{
    public IQueryable<TEntity> GetAll()
    {
        return context.Set<TEntity>();
    }
    
    public IQueryable<TEntity> GetAll(int pageSize, int pageNumber)
    {
        var totalCount = context.Set<TEntity>().Count();
        var pagesCount = (int)Math.Ceiling((double)totalCount / pageSize);
        var skipCount = pageSize * (pageNumber - 1);
        return context.Set<TEntity>()
            .Skip(skipCount)
            .Take(pageSize);
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
            context.Remove(entity);
            context.SaveChanges();
        }

        return entity;
    }
}