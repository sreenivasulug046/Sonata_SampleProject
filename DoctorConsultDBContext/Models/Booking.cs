using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace DoctorConsultDBContext.Models
{
    public partial class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int DoctorId { get; set; }
        public string PName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Problem { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        ////[ForeignKey("DoctorId")]
        //public virtual Doctor Doctor { get; set; }

        ////[ForeignKey("UserId")]
        //public virtual User User { get; set; }


    }
}
