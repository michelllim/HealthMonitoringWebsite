using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMonitoringWebsite.Shared.Domain
{
    public class Prescription: BaseDomainModel
    {
        public int PrescriptionID { get; set; }
        public DateTime PIssueDate { get; set; }
        public DateTime PExpiryDate { get; set; }
        public virtual Consultation? Consultation { get; set; }  
    }
}
