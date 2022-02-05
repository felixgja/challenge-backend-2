using ControleFinanceiro.Domain.Models;
using ControleFinanceiro.Domain.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.Infrastructure.Configurations;
public class DespesasBuilder : IEntityTypeConfiguration<Despesa>
{
    public void Configure(EntityTypeBuilder<Despesa> builder)
    {
        builder.ToTable("Despesas");

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Descricao)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Categoria)
            .HasConversion<string>()
            .HasMaxLength(30)
            .HasDefaultValue(CategoriaType.Outras);

        builder.Property(x => x.Valor)
            .IsRequired()
            .HasPrecision(12,2);
            
        builder.Property(x => x.Data)
            .IsRequired();
        
    }
}