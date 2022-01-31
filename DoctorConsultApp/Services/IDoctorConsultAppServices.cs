using DoctorConsultApp.Models;
using DoctorConsultDBContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorConsultApp.Services
{
    public interface IDoctorConsultAppServices
    {
        public List<DoctorModel> GetAll();
        public List<UserLogin> UsersLogin();
        public DoctorDetailsModel GetDoctor(int id);
        public DoctorAddModel AddDoctor(DoctorAddModel doctor);
        public UserAddModel AddUser(UserAddModel user);
        public UserProfile UserProfile(int UserId);
        public UserProfile UserProfilebyEmail(string Email);
        public BookingModel AddBooking(BookingModel booking);
        public TimeSlotAddModel AddTimeSlots(TimeSlotAddModel slot);
        public List<BookedPatientsList> GetBookedPatientList(int id);
        public BookedPatientDetails GetBookedPatientDetails(int id);
        public List<SlotGetModel> GetTimeSlot(int id);
        public PrescriptionAddModel AddPrescription(PrescriptionAddModel prescription);
        public PrescriptionModel GetPrescription(int id);
        public List<PatientPastConsultList> GetPatientPastConsults(int id);
        public PatientPastConsulationModel PatientPastConsultation(int id);
        public DoctorDetailsModel GetDoctorbyEmail(string Email);
        public SlotGetModel GetTimeSlotbySlotid(int slotid);
    }
}
