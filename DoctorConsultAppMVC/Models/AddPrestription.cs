using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorConsultAppMVC.Models
{
    public class AddPrestription
    {
        public int BookingId { get; set; }
        public int DoctorId { get; set; }
        public int UserId { get; set; }
        public string prescription { get; set; }
        public string AdditionalSuggestion { get; set; }
    }
}