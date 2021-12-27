using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorConsultAppMVC.Models
{
    public class DoctorModel
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string Email { get; set; }
        public string Specilization { get; set; }
    }
}