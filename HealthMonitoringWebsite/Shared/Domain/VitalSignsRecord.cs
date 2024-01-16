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
        public DateOnly RecordDate { get; set; }
        public TimeOnly RecordTime { get; set; }
        public float? Height { get; set; }
        public float? Weight { get; set; }
        public float? BodyTemperature { get; set; }
        public float? BloodPressureSystolic { get; set; }
        public float? BloodPressureDiastolic { get; set; }
        public int? HeartRate { get; set; }
        public int? RespirationRate { get; set; }
        public int? OtherBloodGlucoseLevel { get; set; }
        public int? OtherBloodOxygenLevel { get; set; }
        public int? OtherStepCount { get; set; }
        public float? Others {  get; set; }
        public virtual Patient? Patient { get; set; }
    }
}
