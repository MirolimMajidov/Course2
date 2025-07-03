using BankManagementSystem.API.Models;

namespace BankManagementSystem.API.Infrastructure.Repositories;

public interface IClientRepository : IRepository<Client>
{
    public IEnumerable<Client> TopTenClients(int count);
}