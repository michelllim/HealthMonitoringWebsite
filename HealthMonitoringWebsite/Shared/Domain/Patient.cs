using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMonitoringWebsite.Shared.Domain
{
    public class Patient: BaseDomainModel
    {
        public int PatientID { get; set; }
		
		[Required]
		[StringLength(100, MinimumLength = 2, ErrorMessage = "Full Name does not meet length requirements")]
		public string? PatientName { get; set; }
        public DateTime PatientDateOfBirth { get; set; }
        public string? PatientGender { get; set; }
		
        [Required]
		[RegularExpression(@"^[STFGstfg]\d{7}[A-Za-z]", ErrorMessage = "NRIC does not meet the requirements")]
		public string? PatientNRIC {  get; set; }
        
        public string? PatientFamilyHistory { get; set; }
        public string? PatientAllergies { get; set; }

		[Required]
		[RegularExpression(@"^(A|B|AB|O)[\+\-]$", ErrorMessage = "Invalid blood type")] 
		public string? PatientBloodType { get; set; }
        //public string PatientEthnicity { get; set; }
        public string? PatientAddress { get; set; }

		[Required]
		[DataType(DataType.PhoneNumber)]
		[RegularExpression(@"(6|8|9)\d{7}", ErrorMessage = "Contact Number is not a valid phone number")]
		public string? PatientContactNumber { get; set; }
		
		[Required]
		[DataType(DataType.PhoneNumber)]
		[RegularExpression(@"(6|8|9)\d{7}", ErrorMessage = "Emergency Contact Number is not a valid phone number")]
		public string? PatientEmergencyContact {  get; set; }

		//[Required]
		//[DataType(DataType.EmailAddress, ErrorMessage = "Email Address is not a valid email")]
		//[EmailAddress]
		public string? Email {  get; set; }
        public string? Password { get; set; }
    }
}
