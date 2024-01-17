using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMonitoringWebsite.Shared.Domain
{
    public class Appointment : BaseDomainModel
    {
        public int? AppointmentID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime AppointmentStartTime { get; set; }  
        public DateTime AppointmentEndTime { get; set; }
        public string? AppointmentType { get; set; }
        public string? AppointmentConfirmation { get; set; }
        public virtual Staff? Staff { get; set; }
        public virtual Patient? Patient { get; set; }

    }
}


