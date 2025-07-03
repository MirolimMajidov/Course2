using BankManagementSystem.API.Infrastructure.Database;
using BankManagementSystem.API.Models;

namespace BankManagementSystem.API.Infrastructure.Repositories;

public class BranchRepository(BankContext context) : Repository<Branch>(context), IBranchRepository
{
}