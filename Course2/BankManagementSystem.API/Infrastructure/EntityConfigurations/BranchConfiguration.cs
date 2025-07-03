using BankManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankManagementSystem.API.Infrastructure.EntityConfigurations;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> entityBuilder)
    {
        entityBuilder.HasKey(b=>b.Id);
        // entityBuilder.Navigation(b => b.Workers)
        //     .AutoInclude();
    }
}