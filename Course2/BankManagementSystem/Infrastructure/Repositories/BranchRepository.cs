using BankManagementSystem.Infrastructure.Database;
using BankManagementSystem.Models;

namespace BankManagementSystem.Infrastructure.Repositories;

public class BranchRepository(BankContext context) : Repository<Branch>(context), IBranchRepository
{
}