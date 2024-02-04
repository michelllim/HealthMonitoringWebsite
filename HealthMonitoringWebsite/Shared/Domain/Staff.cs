using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMonitoringWebsite.Shared.Domain
{
	public class Staff : BaseDomainModel
	{
		public int StaffID { get; set; }

		[Required]
		[StringLength(100, MinimumLength = 2, ErrorMessage = "Name does not meet length requirements")]  //error handling
		public string? StaffName { get; set; }

		[Required]
		[DataType(DataType.PhoneNumber)]
		[RegularExpression(@"(6|8|9)\d{7}", ErrorMessage = "Contact Number is not a valid phone number")]
		public string? StaffContactNumber { get; set; }

		[Required]
		[RegularExpression(@"^(Nurse|Doctor|Administrator)$", ErrorMessage = "Invalid Staff Role")]
		public string? StaffRole { get; set; }
		public string? StaffSpecialization { get; set; }

		//[Required]
		//[DataType(DataType.EmailAddress, ErrorMessage = "Email Address is not a valid email")]
		//[EmailAddress]
		public string? Email { get; set; }
		public string? Password { get; set; }
		public virtual List<Appointment>? Appointments { get; set; }
	}
}