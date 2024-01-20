using HealthMonitoringWebsite.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthMonitoringWebsite.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Appointment> Appointments { get; }
        IGenericRepository<Consultation> Consultations { get; }
        IGenericRepository<Diagnosis> Diagnosiss { get; }
        IGenericRepository<Medicine> Medicines { get; }
        IGenericRepository<Patient> Patients { get; }
        IGenericRepository<Prescription> Prescriptions { get; }
        IGenericRepository<PrescriptionItem> PrescriptionItems { get; }
        IGenericRepository<Staff> Staffs { get; }
        IGenericRepository<VitalSignsRecord> VitalSignsRecords { get; }


    }
}