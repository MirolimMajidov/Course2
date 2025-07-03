using BankManagementSystem.API.Infrastructure.Database;
using BankManagementSystem.API.Models;

namespace BankManagementSystem.API.Infrastructure.Repositories;

public class WorkerRepository(BankContext context) : Repository<Worker>(context), IWorkerRepository
{
}