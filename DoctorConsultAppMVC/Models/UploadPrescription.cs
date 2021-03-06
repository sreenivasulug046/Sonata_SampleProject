using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DoctorConsultAppMVC.Models
{
    public class UploadPrescription
    {
        public int BookingId { get; set; }
        public int DoctorId { get; set; }
        public int UserId { get; set; }
        [DisplayName("Upload Image")]
        public string prescription { get; set; }
        public string AdditionalSuggestion { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

    }
}