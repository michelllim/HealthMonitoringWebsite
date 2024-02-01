using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMonitoringWebsite.Shared.Domain
{
    public class Appointment : BaseDomainModel
    {
        public int? AppointmentID { get; set; }
		[Required]
		[DataType(DataType.Date)]
		public DateTime AppointmentDate { get; set; }
		[Required]
		[DataType(DataType.Time)]
		public DateTime AppointmentStartTime { get; set; }
		[Required]
		[DataType(DataType.Time)]
		public DateTime AppointmentEndTime { get; set; }
        public string? AppointmentType { get; set; }
        public string? AppointmentConfirmation { get; set; }
		
        public virtual Staff? Staff { get; set; }
		public int StaffID { get; set; }
		public virtual Patient? Patient { get; set; }
		public int? PatientID { get; set; }

	}
}


