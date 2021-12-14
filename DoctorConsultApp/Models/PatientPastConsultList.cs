using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorConsultApp.Models
{
    public class PatientPastConsultList
    {
        public int UserId { get; set; }
        public int BookingId { get; set; }
        public int DoctorId { get; set; }
        public string PatientName { get; set; }
        public DateTime Date { get; set; }
    }
}
