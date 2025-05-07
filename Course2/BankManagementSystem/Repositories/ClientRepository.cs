using BankManagementSystem.Models;

namespace BankManagementSystem.Repositories;

public class ClientRepository : IClientRepository
{
    private static readonly Dictionary<Guid, Client> Clients =  [
    ];
    
    public IEnumerable<Client> GetAll()
    {
        return Clients.Values;
    }

    public Client GetById(Guid id)
    {
        Clients.TryGetValue(id, out var client);

        return client;
    }

    public void Add(Client client)
    {
        Clients.Add(client.Id, client);
    }

    public bool TryUpdate(Guid id, Client client)
    {
        if (!Clients.ContainsKey(id)) return false;
        
        Clients[id] = client;
        return true;
    }

    public Client Delete(Guid id)
    {
        Clients.TryGetValue(id, out var client);
        if (client is not null)
            Clients.Remove(id);

        return client;
    }
}