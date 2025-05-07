using BankManagementSystem.Models;

namespace BankManagementSystem.Repositories;

public interface IClientRepository
{
    IEnumerable<Client> GetAll();
    
    Client GetById(Guid id);
    
    void Add(Client client);
    
    bool TryUpdate(Guid id, Client client);
    
    Client Delete(Guid id);
}