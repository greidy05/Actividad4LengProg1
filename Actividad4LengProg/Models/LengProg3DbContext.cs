using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Actividad4LengProg.Models;

public partial class LengProg3DbContext : DbContext
{
    public LengProg3DbContext()
    {
    }

    public LengProg3DbContext(DbContextOptions<LengProg3DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Calificacione> Calificaciones { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Materia> Materias { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LOCALHOST;Database=LengProg3DB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Calificacione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Califica__3214EC076EA276D0");

            entity.Property(e => e.CodigoMateria).HasMaxLength(20);
            entity.Property(e => e.MatriculaEstudiante).HasMaxLength(15);
            entity.Property(e => e.Periodo).HasMaxLength(20);

            entity.HasOne(d => d.CodigoMateriaNavigation).WithMany(p => p.Calificaciones)
                .HasForeignKey(d => d.CodigoMateria)
                .HasConstraintName("FK_Calificaciones_Materias");

            entity.HasOne(d => d.MatriculaEstudianteNavigation).WithMany(p => p.Calificaciones)
                .HasForeignKey(d => d.MatriculaEstudiante)
                .HasConstraintName("FK_Calificaciones_Estudiantes");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.Matricula).HasName("PK__Estudian__0FB9FB4E34D87382");

            entity.Property(e => e.Matricula).HasMaxLength(15);
            entity.Property(e => e.Carrera).HasMaxLength(100);
            entity.Property(e => e.CorreoInstitucional).HasMaxLength(100);
            entity.Property(e => e.Genero).HasMaxLength(10);
            entity.Property(e => e.NombreCompleto).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
            entity.Property(e => e.TipoIngreso).HasMaxLength(50);
            entity.Property(e => e.Turno).HasMaxLength(20);
        });

        modelBuilder.Entity<Materia>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__Materias__06370DAD1A6B6EB7");

            entity.Property(e => e.Codigo).HasMaxLength(20);
            entity.Property(e => e.Carrera).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
