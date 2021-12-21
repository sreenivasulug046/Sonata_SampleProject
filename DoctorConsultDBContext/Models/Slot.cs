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
        public string SDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Availability { get; set; }



        //public virtual Doctor Doctor { get; set; }
    }
}
