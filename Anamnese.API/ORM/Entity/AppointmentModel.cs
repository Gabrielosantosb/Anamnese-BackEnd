﻿using System.ComponentModel.DataAnnotations;

namespace Anamnese.API.ORM.Entity
{
    public class AppointmentModel
    {
        [Key]
        public int AppointmentId { get; set; }
        public DateTime AppointmentDateTime { get; set; }

        public int PacientId { get; set; }
        public PacientModel Pacient { get; set; }

        public int ProfissionalId { get; set; }
        public ProfissionalModel Profissional { get; set; }
    }
}
