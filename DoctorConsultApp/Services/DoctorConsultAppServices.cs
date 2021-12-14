using DoctorConsultApp.Models;
using DoctorConsultDBContext.Models;
using DoctorConsultDBContext.Services;
using System;
using System.Collections.Generic;
using System.Linq;
namespace DoctorConsultApp.Services
{
    public class DoctorConsultAppServices : IDoctorConsultAppServices
    {
        private IDoctorConsultAppDBServices _DbContext;
        public DoctorConsultAppServices(IDoctorConsultAppDBServices DbContext)
        {
            _DbContext = DbContext;
        }

        //for geting list of doctors
        public List<DoctorModel> GetAll()
        {
            //var data = _DbContext.GetAll();

            var data = _DbContext.GetAll()
                .Select(f => new DoctorModel
                {
                    DoctorId = f.DoctorId,
                    DoctorName = f.DoctorName,
                    Specilization = f.Specilization


                })
                .ToList();
            //return data;
            return data;
        }

        //for getting perticular doctor detailes
        public DoctorDetailsModel GetDoctor(int id)
        {

            //var result = _DbContext.GetDoctor(id);

            var result = _DbContext.GetDoctor()
                 .Where(f => f.DoctorId == id)
                 .Select(f => new DoctorDetailsModel
                 {
                     DoctorId = f.DoctorId,
                     DoctorName = f.DoctorName,
                     Gender = f.Gender,
                     Specilization = f.Specilization,
                     PhNo = f.PhNo,
                     Email = f.Email
                 }).FirstOrDefault();

            return result;
        }

        public DoctorAddModel AddDoctor(DoctorAddModel doctor)
        {
            //_Dbconext.Doctor.Add(doctor);
            // return doctor;

            _DbContext.AddDoctor( new Doctor()
            {
                DoctorName = doctor.DoctorName,
                Gender = doctor.Gender,
                Specilization = doctor.Specilization,
                PhNo = doctor.PhNo,
                Email = doctor.Email,
                Password = doctor.Password


            });
            return doctor;
            
        }
        public UserAddModel AddUser(UserAddModel user)
        {
            _DbContext.AddUser(new User
            {
                UserName = user.UserName,
                PhNo = user.PhNo,
                Email = user.Email,
                Password = user.Password
            });
            return user;

        }
        // for Booking a doctor 
        public BookingModel AddBooking(BookingModel booking)
        {

            _DbContext.AddBooking(new Booking
            {
                UserId = booking.UserId,
                DoctorId = booking.DoctorId,
                PatientName = booking.PatientName,
                Gender = booking.Gender,
                Age=booking.Age,
                Height = booking.Height,
                PWeight = booking.PWeight,
                Problem = booking.Problem,
                Date = booking.Date,
                StartTime = booking.StartTime,
                EndTime = booking.EndTime

            });
            //_DbContext.SaveChanges();
            return booking;

        }
        //for add time slots(doctor)
        public TimeSlotAddModel AddTimeSlots(TimeSlotAddModel slot)
        {
            _DbContext.AddTimeSlots(new Slot
            {
                DoctorId = slot.DoctorId,
                SDate = slot.SDate,
                StartTime = slot.StartTime,
                EndTime = slot.EndTime,
                SlotAvailability=slot.SlotAvailability
                
            });

            return slot;

        }
        //for getting the timeslot availability in Doctor details
        public List<Slot> GetTimeSlot(int id)
        {
            var result = _DbContext.GetTimeSlot(id);

            //var result = _DbContext.Slots
            //     .Where(f => f.DoctorId == id)
            //     .Select(f => new Slot
            //     {
            //         SlotId = f.SlotId,
            //         Date = f.Date,
            //         StartTime = f.StartTime,
            //         EndTime = f.EndTime

            //     }).ToList();

            return result;
        }

        //for getting perticular user booking details to doctor
        public BookedPatientDetails GetBookedPatientDetails(int id)
        {
            var result = _DbContext.GetBookedPatientDetails()
                 .Where(f => f.BookingId == id)
                 .Select(f => new BookedPatientDetails
                 {
                     BookingId = f.BookingId,
                     UserId = f.UserId,
                     DoctorId = f.DoctorId,
                     PatientName = f.PatientName,
                     Gender = f.Gender,
                     Height = f.Height,
                     PWeight = f.PWeight,
                     Problem = f.Problem,
                     Date = f.Date,
                     StartTime = f.StartTime,
                     EndTime = f.EndTime
                 }).FirstOrDefault();

            return result;
        }

        //Doctor Add prescription for patient
        public Prescription AddPrescription(Prescription prescription)
        {

            _DbContext.AddPrescription(prescription);
            //_DbContext.Prescriptions.Add(new Prescription()
            //{
            //    PrescriptionId=prescription.PrescriptionId,
            //    DoctorId = prescription.DoctorId,
            //    UserId = prescription.UserId,
            //    PrescriptionImage=prescription.PrescriptionImage,
            //    AdditionalSuggestion=prescription.AdditionalSuggestion
            //});
            //_DbContext.SaveChanges();
            return prescription;

        }
        //for getting Prescription details 
        public PrescriptionModel GetPrescription(int id)
        {

            var result = _DbContext.GetPrescription()
                 .Where(f => f.BookingId==id)
                 .Select(f => new PrescriptionModel
                 {
                     PrescriptionId = f.PrescriptionId,
                     PrescriptionImage = f.PrescriptionImage,
                     AdditionalSuggestion = f.AdditionalSuggestion

                 }).FirstOrDefault();

            return result;
        }
        public List<BookedPatientsList> GetBookedPatientList()
        {
            var result = _DbContext.GetPatientList()
                    .Where(f => f.Date == DateTime.Today)
                    .Select(f => new BookedPatientsList
                    {
                        BookingId = f.BookingId,
                        PatientName = f.PatientName,
                        StartTime = f.StartTime,
                        EndTime = f.EndTime
                    })
                    .ToList();
            return result;
            
        }

        //Service List of Past Consultations
        public List<PatientPastConsultList> GetPatientPastConsults(int id)
        {
            var result = _DbContext.GetPatientList()
                    .Where(f => f.UserId==id)
                    .Select(f => new PatientPastConsultList
                    {
                        BookingId = f.BookingId,
                        DoctorId=f.DoctorId,
                        PatientName = f.PatientName,
                        Date=f.Date
                    })
                    .ToList();
            return result;

        }

        //Service for Perticular Past Consultation

        public PatientPastConsulationModel PatientPastConsultation(int id)
        {
            var result = _DbContext.GetPatientList()
                    .Where(f => f.BookingId==id)
                    .Select(f => new PatientPastConsulationModel
                    {
                        BookingId = f.BookingId,
                        PatientName = f.PatientName,
                        Date = f.Date,
                        StartTime=f.StartTime,
                        EndTime=f.EndTime,
                        Doctor=f.Doctor
                    })
                    .FirstOrDefault();
            return result;

        }


    }
}
