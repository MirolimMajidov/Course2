using BankManagementSystem.Database;
using BankManagementSystem.Models;

namespace BankManagementSystem.Repositories;

public class WorkerRepository(BankContext context) : Repository<Worker>(context), IWorkerRepository
{
}