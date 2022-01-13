using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorConsultAppMVC.Models
{
    public class PastConsultList
    {
        
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int DoctorId { get; set; }
        public string PatientName { get; set; }
        public string BookingDate { get; set; }
    }
}