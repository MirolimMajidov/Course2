using BankManagementSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankManagementSystem.Infrastructure.EntityConfigurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> entityBuilder)
    {
        entityBuilder.HasIndex(p => p.UserName)
            .IsUnique();

        entityBuilder.Property(p => p.Password).IsRequired(false);
        entityBuilder.Property(p => p.Email).IsRequired(false);

        Client[] entities =
        [
            new Client
            {

            }
        ];
        // entityBuilder.HasData(entities);
    }
}