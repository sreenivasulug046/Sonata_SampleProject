using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorConsultApp.Models
{
    public class DoctorAddModel
    {
        public string DoctorName { get; set; }
        public string Gender { get; set; }
        public string Specilization { get; set; }
        public string PhNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
