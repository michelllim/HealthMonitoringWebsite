using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HealthMonitoringWebsite.Shared.Domain;
using System.Collections.Generic;

namespace HealthMonitoringWebsite.Server.Configurations.Entities
{
    public class PatientSeedConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            _ = builder.HasData(
                new Patient
                {
                    Id =1,
                    PatientID = 1,
                    PatientName = "Lily Wong",
                    //PatientDateOfBirth = "01/02/1990",
                    PatientGender = "Female",
                    PatientNRIC = "S12345678A",
                    PatientFamilyHistory = "Family has record of asthma, high blood pressure and diabetes.",
                    PatientAllergies = "Animal fur",
                    PatientBloodType = "A-",
                    PatientAddress = "Tampines Avenue 1 Block 550 #11-222",
                    PatientContactNumber = "89547967",
                    PatientEmergencyContact = "89547990",
                },
                new Patient
                {
                    Id = 2,
                    PatientID = 2,
                    PatientName = "Tommy Lin",
                    //PatientDateOfBirth = "11/02/1977",
                    PatientGender = "Male",
                    PatientNRIC = "S12345678B",
                    PatientFamilyHistory = "Family has record of seizures and diabetes.",
                    PatientAllergies = "Nil",
                    PatientBloodType = "B+",
                    PatientAddress = "Tampines Street 53 Block 222 #12-232",
                    PatientContactNumber = "98885222",
                    PatientEmergencyContact = "98834555",
                },
                new Patient
                {
                    Id = 3,
                    PatientID = 3,
                    PatientName = "Andy Low",
                    //PatientDateOfBirth = "02/02/1989",
                    PatientGender = "Male",
                    PatientNRIC = "S12345111F",
                    PatientFamilyHistory = "Family has record of cancer, asthma, high blood pressure and diabetes.",
                    PatientAllergies = "Pollen",
                    PatientBloodType = "A+",
                    PatientAddress = "Bedok Reservoir Road Block 222 #07-222",
                    PatientContactNumber = "88787967",
                    PatientEmergencyContact = "89097990",
                }
                );
        }
    }
}
