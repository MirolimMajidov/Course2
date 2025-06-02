using System.ComponentModel;
using BankManagementSystem.Infrastructure.Convertors;
using BankManagementSystem.Infrastructure.EntityConfigurations;
using BankManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BankManagementSystem.Database;

public class BankContext : DbContext
{
    public DbSet<Person> People { get; set; }
    public DbSet<Worker> Workers { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Branch> Branches { get; set; }

    public BankContext(DbContextOptions<BankContext> options) : base(options)
    {
        //Database.EnsureCreated();
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     if (optionsBuilder.IsConfigured)
    //     {
    //         optionsBuilder.UseSqlServer("server=localhost;integrated security=True; user: password: database=BankDb;TrustServerCertificate=true;");
    //     }
    // }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Person>(entity =>
        // {
        //     entity.Property(p => p.FirstName)
        //         .HasMaxLength(30)
        //         .HasColumnName("Name")
        //         .IsRequired();
        //    
        //     entity.Property(p => p.LastName)
        //         .HasMaxLength(15);
        // });
        //
        // modelBuilder.Entity<Client>(entity =>
        // {
        //     entity.HasIndex(p => p.Nickname)
        //         .IsUnique();
        // });

        // modelBuilder.ApplyConfiguration(new PersonConfiguration());
        // modelBuilder.ApplyConfiguration(new ClientConfiguration());
        
        var assembly = typeof(PersonConfiguration).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        
        base.OnModelCreating(modelBuilder);
    }
    
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<DateTimeOffset>()
            .HaveConversion<DateTimeOffSetConvertor>();
    }
}