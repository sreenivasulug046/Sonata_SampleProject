using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DoctorConsultDBContext.Models
{
    public partial class Prescription
    {
        [Key]
        public int PrescriptionId { get; set; }
        public int BookingId { get; set; }  
        public int DoctorId { get; set; }
        public int UserId { get; set; }
        public byte[] PrescriptionImage { get; set; }
        public string AdditionalSuggestion { get; set; }

        //public virtual Booking Booking { get; set; }


        //public virtual User User { get; set; }
    }
}
