using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorConsultApp.Models
{
    public class PrescriptionModel
    {
        public int PrescriptionId { get; set; }
        public int BookingId { get; set; }
        public byte[] PrescriptionImage { get; set; }
        public string AdditionalSuggestion { get; set; }
    }
}
