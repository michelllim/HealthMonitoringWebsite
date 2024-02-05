using Duende.IdentityServer.EntityFramework.Options;
using HealthMonitoringWebsite.Server.Configurations.Entities;
using HealthMonitoringWebsite.Server.Models;
using HealthMonitoringWebsite.Shared.Domain;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Drawing;

namespace HealthMonitoringWebsite.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Diagnosis> Diagnosiss { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionItem> PrescriptionItems { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<VitalSignsRecord> VitalSignsRecord { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new PatientSeedConfiguration());
            builder.ApplyConfiguration(new MedicineSeedConfiguration());
            builder.ApplyConfiguration(new StaffSeedConfiguration());
            builder.ApplyConfiguration(new RoleSeedConfiguration());
            builder.ApplyConfiguration(new UserSeedConfiguration());
            builder.ApplyConfiguration(new UserRoleSeedConfiguration());
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Appointment>()
        //        .Property(a => a.AppointmentDate)
        //        .HasColumnType("date");

        //    modelBuilder.Entity<Appointment>()
        //        .Property(a => a.AppointmentStartTime)
        //        .HasColumnType("time");

        //    modelBuilder.Entity<Appointment>()
        //        .Property(a => a.AppointmentEndTime)
        //        .HasColumnType("time");

        //    modelBuilder.Entity<Consultation>()
        //        .Property(a => a.ConsultationDate)
        //        .HasColumnType("date");

        //    modelBuilder.Entity<Consultation>()
        //        .Property(a => a.ConsultationStartTime)
        //        .HasColumnType("time");

        //    modelBuilder.Entity<Consultation>()
        //        .Property(a => a.ConsultationEndTime)
        //        .HasColumnType("time");

        //    modelBuilder.Entity<Diagnosis>()
        //        .Property(a => a.DiagnosisDate)
        //        .HasColumnType("date");

        //    modelBuilder.Entity<Diagnosis>()
        //        .Property(a => a.DiagnosisTime)
        //        .HasColumnType("time");

        //    modelBuilder.Entity<Medicine>()
        //        .Property(a => a.MExpiryDate)
        //        .HasColumnType("date");

        //    modelBuilder.Entity<Patient>()
        //        .Property(a => a.PatientDateOfBirth)
        //        .HasColumnType("date");

        //    modelBuilder.Entity<Prescription>()
        //        .Property(a => a.PExpiryDate)
        //        .HasColumnType("date");

        //    modelBuilder.Entity<Prescription>()
        //        .Property(a => a.PIssueDate)
        //        .HasColumnType("date");

        //    modelBuilder.Entity<VitalSignsRecord>()
        //        .Property(a => a.RecordDate)
        //        .HasColumnType("date");

        //    modelBuilder.Entity<VitalSignsRecord>()
        //        .Property(a => a.RecordTime)
        //        .HasColumnType("time");
        //}
    }
}
