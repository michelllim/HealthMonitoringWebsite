using HealthMonitoringWebsite.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
//using System.Ling;
using System.Threading.Tasks;

namespace HealthMonitoringWebsite.Server.Configurations.Entities
{
    public class MedicineSeedConfiguration : IEntityTypeConfiguration<Medicine>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Medicine> builder)
        {

            builder.HasData(
                new Medicine
                {
                    MedicineID = 1,
                    MName = "Benzonatate",
                    MStrength = "100mg",
                    MType = "Oral Capsule",
                    MTotalAmount = 0,
                    MInstructions = "Adults and children 10 years of age and older—100 milligrams (mg) three times a day. " +
                    "Do not take more than 200 mg at one time or more than 600 mg per day.\r\nChildren younger than 10 years of age—Use is not recommended",
                    MPurpose = "It is used to relieve coughing.",
                    MExpiryDate = DateTime.Now.AddMonths(3)
                },
                new Medicine
                {
                    MedicineID = 2,
                    MName = "Acebutolol",
                    MStrength = "200 mg",
                    MType = "Oral Capsule",
                    MTotalAmount = 0,
                    MInstructions = "Initial dose: 400 mg orally per day in 1 to 2 divided doses\r\nMaintenance dose: 400 to 800 mg orally per day\r\n" +
                    "You should not use acebutolol if you have a serious heart condition such as \"AV block\" (2nd or 3rd degree), severe heart failure," +
                    " or slow heartbeats that have caused you to faint.",
                    MPurpose = "It is a beta blocker for the treatment of hypertension and arrhythmias (lowers blood pressure and irregular heartbeat).",
                    MExpiryDate = DateTime.Now.AddMonths(3)
                }
                );

            //throw new NotImplementedException();
        }
    }
}
