using BankManagementSystem.Models;

namespace BankManagementSystem.Repositories;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class, IEntity
{
    private readonly Dictionary<Guid, TEntity> Entities =  [
    ];
    
    public IEnumerable<TEntity> GetAll()
    {
        return Entities.Values;
    }

    public TEntity GetById(Guid id)
    {
        Entities.TryGetValue(id, out var entity);

        return entity;
    }

    public void Add(TEntity entity)
    {
        Entities.Add(entity.Id, entity);
    }

    public bool TryUpdate(Guid id, TEntity entity)
    {
        if (!Entities.ContainsKey(id)) return false;
        
        Entities[id] = entity;
        return true;
    }

    public TEntity Delete(Guid id)
    {
        Entities.TryGetValue(id, out var entity);
        if (entity is not null)
            Entities.Remove(id);

        return entity;
    }
}