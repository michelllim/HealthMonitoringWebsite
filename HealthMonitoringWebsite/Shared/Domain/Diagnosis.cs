using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMonitoringWebsite.Shared.Domain
{
    public abstract class Diagnosis: BaseDomainModel
    {
        public int DiagnosisID { get; set; }
        public DateOnly DiagnosisDate { get; set; }
        public TimeOnly DiagnosisTime { get; set; }
        public string? BodyPart { get; set; }
        public string? Symptoms { get; set; }
        public string? Conditions { get; set; }
        public virtual Consultation? Consultation { get; set; }  

    }
}
