using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMonitoringWebsite.Shared.Domain
{
    public class Staff : BaseDomainModel
    {
        public int StaffID { get; set; }    
        public string? StaffName { get;set; }
        public string? StaffContactNumber { get;set;}
        public string? StaffRole { get;set;}
        public string? StaffSpecialization { get;set; }
        public string? Email { get;set; }
        public string? Password { get;set; }
        public virtual List<Appointment>? Appointments { get;set; }
    }
}
