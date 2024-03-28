using Microsoft.EntityFrameworkCore;
using PruebaTecnicaCycle.Domain.Entities;

namespace PruebaTecnicaCycle.Infrastructure.Database
{
    public partial class CycleContext : DbContext
    {
        public CycleContext()
        {
        }

        public CycleContext(DbContextOptions<CycleContext> options) : base(options) { }

        public virtual DbSet<Producto> Productos { get; set; } = null!;

        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer();
            }
        } */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(entity =>
            {
                /* entity.HasNoKey(); */

                entity.ToTable("Productos", "Catalogo");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Imagen).IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("numeric(10, 2)");
            });

            base.OnModelCreating(modelBuilder);
        }

        /* partial void OnModelCreatingPartial(ModelBuilder modelBuilder); */
    }
}
