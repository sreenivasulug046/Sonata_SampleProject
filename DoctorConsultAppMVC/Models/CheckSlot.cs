using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorConsultAppMVC.Models
{
    public class CheckSlot
    {
        public int SlotId { get; set; }
        public int DoctorId { get; set; }
        public string SDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Availability { get; set; }
    }
}