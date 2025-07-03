using BankManagementSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankManagementSystem.Infrastructure.EntityConfigurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> entityBuilder)
    {
        entityBuilder.ToTable("People");

        entityBuilder.Property(p => p.FirstName)
            .HasMaxLength(30)
            .HasColumnName("Name")
            .IsRequired();

        entityBuilder.Property(p => p.LastName)
            .HasMaxLength(15);

        entityBuilder.HasQueryFilter(p => !p.IsDeleted);
    }
}