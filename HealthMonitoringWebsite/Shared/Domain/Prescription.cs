using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HealthMonitoringWebsite.Shared.Domain
{
    public class Prescription: BaseDomainModel
    {
        public int PrescriptionID { get; set; }
		[Required]
		[DataType(DataType.Date)]
		public DateTime PIssueDate { get; set; }
		[Required]
		[DataType(DataType.Date)]
		public DateTime PExpiryDate { get; set; }
        public virtual Consultation? Consultation { get; set; }
		public int? ConsultationID { get; set; }


		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			//throw new NotImplementedException();

			if (PIssueDate != null)
			{
				if (PIssueDate <= PExpiryDate)
				{
					yield return new ValidationResult("PIssueDate must be greater than PExpiryDate", new[] { "PIssueDate" });
				}
			}
		}
	}
}
