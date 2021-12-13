using DoctorConsultDBContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorConsultDBContext.Services
{
    public interface IDoctorConsultAppDBServices
    {
        public List<Doctor> GetAll();
        public List<Doctor> GetDoctor();
        public Doctor AddDoctor(Doctor doctor);
        public User AddUser(User user);
        public Booking AddBooking(Booking booking);
        public Slot AddTimeSlots(Slot slot);
        public List<Slot> GetTimeSlot(int id);
        public Booking GetBookedPatientDetails(int Uid, int Did);
        public Prescription AddPrescription(Prescription prescription);
        public List<Prescription> GetPrescription(int Uid, int Did);
    }
}
