using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthMonitoringWebsite.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly string PatientsEndpoint = $"{Prefix}/patients";
        public static readonly string ConsultationsEndpoint = $"{Prefix}/consultations";
        public static readonly string DiagnosissEndpoint = $"{Prefix}/diagnosiss";
        public static readonly string PrescriptionsEndpoint = $"{Prefix}/prescriptions";
        public static readonly string VitalSignsRecordsEndpoint = $"{Prefix}/vitalsignsrecords";

		public static readonly string StaffsEndpoint = $"{Prefix}/staffs";
		public static readonly string AppointmentsEndpoint = $"{Prefix}/appointments";
		public static readonly string MedicinesEndpoint = $"{Prefix}/medicines";
		public static readonly string PrescriptionItemsEndpoint = $"{Prefix}/prescriptionItems";

    }
}