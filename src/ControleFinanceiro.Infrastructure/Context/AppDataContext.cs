using ControleFinanceiro.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Infrastructure.Context;
public class AppDataContext : DbContext
{
    public AppDataContext(){}
    
    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDataContext).Assembly);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var connectionString = "server=localhost;userid=challenge;password=challenge;database=challengeback";
        var version = ServerVersion.AutoDetect(connectionString);
        optionsBuilder.UseMySql(connectionString, version);
    }

    public DbSet<Despesa> Despesas { get; set; }
    public DbSet<Receita> Receitas { get; set; }
}