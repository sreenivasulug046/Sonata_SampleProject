using DoctorConsultDBContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorConsultApp.Services
{
    public interface IHomeServices
    {
        public List<Doctor> GetAll();
        public Doctor GetDoctor(int id);
        public Doctor AddDoctor(Doctor doctor);
        public User AddUser(User user);
        public Booking AddBooking(Booking booking);
        public Slot AddTimeSlots(Slot slot);
        public Booking GetBookedPatientDetails(int Uid, int Did);
        public List<Slot> GetTimeSlot(int id);
        public Prescription AddPrescription(Prescription prescription);
        public List<Prescription> GetPrescription(int Uid, int Did);
    }
}
