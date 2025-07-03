using BankManagementSystem.Application.Repositories;
using BankManagementSystem.Domain.Models;
using BankManagementSystem.Infrastructure.Database;

namespace BankManagementSystem.Infrastructure.Repositories;

public class BranchRepository(BankContext context) : Repository<Branch>(context), IBranchRepository
{
}