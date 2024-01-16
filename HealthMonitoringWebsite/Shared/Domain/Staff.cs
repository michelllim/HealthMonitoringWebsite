using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMonitoringWebsite.Shared.Domain
{
    public class Staff : BaseDomainModel
    {
        public string? StaffName { get;set; }
        public int? StaffContactNumber { get;set;}
        public string? StaffRole { get;set;}
        public string? StaffSpecialization { get;set; }
        public string? StaffEmail { get;set; }
        public string? StaffPassword { get;set; }
        public virtual List<Appointment>? Appointments { get;set; }
    }
}
