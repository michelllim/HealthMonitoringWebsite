using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMonitoringWebsite.Shared.Domain
{
    public class Medicine : BaseDomainModel
    {
       public int MedicineID {  get; set; }
        public string? MName { get; set; }
        public string? MStrength { get; set; }
        public string? MType { get; set; }
        public string? MIngredients { get; set; }
        public int? MTotalAmount { get; set; }
        public string? MInstructions { get; set; }
        public string? MPurpose { get; set; }
        public DateOnly MExpiryDate { get; set; }


    }
}

