using BankManagementSystem.Models;

namespace BankManagementSystem.Repositories;

public interface IClientRepository : IRepository<Client>
{
    public IEnumerable<Client> TopTenClients(int count);
}