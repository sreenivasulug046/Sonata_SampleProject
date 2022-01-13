using DoctorConsultApp.Models;
using DoctorConsultApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsConsultAppTest.Services
{
    class ConsultationServicesFake : IDoctorConsultAppServices
    {
        private readonly List<BookingModel> _booking;
        private readonly List<DoctorModel> _getdoctor;
        private readonly DoctorDetailsModel _getdoctorbid;
        private readonly IList<DoctorAddModel> _doctor;
        private readonly UserProfile _userprofile;
        public ConsultationServicesFake()
        {
            _booking = new List<BookingModel>();
            _getdoctor = new List<DoctorModel>()
            {
                new DoctorModel(){DoctorName="Raju",Email="raju@gmail.com",Specilization="doctor",Password="raju123"},
                new DoctorModel(){DoctorName="Ravi",Email="ravi@gmail.com",Specilization="doctor",Password="ravi123"},
                new DoctorModel(){DoctorName="Ramesh",Email="ramesh@gmail.com",Specilization="doctor",Password="ramesh123"}
            };
            _getdoctorbid = new DoctorDetailsModel() { DoctorId = 1, DoctorName = "Raju", Email = "raju@gmail.com", Specilization = "doctor" };
            _userprofile = new UserProfile() { UserId = 1, UserName = "Ravi", Email = "ravi@mail.com", PhNo = "9652729580" };
        }

        public BookingModel AddBooking(BookingModel booking)
        {
            _booking.Add(booking);
            return booking;
        }

        public DoctorAddModel AddDoctor(DoctorAddModel doctor)
        {
            _doctor.Add(doctor);
            return doctor;
        }

        public PrescriptionAddModel AddPrescription(PrescriptionAddModel prescription)
        {
            throw new NotImplementedException();
        }

        public TimeSlotAddModel AddTimeSlots(TimeSlotAddModel slot)
        {
            throw new NotImplementedException();
        }

        public UserAddModel AddUser(UserAddModel user)
        {
            throw new NotImplementedException();
        }

        public List<DoctorModel> GetAll()
        {
            return _getdoctor;
        }

        public BookedPatientDetails GetBookedPatientDetails(int id)
        {
            throw new NotImplementedException();
        }

        public List<BookedPatientsList> GetBookedPatientList(int id)
        {
            throw new NotImplementedException();
        }

        public DoctorDetailsModel GetDoctor(int id)
        {
            return _getdoctorbid;
        }

        public DoctorDetailsModel GetDoctorbyEmail(string Email)
        {
            throw new NotImplementedException();
        }

        public List<PatientPastConsultList> GetPatientPastConsults(int id)
        {
            throw new NotImplementedException();
        }

        public PrescriptionModel GetPrescription(int id)
        {
            throw new NotImplementedException();
        }

        public List<SlotGetModel> GetTimeSlot(int id)
        {
            throw new NotImplementedException();
        }

        public PatientPastConsulationModel PatientPastConsultation(int id)
        {
            throw new NotImplementedException();
        }

        public UserProfile UserProfile(int UserId)
        {
            return _userprofile;
        }

        public UserProfile UserProfilebyEmail(string Email)
        {
            throw new NotImplementedException();
        }

        public List<UserLogin> UsersLogin()
        {
            throw new NotImplementedException();
        }
    }
}
