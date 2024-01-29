using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMonitoringWebsite.Shared.Domain
{
    public class Diagnosis : BaseDomainModel
    {
        public int DiagnosisID { get; set; }
		[Required]
		[DataType(DataType.Date)]
		public DateTime DiagnosisDate { get; set; }
		[Required]
		[DataType(DataType.Time)]
		public DateTime DiagnosisTime { get; set; }
        public string? BodyPart { get; set; }
        public string? Symptoms { get; set; }
        public string? Conditions { get; set; }
        public virtual Consultation? Consultation { get; set; }
		public int? ConsultationID { get; set; }


	}
}
