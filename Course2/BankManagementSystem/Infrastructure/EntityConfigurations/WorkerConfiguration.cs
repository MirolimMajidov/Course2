using BankManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankManagementSystem.Infrastructure.EntityConfigurations;

public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
{
    public void Configure(EntityTypeBuilder<Worker> entityBuilder)
    {
        entityBuilder.HasOne(p => p.Branch)
            .WithMany(r => r.Workers)
            .HasForeignKey(r => r.BranchId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}