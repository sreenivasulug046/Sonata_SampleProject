using System;
using System.Collections.Generic;

#nullable disable

namespace DoctorConsultDBContext.Models
{
    public partial class Slot
    {
        public int SlotId { get; set; }
        public int? DoctorId { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string Availability { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
