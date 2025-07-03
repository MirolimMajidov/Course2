using BankManagementSystem.Application.Repositories;
using BankManagementSystem.Domain.Models;
using BankManagementSystem.Infrastructure.Database;

namespace BankManagementSystem.Infrastructure.Repositories;

public class ClientRepository(BankContext context) : Repository<Client>(context), IClientRepository
{
    public IEnumerable<Client> TopTenClients(int count)
    {
        throw new NotImplementedException();
    }
}