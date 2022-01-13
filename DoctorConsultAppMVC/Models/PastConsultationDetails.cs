using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorConsultAppMVC.Models
{
    public class PastConsultationDetails
    {
        public int BookingId { get; set; }
        public int DoctorId { get; set; }
        public string PatientName { get; set; }
        public string BookingDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}