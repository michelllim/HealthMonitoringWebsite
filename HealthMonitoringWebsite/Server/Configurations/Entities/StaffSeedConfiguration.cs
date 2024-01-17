using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HealthMonitoringWebsite.Shared.Domain;
using System.Collections.Generic;

namespace HealthMonitoringWebsite.Server.Configurations.Entities
{
    public class StaffSeedConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasData(
                new Staff
                {
                    StaffID = 1,
                    StaffName = "Chen Pei Nee",
                    StaffContactNumber = "89547968",
                    StaffRole = "Doctor",
                    StaffSpecialization = "Cardiologist",
                    Email = "peinee2005@gmail.com",
                    Password = "DPeiNee123"
                },
                new Staff
                {
                    StaffID = 2,
                    StaffName = "Tom Liew",
                    StaffContactNumber = "68902727",
                    StaffRole = "Doctor",
                    StaffSpecialization = "Pulmonologist",
                    Email = "tomLiew@gmail.com",
                    Password = "DTom123"
                },
                new Staff
                {
                    StaffID = 3,
                    StaffName = "Amy Tang",
                    StaffContactNumber = "98213410",
                    StaffRole = "Nurse",
                    StaffSpecialization = "Neonatal Nurse",
                    Email = "amy123@gmail.com",
                    Password = "NAmy123"
                },
                new Staff
                {
                    StaffID = 4,
                    StaffName = "Vali Thamoi",
                    StaffContactNumber = "92859335",
                    StaffRole = "Nurse",
                    StaffSpecialization = "Psychiatric Nurse",
                    Email = "valiT@gmail.com",
                    Password = "NVali123"
                },
                new Staff
                {
                    StaffID = 5,
                    StaffName = "John",
                    StaffContactNumber = "86547733",
                    StaffRole = "Administrative Staff",
                    StaffSpecialization = "Receptionists",
                    Email = "johnT@gmail.com",
                    Password = "AJohn123"
                },
                new Staff
                {
                    StaffID = 6,
                    StaffName = "Tammy",
                    StaffContactNumber = "85557763",
                    StaffRole = "Medical Records Staff",
                    StaffSpecialization = "Receptionists",
                    Email = "Tammy@gmail.com",
                    Password = "MRTammy123"
                },
                new Staff
                {
                    StaffID = 7,
                    StaffName = "Tan Yan Ting",
                    StaffContactNumber = "90683274",
                    StaffRole = "Therapists",
                    StaffSpecialization = "Physical Therapists",
                    Email = "TYanTing@gmail.com",
                    Password = "TYanTing123"
                }
                );
        }
    }
}
