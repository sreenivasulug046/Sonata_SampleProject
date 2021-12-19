using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorConsultApp.Models
{
    public class BookingModel
    {
        [Key]
        public int UserId { get; set; }
        public int DoctorId { get; set; }
        public string PName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Problem { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

    }
}
