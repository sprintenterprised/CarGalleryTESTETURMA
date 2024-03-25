using CarGallery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarGallery.Mapping
{
    public class FabricanteMapping : IEntityTypeConfiguration<Fabricante>
    {
        public void Configure(EntityTypeBuilder<Fabricante> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Nome).IsRequired().HasMaxLength(250);
            builder.Property(e => e.Descricao).HasMaxLength(1024);

            builder.HasMany(e => e.Carros).WithOne(); 
        }
    }
}
