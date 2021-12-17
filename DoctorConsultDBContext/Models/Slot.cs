using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DoctorConsultDBContext.Models
{
    public partial class Slot
    {
        [Key]
        public int SlotId { get; set; }
        public int DoctorId { get; set; }
        public DateTime SDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string SlotAvailability { get; set; }



        //public virtual Doctor Doctor { get; set; }
    }
}
