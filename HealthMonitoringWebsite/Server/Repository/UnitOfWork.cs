using HealthMonitoringWebsite.Server.Data;
using HealthMonitoringWebsite.Server.IRepository;
using HealthMonitoringWebsite.Server.Models;
using HealthMonitoringWebsite.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HealthMonitoringWebsite.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Appointment> _appointments;
        private IGenericRepository<Consultation> _consultations;
        private IGenericRepository<Diagnosis> _diagnosiss;
        private IGenericRepository<Medicine> _medicines;
        private IGenericRepository<Patient> _patients;
        private IGenericRepository<Prescription> _prescriptions;
        private IGenericRepository<PrescriptionItem> _prescriptionitems;
        private IGenericRepository<Staff> _staffs;
        private IGenericRepository<VitalSignsRecord> _vitalsignsrecords;


        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<Appointment> Appointments
            => _appointments ??= new GenericRepository<Appointment>(_context);
        public IGenericRepository<Consultation> Consultations
            => _consultations ??= new GenericRepository<Consultation>(_context);
        public IGenericRepository<Diagnosis> Diagnosiss
            => _diagnosiss ??= new GenericRepository<Diagnosis>(_context);
        public IGenericRepository<Medicine> Medicines
            => _medicines ??= new GenericRepository<Medicine>(_context);
        public IGenericRepository<Patient> Patients
            => _patients ??= new GenericRepository<Patient>(_context);
        public IGenericRepository<Prescription> Prescriptions
            => _prescriptions ??= new GenericRepository<Prescription>(_context);
        public IGenericRepository<PrescriptionItem> PrescriptionItems
            => _prescriptionitems ??= new GenericRepository<PrescriptionItem>(_context);
        public IGenericRepository<Staff> Staffs
            => _staffs ??= new GenericRepository<Staff>(_context);
        public IGenericRepository<VitalSignsRecord> VitalSignsRecords
            => _vitalsignsrecords ??= new GenericRepository<VitalSignsRecord>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            //To be implemented
            string user = "System";

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);

            foreach (var entry in entries)
            {
                ((BaseDomainModel)entry.Entity).DateUpdated = DateTime.Now;
                ((BaseDomainModel)entry.Entity).UpdatedBy = user;
                if (entry.State == EntityState.Added)
                {
                    ((BaseDomainModel)entry.Entity).DateCreated = DateTime.Now;
                    ((BaseDomainModel)entry.Entity).CreatedBy = user;
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}