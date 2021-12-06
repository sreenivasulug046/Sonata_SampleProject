using System;
using System.Collections.Generic;

#nullable disable

namespace DoctorConsultApp.Models
{
    public partial class Prescription
    {
        public int PrescriptionId { get; set; }
        public int? DoctorId { get; set; }
        public int? UserId { get; set; }
        public byte[] PrescriptionImage { get; set; }
        public string AdditionalSuggestion { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual User User { get; set; }
    }
}
