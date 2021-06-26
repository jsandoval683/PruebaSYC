using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PruebaDesarrolloSYC.Models
{
    public partial class PruebaDBContext : DbContext
    {
        public PruebaDBContext()
        {
        }

        public PruebaDBContext(DbContextOptions<PruebaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<EstadosFactura> EstadosFacturas { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=PruebaDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.NumeDoc)
                    .HasName("PK__CLIENTES__4D7606B6DF184960");

                entity.ToTable("CLIENTES");

                entity.Property(e => e.NumeDoc)
                    .ValueGeneratedNever()
                    .HasColumnName("NUME_DOC");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DIRECCION");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<EstadosFactura>(entity =>
            {
                entity.HasKey(e => e.CodiEstado)
                    .HasName("PK__ESTADOS___D75086015AD37A4D");

                entity.ToTable("ESTADOS_FACTURA");

                entity.Property(e => e.CodiEstado)
                    .ValueGeneratedNever()
                    .HasColumnName("CODI_ESTADO");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura)
                    .HasName("PK__FACTURA__4A921BEDFAC3E291");

                entity.ToTable("FACTURA");

                entity.Property(e => e.IdFactura).HasColumnName("ID_FACTURA");

                entity.Property(e => e.CodiEstado).HasColumnName("CODI_ESTADO");

                entity.Property(e => e.FechaFac)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_FAC");

                entity.Property(e => e.NumeDoc).HasColumnName("NUME_DOC");

                entity.Property(e => e.ValorFac).HasColumnName("VALOR_FAC");

                entity.HasOne(d => d.CodiEstadoNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.CodiEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FACTURA__CODI_ES__29572725");

                entity.HasOne(d => d.NumeDocNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.NumeDoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FACTURA__FECHA_F__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
