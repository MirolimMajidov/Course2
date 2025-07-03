using BankManagementSystem.Application.Repositories;
using BankManagementSystem.Domain.Models;
using BankManagementSystem.Infrastructure.Database;

namespace BankManagementSystem.Infrastructure.Repositories;

public class WorkerRepository(BankContext context) : Repository<Worker>(context), IWorkerRepository
{
}