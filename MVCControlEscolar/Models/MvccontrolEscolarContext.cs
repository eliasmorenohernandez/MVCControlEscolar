using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVCControlEscolar.Models;

public partial class MvccontrolEscolarContext : DbContext
{
    public MvccontrolEscolarContext()
    {
    }

    public MvccontrolEscolarContext(DbContextOptions<MvccontrolEscolarContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Calificacion> Calificacions { get; set; }

    public virtual DbSet<EstatusAcreditacion> EstatusAcreditacions { get; set; }

    public virtual DbSet<EstatusRegistro> EstatusRegistros { get; set; }

    public virtual DbSet<Grupo> Grupos { get; set; }

    public virtual DbSet<Materia> Materia { get; set; }

    public virtual DbSet<Profesor> Profesors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;DataBase=MVCControlEscolar;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.ToTable("Alumno");

            entity.Property(e => e.CorreoElectronico).HasMaxLength(150);
            entity.Property(e => e.Matricula).HasMaxLength(10);
            entity.Property(e => e.Nombre).HasMaxLength(60);
            entity.Property(e => e.PrimerApellido).HasMaxLength(60);
            entity.Property(e => e.SegundoApellido).HasMaxLength(60);
            entity.Property(e => e.Telefono).HasMaxLength(13);

            entity.HasOne(d => d.IdEstatusRegistroNavigation).WithMany(p => p.Alumnos)
                .HasForeignKey(d => d.IdEstatusRegistro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Alumno__IdEstatu__6E01572D");
        });

        modelBuilder.Entity<Calificacion>(entity =>
        {
            entity.ToTable("Calificacion");

            entity.Property(e => e.CalificacionGrupo).HasMaxLength(3);

            entity.HasOne(d => d.IdAlumnoNavigation).WithMany(p => p.Calificacions)
                .HasForeignKey(d => d.IdAlumno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calificac__IdAlu__72C60C4A");

            entity.HasOne(d => d.IdEstatusAcreditacionNavigation).WithMany(p => p.Calificacions)
                .HasForeignKey(d => d.IdEstatusAcreditacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calificac__IdEst__74AE54BC");

            entity.HasOne(d => d.IdEstatusRegistroNavigation).WithMany(p => p.Calificacions)
                .HasForeignKey(d => d.IdEstatusRegistro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calificac__IdEst__71D1E811");

            entity.HasOne(d => d.IdGrupoNavigation).WithMany(p => p.Calificacions)
                .HasForeignKey(d => d.IdGrupo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Calificac__IdGru__73BA3083");
        });

        modelBuilder.Entity<EstatusAcreditacion>(entity =>
        {
            entity.ToTable("EstatusAcreditacion");

            entity.Property(e => e.Nombre).HasMaxLength(60);
        });

        modelBuilder.Entity<EstatusRegistro>(entity =>
        {
            entity.ToTable("EstatusRegistro");

            entity.Property(e => e.Nombre).HasMaxLength(60);
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.ToTable("Grupo");

            entity.Property(e => e.Nombre).HasMaxLength(10);

            entity.HasOne(d => d.IdEstatusRegistroNavigation).WithMany(p => p.Grupos)
                .HasForeignKey(d => d.IdEstatusRegistro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Grupo__IdEstatus__70DDC3D8");

            entity.HasOne(d => d.IdMateriaNavigation).WithMany(p => p.Grupos)
                .HasForeignKey(d => d.IdMateria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Grupo__IdMateria__6FE99F9F");

            entity.HasOne(d => d.IdProfesorNavigation).WithMany(p => p.Grupos)
                .HasForeignKey(d => d.IdProfesor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Grupo__IdProfeso__6EF57B66");
        });

        modelBuilder.Entity<Materia>(entity =>
        {
            entity.Property(e => e.Clave).HasMaxLength(10);
            entity.Property(e => e.Nombre).HasMaxLength(60);

            entity.HasOne(d => d.IdEstatusRegistroNavigation).WithMany(p => p.Materia)
                .HasForeignKey(d => d.IdEstatusRegistro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Materia__IdEstat__5AEE82B9");
        });

        modelBuilder.Entity<Profesor>(entity =>
        {
            entity.ToTable("Profesor");

            entity.Property(e => e.CorreoElectronico).HasMaxLength(150);
            entity.Property(e => e.Nombre).HasMaxLength(60);
            entity.Property(e => e.PrimerApellido).HasMaxLength(60);
            entity.Property(e => e.SegundoApellido).HasMaxLength(60);
            entity.Property(e => e.Telefono).HasMaxLength(13);

            entity.HasOne(d => d.IdEstatusRegistroNavigation).WithMany(p => p.Profesors)
                .HasForeignKey(d => d.IdEstatusRegistro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Profesor__IdEsta__47DBAE45");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
