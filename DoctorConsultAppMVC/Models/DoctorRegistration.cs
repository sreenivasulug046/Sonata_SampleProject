using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorConsultAppMVC.Models
{
    public class DoctorRegistration
    {
        public string DoctorName { get; set; }
        public string Gender { get; set; }
        public string Specilization { get; set; }
        public string PhNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}