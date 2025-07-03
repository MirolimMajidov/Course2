using BankManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankManagementSystem.API.Infrastructure.EntityConfigurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> entityBuilder)
    {
        entityBuilder.HasIndex(p => p.UserName)
            .IsUnique();
    }
}