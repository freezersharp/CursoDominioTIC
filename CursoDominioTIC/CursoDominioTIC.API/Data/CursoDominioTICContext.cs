using CursoDominioTIC.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoDominioTIC.API
{
    public partial class CursoDominioTICContext : DbContext
    {
        public CursoDominioTICContext()
        {
        }

        public CursoDominioTICContext(DbContextOptions<CursoDominioTICContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Establecimiento> Establecimiento { get; set; }
        public virtual DbSet<Favorito> Favorito { get; set; }
        public virtual DbSet<Opinion> Opinion { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=freezersharp.database.windows.net;initial catalog=CursoDominioTIC;user id=freezersharp;password=paolit0!;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK_CategoriaProducto");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Establecimiento>(entity =>
            {
                entity.HasKey(e => e.IdEstablecimiento);

                entity.Property(e => e.Calificacion)
                    .HasColumnType("decimal(5, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Descripcion).HasMaxLength(2000);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Favorito>(entity =>
            {
                entity.HasKey(e => e.IdFavorito);

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUsuario)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.IdEstablecimientoNavigation)
                    .WithMany(p => p.Favorito)
                    .HasForeignKey(d => d.IdEstablecimiento)
                    .HasConstraintName("FK_Favorito_Establecimiento");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Favorito)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Favorito_Usuario");
            });

            modelBuilder.Entity<Opinion>(entity =>
            {
                entity.HasKey(e => e.IdOpinion);

                entity.Property(e => e.Calificacion)
                    .HasColumnType("decimal(5, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IdUsuario)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("P:Producto; E:Establecimiento");

                entity.HasOne(d => d.IdEstablecimientoNavigation)
                    .WithMany(p => p.Opinion)
                    .HasForeignKey(d => d.IdEstablecimiento)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Opinion_Establecimiento");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Opinion)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Opinion_Producto");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Opinion)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Opinion_Usuario");
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.HasKey(e => e.IdPerfil);

                entity.Property(e => e.IdPerfil).HasMaxLength(20);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto);

                entity.Property(e => e.Calificacion).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK_Producto_Categoria");

                entity.HasOne(d => d.IdEstablecimientoNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdEstablecimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_Establecimiento");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.IdUsuario).HasMaxLength(250);

                entity.Property(e => e.Calificacion).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('A')")
                    .HasComment("A: Activo; I: Inactivo");

                entity.Property(e => e.IdPerfil)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Perfil");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
