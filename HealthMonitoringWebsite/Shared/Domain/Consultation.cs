using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMonitoringWebsite.Shared.Domain
{
    public class Consultation: BaseDomainModel
    {
        public int ConsultationID { get; set; }
        public DateTime ConsultationDate { get; set; }
        public DateTime ConsultationStartTime { get; set; }
        public DateTime ConsultationEndTime { get; set; }
        public float? ConsultationPrice { get; set; }
        public string? ConsultationContent { get; set; }
        public string? ConsultationLocation { get; set; }
        public virtual VitalSignsRecord? VitalSignsRecord { get; set; }  
        public virtual Appointment? Appointment { get; set; }
    }
}
