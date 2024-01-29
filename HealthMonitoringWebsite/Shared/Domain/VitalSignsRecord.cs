using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMonitoringWebsite.Shared.Domain
{
    public class VitalSignsRecord: BaseDomainModel
    {
        public int RecordID { get; set; }
        public DateTime RecordDate { get; set; }
        public DateTime RecordTime { get; set; }
        public float? Height { get; set; }
        public float? Weight { get; set; }
        public float? BodyTemperature { get; set; }
        public int? BloodPressureSystolic { get; set; }
        public int? BloodPressureDiastolic { get; set; }
        public int? HeartRate { get; set; }
        public int? RespirationRate { get; set; }
        public int? OtherBloodGlucoseLevel { get; set; }
        public int? OtherBloodOxygenLevel { get; set; }
        public int? OtherStepCount { get; set; }
        public float? Others {  get; set; }
        //change to string
        public virtual Patient? Patient { get; set; }
    }
}
