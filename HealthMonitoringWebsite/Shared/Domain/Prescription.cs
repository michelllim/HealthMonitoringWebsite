using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMonitoringWebsite.Shared.Domain
{
    public abstract class Prescription: BaseDomainModel
    {
        public int PrescriptionID { get; set; }
        public DateOnly PIssueDate { get; set; }
        public DateOnly PExpiryDate { get; set; }
        public virtual Consultation? Consultation { get; set; }  
    }
}
