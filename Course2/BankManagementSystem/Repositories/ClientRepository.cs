using BankManagementSystem.Models;

namespace BankManagementSystem.Repositories;

public class ClientRepository : Repository<Client>, IClientRepository
{
    public IEnumerable<Client> TopTenClients(int count)
    {
        throw new NotImplementedException();
    }
}