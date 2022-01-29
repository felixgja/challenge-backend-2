using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace challenge_backend_2.Models.ModelBuilders
{
    public class ReceitasBuilder : IEntityTypeConfiguration<Receita>
    {
        public void Configure(EntityTypeBuilder<Receita> builder)
        {
            builder.ToTable("Receitas");

            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Valor)
                .IsRequired()
                .HasPrecision(12,2);
                
            builder.Property(x => x.Data)
                .IsRequired();
            
        }
    }
}