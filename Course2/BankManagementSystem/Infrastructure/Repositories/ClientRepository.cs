using BankManagementSystem.Database;
using BankManagementSystem.Models;

namespace BankManagementSystem.Repositories;

public class ClientRepository(BankContext context) : Repository<Client>(context), IClientRepository
{
    public IEnumerable<Client> TopTenClients(int count)
    {
        throw new NotImplementedException();
    }
}