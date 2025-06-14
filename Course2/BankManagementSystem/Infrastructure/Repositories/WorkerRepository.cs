using BankManagementSystem.Infrastructure.Database;
using BankManagementSystem.Models;

namespace BankManagementSystem.Infrastructure.Repositories;

public class WorkerRepository(BankContext context) : Repository<Worker>(context), IWorkerRepository
{
}