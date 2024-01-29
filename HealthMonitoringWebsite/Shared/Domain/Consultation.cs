using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMonitoringWebsite.Shared.Domain
{
    public class Consultation: BaseDomainModel
    {
        public int ConsultationID { get; set; }
		[Required]
		[DataType(DataType.Date)]
		public DateTime ConsultationDate { get; set; }
		[Required]
		[DataType(DataType.Time)]
		public DateTime ConsultationStartTime { get; set; }
		[Required]
		[DataType(DataType.Time)]
		public DateTime ConsultationEndTime { get; set; }
        public float? ConsultationPrice { get; set; }
        public string? ConsultationContent { get; set; }
        public string? ConsultationLocation { get; set; }
        public virtual VitalSignsRecord? VitalSignsRecord { get; set; }  
        public virtual Appointment? Appointment { get; set; }
		public int? RecordID { get; set; }
		public int? AppointmentID { get; set; }

	}
}
