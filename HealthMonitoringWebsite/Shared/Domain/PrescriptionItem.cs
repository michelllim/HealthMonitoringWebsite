using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMonitoringWebsite.Shared.Domain
{
    public class PrescriptionItem : BaseDomainModel
    {
        public int PrescriptionItemID { get; set; }
        public string? PDosage { get; set; }
        public string? PDuration { get; set; }
        public string? PRefill { get; set; }
        public virtual Prescription? Prescription { get; set; }
		public int? PrescriptionID { get; set; }
		public virtual Medicine? Medicine { get; set; }
		public int? MedicineID { get; set; }

	}
}
