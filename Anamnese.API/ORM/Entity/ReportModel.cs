﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Anamnese.API.ORM.Entity
{
    public class ReportModel
    {
        [Key]
        public int ReportId { get; set; }
        public DateTime ReportDateTime { get; set; }        

        public string MedicalHistory { get; set; }
        public string CurrentMedications { get; set; }
        public bool CardiovascularIssues { get; set; }
        public bool Diabetes { get; set; }


        //Historico Familiar
        public bool FamilyHistoryCardiovascularIssues { get; set; }
        public bool FamilyHistoryDiabetes { get; set; }


        // Lifestyle        
        public string PhysicalActivity { get; set; }
        public bool Smoker { get; set; }
        public int AlcoholConsumption { get; set; }


        // Other relevant information
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhone { get; set; }
        public string Observations { get; set; }

        [ForeignKey("Pacient")]
        public int PacientId { get; set; }
        public string PacientName { get; set; }

        [JsonIgnore]
        public PacientModel Pacient { get; set; }
    }
}
