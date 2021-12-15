using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorConsultApp.Models
{
    public class PrescriptionAddModel
    {
        public int PrescriptionId { get; set; }
        public int BookingId { get; set; }
        public int DoctorId { get; set; }
        public int UserId { get; set; }
        public byte[] PrescriptionImage { get; set; }
        public string AdditionalSuggestion { get; set; }

    }
}
