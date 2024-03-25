using System.Reflection.Emit;
using CarGallery.Mapping;
using CarGallery.Models;
using Microsoft.EntityFrameworkCore;

namespace CarGallery
{
    public class CarGalleryContext : DbContext
    {
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Carro> Carros { get; set; }
        public CarGalleryContext(DbContextOptions<CarGalleryContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuider)
        {

            modelBuider.ApplyConfiguration(new FabricanteMapping());
            modelBuider.ApplyConfiguration(new CarroMapping());


            base.OnModelCreating(modelBuider);
        }
    }
}
