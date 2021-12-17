using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorConsultApp.Models
{
    public class SlotGetModel
    {
        public int SlotId { get; set; }
        public int DoctorId { get; set; }
        public DateTime SDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string SlotAvailability { get; set; }
    }
}
