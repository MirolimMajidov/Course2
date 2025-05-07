using BankManagementSystem.Models;

namespace BankManagementSystem.Repositories;

public interface IWorkerRepository
{
    IEnumerable<Worker> GetAll();
    
    Worker GetById(Guid id);
    
    void Add(Worker worker);
    
    bool TryUpdate(Guid id, Worker worker);
    
    Worker Delete(Guid id);
}