using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorConsultApp.Models
{
    public class TimeSlotAddModel
    {
        public int DoctorId { get; set; }
        public string SDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Availability { get; set; }
    }
}
