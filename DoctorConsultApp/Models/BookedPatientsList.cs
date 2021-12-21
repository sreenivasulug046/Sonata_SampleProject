using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorConsultApp.Models
{
    public class BookedPatientsList
    {
        public int BookingId { get; set; }
        public int DoctorId { get; set; }
        public int UserId { get; set; }
        public string PName { get; set; }
        public string BookingDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
