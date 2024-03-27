using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PruebaTecnicaCycle.Infrastructure;

namespace PruebaTecnicaCycle.Infrastructure.database
{
    public partial class PruebaTecnicaCycleContext : DbContext
    {
        public PruebaTecnicaCycleContext()
        {
        }

        public PruebaTecnicaCycleContext(DbContextOptions<PruebaTecnicaCycleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=IVO\\SQLEXPRESS;Database=PruebaTecnicaCycle;Trusted_Connection=true;Trust Server Certificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasNoKey();

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
