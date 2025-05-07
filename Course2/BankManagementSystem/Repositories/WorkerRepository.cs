using BankManagementSystem.Models;

namespace BankManagementSystem.Repositories;

public class WorkerRepository : IWorkerRepository
{
    private static readonly Dictionary<Guid, Worker> Workers =  [
    ];
    
    public IEnumerable<Worker> GetAll()
    {
        return Workers.Values;
    }

    public Worker GetById(Guid id)
    {
        Workers.TryGetValue(id, out var client);

        return client;
    }

    public void Add(Worker client)
    {
        Workers.Add(client.Id, client);
    }

    public bool TryUpdate(Guid id, Worker worker)
    {
        if (!Workers.ContainsKey(id)) return false;
        
        Workers[id] = worker;
        return true;
    }

    public Worker Delete(Guid id)
    {
        Workers.TryGetValue(id, out var client);
        if (client is not null)
            Workers.Remove(id);

        return client;
    }
}