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
        public List<User> GetUsersAll();
        public List<Doctor> GetDoctor();
        public Doctor AddDoctor(Doctor doctor);
        public User AddUser(User user);
        public List<User> GetUser();
        public Booking AddBooking(Booking booking);
        public Slot AddTimeSlots(Slot slot);
        public List<Slot> GetTimeSlot();
        public List<Booking> GetBookedPatientDetails();
        public Prescription AddPrescription(Prescription prescription);
        public List<Booking> GetPatientList();
        public List<Prescription> GetPrescription();
    }
}
