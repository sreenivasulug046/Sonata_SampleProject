using DoctorConsultDBContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorConsultApp.Models
{
    public class PatientPastConsulationModel
    {
        public int BookingId { get; set; }
        public string PatientName { get; set; }
        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public virtual Doctor Doctor { get; set; }


    }
}
