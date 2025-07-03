using BankManagementSystem.Domain.Models;

namespace BankManagementSystem.Application.Repositories;

public interface IClientRepository : IRepository<Client>
{
    public IEnumerable<Client> TopTenClients(int count);
}