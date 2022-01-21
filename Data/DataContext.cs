using challenge_backend_2.Models;
using Microsoft.EntityFrameworkCore;

namespace challenge_backend_2.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Receita> Receitas {get;set;}
        public DbSet<Despesa> Despesas { get; set; }
    }
}