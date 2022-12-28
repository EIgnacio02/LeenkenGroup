using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class EignacioLeenkenGroupContext : DbContext
{
    public EignacioLeenkenGroupContext()
    {
    }

    public EignacioLeenkenGroupContext(DbContextOptions<EignacioLeenkenGroupContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-4F295B7J; Database= EIgnacioLeenkenGroup; Trusted_Connection=True; TrustServerCertificate=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__CE6D8B9E8461EE5C");

            entity.ToTable("Empleado", tb => tb.HasTrigger("EmpleadoTrigger"));

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NumeroNomina)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK_EmpleadoEstado");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__Estado__FBB0EDC1781CF943");

            entity.ToTable("Estado");

            entity.Property(e => e.Estado1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Estado");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
