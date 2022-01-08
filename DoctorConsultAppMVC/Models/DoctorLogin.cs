using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorConsultAppMVC.Models
{
    public class DoctorLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int DoctorId { get; set; }


    }
}