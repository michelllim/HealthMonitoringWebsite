using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMonitoringWebsite.Shared.Domain
{
    public class Appointment : BaseDomainModel
    {
        public string? AppointmentDate { get; set; }
        public string? AppointmentStartTime { get; set; }  
        public string? AppointmentEndTime { get; set; }
        public string? AppointmentType { get; set; }
        public string? AppointmentConfirmation { get; set; }

        public virtual Staff? Staff { get; set; }
        public virtual Patient? Patient { get; set; }


        //extra not added into erd
        public DateTime DateOut { get; set; }
        public DateTime DateIn { get; set; }



    }
}
