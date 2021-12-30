using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorConsultAppMVC.Models
{
    public class UploadPrescription
    {
        public byte[] PrescriptionImage { get; set; }
        public string AdditionalSuggestion { get; set; }
    }
}