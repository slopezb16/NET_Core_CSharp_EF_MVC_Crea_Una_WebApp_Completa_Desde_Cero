using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace Turnos.Models
{
    public class TurnosContext : DbContext
    {
        public TurnosContext(DbContextOptions<TurnosContext> db) : base(db)
        {

        }

        public DbSet<Especialidad> Especialidad { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<MedicoEspecialidad> MedicoEspecialidad { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<Login> Login { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Especialidad>(entidad =>
                {
                    entidad.ToTable("Especialidad");

                    entidad.HasKey(x => x.IdEspecialidad);

                    entidad.Property(x => x.Descripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
                }
            );

            modelBuilder.Entity<Paciente>(entidad =>
            {
                entidad.ToTable("Paciente");

                entidad.HasKey(x => x.IdPaciente);

                entidad.Property(x => x.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(x => x.Apellido)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(x => x.Direccion)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

                entidad.Property(x => x.Telefono)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                entidad.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            }
            );

            modelBuilder.Entity<Medico>(entidad =>
            {
                entidad.ToTable("Medico");

                entidad.HasKey(x => x.IdMedico);

                entidad.Property(x => x.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(x => x.Apellido)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(x => x.Direccion)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

                entidad.Property(x => x.Telefono)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                entidad.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entidad.Property(x => x.HorarioAtencionDesde)
                .IsRequired()
                .IsUnicode(false);

                entidad.Property(x => x.HorarioAtencionHasta)
                .IsRequired()
                .IsUnicode(false);
            }
            );

            modelBuilder.Entity<MedicoEspecialidad>().HasKey(x => new { x.IdMedico, x.IdEspecialidad });

            modelBuilder.Entity<MedicoEspecialidad>().HasOne(x => x.Medico)
            .WithMany(z => z.MedicoEspecialidad)
            .HasForeignKey(a => a.IdMedico);

            modelBuilder.Entity<MedicoEspecialidad>().HasOne(x => x.Especialidad)
            .WithMany(z => z.MedicoEspecialidad)
            .HasForeignKey(a => a.IdEspecialidad);

            modelBuilder.Entity<Turno>(entidad =>
            {
                entidad.ToTable("Turno");

                entidad.HasKey(x => x.IdTurno);

                entidad.Property(x => x.IdPaciente)
                .IsRequired()
                .IsUnicode(false);

                entidad.Property(x => x.IdMedico)
                .IsRequired()
                .IsUnicode(false);

                entidad.Property(x => x.FechaHoraInicio)
                .IsRequired()
                .IsUnicode(false);

                entidad.Property(x => x.FechaHoraFin)
                .IsRequired()
                .IsUnicode(false);
            }
            );

            modelBuilder.Entity<Turno>().HasOne(x => x.Paciente)
            .WithMany(x => x.Turno)
            .HasForeignKey(a => a.IdPaciente);

            modelBuilder.Entity<Turno>().HasOne(x => x.Medico)
            .WithMany(x => x.Turno)
            .HasForeignKey(a => a.IdMedico);

            modelBuilder.Entity<Login>(x =>
            {
                x.ToTable("Login");

                x.HasKey(x => x.LoginId);

                x.Property(l => l.Usuario).IsRequired().HasMaxLength(50);

                x.Property(l => l.Password).IsRequired().HasMaxLength(100);
            }
            );
        }
    }
}