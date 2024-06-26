﻿
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Anamnese.API.ORM.Entity
{
    public class PacientModel
    {
        [Key]
        public int PacientId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Profession { get; set; }
        public string Uf { get; set; }
        public DateOnly Birth { get; set; }
        public string Gender { get; set; }
        public int ProfissionalId { get; set; }
        public string? MedicalSpeciality { get; set; }

        //[JsonIgnore]
        public ReportModel Report { get; set; }
        List<AppointmentModel> Appointments { get; set; }
        List<AnotationModel> Anotations { get; set; }

    }
}
