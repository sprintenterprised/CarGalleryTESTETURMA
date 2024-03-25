using CarGallery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarGallery.Mapping
{
    public class CarroMapping : IEntityTypeConfiguration<Carro>
    {
        public void Configure(EntityTypeBuilder<Carro> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Nome).IsRequired().HasMaxLength(250);
            builder.Property(e => e.DescricaoCurta).HasMaxLength(600);
            builder.Property(e => e.DescricaoLonga).HasMaxLength(1024);
            builder.Property(e => e.Imagem).IsRequired().HasMaxLength(2000);
        }
    }
}
