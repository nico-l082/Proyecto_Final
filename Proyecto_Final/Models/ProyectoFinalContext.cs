using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_Final.Models;

public partial class ProyectoFinalContext : DbContext
{
    public ProyectoFinalContext()
    {
    }

    public ProyectoFinalContext(DbContextOptions<ProyectoFinalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Biblioteca> Bibliotecas { get; set; }

    public virtual DbSet<Juego> Juegos { get; set; }

    public virtual DbSet<Membresium> Membresia { get; set; }

    public virtual DbSet<MiembrosPlu> MiembrosPlus { get; set; }

    public virtual DbSet<TipoMembresium> TipoMembresia { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuariosJuego> UsuariosJuegos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Nico_Desktop;Initial Catalog=Proyecto_Final;User ID=sa;Password=Malg123;Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.IdAdmin).HasName("PK__Admin__B2C3ADE5F2A5DF96");

            entity.ToTable("Admin");

            entity.Property(e => e.IdAdmin).HasColumnName("idAdmin");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Biblioteca>(entity =>
        {
            entity.HasKey(e => e.IdBiblio).HasName("PK__Bibliote__C721831F871764D8");

            entity.ToTable("Biblioteca");

            entity.HasIndex(e => e.Juegos, "IX_Biblioteca_juegos");

            entity.Property(e => e.IdBiblio).HasColumnName("idBiblio");
            entity.Property(e => e.Juegos).HasColumnName("juegos");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.JuegosNavigation).WithMany(p => p.Bibliotecas)
                .HasForeignKey(d => d.Juegos)
                .HasConstraintName("biblio_Juego_fk");
        });

        modelBuilder.Entity<Juego>(entity =>
        {
            entity.HasKey(e => e.IdJuegos).HasName("PK__Juegos__E4EEF679CB006B0B");

            entity.HasIndex(e => e.ItiPlus, "IX_Juegos_itiPlus");

            entity.Property(e => e.IdJuegos).HasColumnName("idJuegos");
            entity.Property(e => e.Desarrolladora)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("desarrolladora");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Genero)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("genero");
            entity.Property(e => e.ImagenUrl)
                .HasMaxLength(225)
                .IsUnicode(false)
                .HasColumnName("imagenURL");
            entity.Property(e => e.ItiPlus).HasColumnName("itiPlus");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasColumnType("money")
                .HasColumnName("precio");

            entity.HasOne(d => d.ItiPlusNavigation).WithMany(p => p.Juegos)
                .HasForeignKey(d => d.ItiPlus)
                .HasConstraintName("Juegos_TipoMemb_FK");
        });

        modelBuilder.Entity<Membresium>(entity =>
        {
            entity.HasKey(e => e.IdMembresia).HasName("PK__Membresi__BDDB80E94CDE81D8");

            entity.Property(e => e.IdMembresia).HasColumnName("idMembresia");
            entity.Property(e => e.Detalle)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("detalle");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.TipoMembresia).HasColumnName("tipoMembresia");
        });

        modelBuilder.Entity<MiembrosPlu>(entity =>
        {
            entity.HasKey(e => e.IdMiembros).HasName("PK__Miembros__F1261B7C5B75030D");

            entity.HasIndex(e => e.Tipo, "IX_MiembrosPlus_tipo");

            entity.Property(e => e.IdMiembros).HasColumnName("idMiembros");
            entity.Property(e => e.CantidadJuegosMembresia).HasColumnName("cantidadJuegosMembresia");
            entity.Property(e => e.FormaPago)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("formaPago");
            entity.Property(e => e.PrecioMembresia)
                .HasColumnType("money")
                .HasColumnName("precioMembresia");
            entity.Property(e => e.Tipo).HasColumnName("tipo");
            entity.Property(e => e.Vigencia)
                .HasColumnType("datetime")
                .HasColumnName("vigencia");

            entity.HasOne(d => d.TipoNavigation).WithMany(p => p.MiembrosPlus)
                .HasForeignKey(d => d.Tipo)
                .HasConstraintName("Plus_TipoMemb_FK");
        });

        modelBuilder.Entity<TipoMembresium>(entity =>
        {
            entity.HasKey(e => e.IdTipoMembresia).HasName("PK__TipoMemb__1D164B22339793F0");

            entity.HasIndex(e => e.Tipo, "IX_TipoMembresia_tipo");

            entity.Property(e => e.IdTipoMembresia).HasColumnName("idTipoMembresia");
            entity.Property(e => e.Tipo).HasColumnName("tipo");

            entity.HasOne(d => d.TipoNavigation).WithMany(p => p.TipoMembresiaNavigation)
                .HasForeignKey(d => d.Tipo)
                .HasConstraintName("Tipo_Memb_FK");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuarios).HasName("PK__Usuarios__3940559A03D1B9BB");

            entity.HasIndex(e => e.BiblioJuegos, "IX_Usuarios_biblioJuegos");

            entity.HasIndex(e => e.Miembro, "IX_Usuarios_miembro");

            entity.Property(e => e.IdUsuarios).HasColumnName("idUsuarios");
            entity.Property(e => e.BiblioJuegos).HasColumnName("biblioJuegos");
            entity.Property(e => e.CantJuegos).HasColumnName("cantJuegos");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Miembro).HasColumnName("miembro");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreUsuario");

            entity.HasOne(d => d.BiblioJuegosNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.BiblioJuegos)
                .HasConstraintName("usu_biblio_fk");

            entity.HasOne(d => d.MiembroNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Miembro)
                .HasConstraintName("Usu_Memb_fk");
        });

        modelBuilder.Entity<UsuariosJuego>(entity =>
        {
            entity.HasKey(e => e.IdUj).HasName("PK__Usuarios__9DB8000BCA3B98AE");

            entity.Property(e => e.IdUj).HasColumnName("idUJ");
            entity.Property(e => e.FechaCompra)
                .HasColumnType("datetime")
                .HasColumnName("fechaCompra");
            entity.Property(e => e.JuegoId).HasColumnName("juegoId");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Juego).WithMany(p => p.UsuariosJuegos)
                .HasForeignKey(d => d.JuegoId)
                .HasConstraintName("FK_Juego");

            entity.HasOne(d => d.User).WithMany(p => p.UsuariosJuegos)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
