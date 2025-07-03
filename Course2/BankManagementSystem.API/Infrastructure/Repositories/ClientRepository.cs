using BankManagementSystem.API.Infrastructure.Database;
using BankManagementSystem.API.Models;

namespace BankManagementSystem.API.Infrastructure.Repositories;

public class ClientRepository(BankContext context) : Repository<Client>(context), IClientRepository
{
    public IEnumerable<Client> TopTenClients(int count)
    {
        throw new NotImplementedException();
    }
}