using BankManagementSystem.Domain.Models;

namespace BankManagementSystem.Application.Repositories;

public interface IRepository<TEntity>
    where TEntity : class, IEntity
{
    IQueryable<TEntity> GetAll();
    
    TEntity GetById(Guid id);
    
    void Add(TEntity entity);
    
    bool TryUpdate(Guid id, TEntity entity);
    
    TEntity Delete(Guid id);
}