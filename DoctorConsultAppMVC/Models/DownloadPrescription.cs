using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorConsultAppMVC.Models
{
    public class DownloadPrescription
    {
        public int BookingId { get; set; }
        public string Prescription { get; set; }
        public string AdditionalSuggestion { get; set; }
    }
}