using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorConsultAppMVC.Models
{
    public class Booking
    {
        public int UserId { get; set; }
        public int DoctorId { get; set; }
        public string PName { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string Problem { get; set; }
        public string BookingDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}