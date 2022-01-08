using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorConsultApp.Models
{
    public class DoctorLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int DoctorId { get; set; }

    }
}
