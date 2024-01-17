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
        public string? PatientName { get; set; }
        public DateTime PatientDateOfBirth { get; set; }
        public string? PatientGender { get; set; }
        public string? PatientNRIC {  get; set; }
        public string? PatientFamilyHistory { get; set; }
        public string? PatientAllergies { get; set; }
        public string? PatientBloodType { get; set; }
        //public string PatientEthnicity { get; set; }
        public string? PatientAddress { get; set; }
        public string? PatientContactNumber { get; set; }
        public string? PatientEmergencyContact {  get; set; }
        public string? Email {  get; set; }
        public string? Password { get; set; }
    }
}
