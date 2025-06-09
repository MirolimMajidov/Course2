using BankManagementSystem.Models;

namespace BankManagementSystem.Infrastructure.Repositories;

public interface IClientRepository : IRepository<Client>
{
    public IEnumerable<Client> TopTenClients(int count);
}