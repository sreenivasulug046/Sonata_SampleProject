using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorConsultApp.Models
{
    public class BookedPatientDetails
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int DoctorId { get; set; }
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public float Height { get; set; }
        public float PWeight { get; set; }
        public string Problem { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
