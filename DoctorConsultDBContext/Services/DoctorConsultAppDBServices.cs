using DoctorConsultDBContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorConsultDBContext.Services
{
    public class DoctorConsultAppDBServices : IDoctorConsultAppDBServices
    {

        private DoctorConsultAppDBContext _DbContext;
        public DoctorConsultAppDBServices(DoctorConsultAppDBContext DbContext)
        {
            _DbContext = DbContext;
        }

        //for geting list of doctors
        public List<Doctor> GetAll()
        {
            var data = _DbContext.Doctors
                .Select(f => new Doctor
                {
                    DoctorId=f.DoctorId,
                    DoctorName = f.DoctorName,
                    Specilization = f.Specilization
                    //PhNo = f.PhNo,

                })
                .ToList();
            return data;
        }

        //for getting perticular doctor detailes
        public List<Doctor> GetDoctor()
        {

            var result = _DbContext.Doctors 
                 .Select(f => new Doctor
                 {
                     DoctorId = f.DoctorId,
                     DoctorName = f.DoctorName,
                     Gender = f.Gender,
                     Specilization = f.Specilization,
                     PhNo = f.PhNo,
                     Email = f.Email
                 }).ToList();

            return result;
        }

        public Doctor AddDoctor(Doctor doctor)
        {
            //_Dbconext.Doctor.Add(doctor);
            //return doctor;


            _DbContext.Doctors.Add(new Doctor()
            {
                DoctorId = doctor.DoctorId,
                DoctorName = doctor.DoctorName,
                Gender = doctor.Gender,
                Specilization = doctor.Specilization,
                PhNo = doctor.PhNo,
                Email = doctor.Email,
                Password = doctor.Password
            });
            _DbContext.SaveChanges();
            return doctor;

        }
        public User AddUser(User user)
        {
            _DbContext.Users.Add(new User()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                PhNo = user.PhNo,
                Email = user.Email,
                Password = user.Password
            });
            _DbContext.SaveChanges();
            return user;

        }
        // for Booking a doctor 
        public Booking AddBooking(Booking booking)
        {
            _DbContext.Bookings.Add(new Booking()
            {
                BookingId = booking.BookingId,
                UserId = booking.UserId,
                DoctorId = booking.DoctorId,
                PName = booking.PName,
                Gender = booking.Gender,
                Age = booking.Age,
                Problem = booking.Problem,
                Date = booking.Date,
                StartTime = booking.StartTime,
                EndTime = booking.EndTime,
                

            });
            _DbContext.SaveChanges();
            return booking;

        }
        //for add time slots(doctor)
        public Slot AddTimeSlots(Slot slot)
        {
            _DbContext.Slots.Add(new Slot()
            {
                SlotId = slot.SlotId,
                DoctorId = slot.DoctorId,
                SDate = slot.SDate,
                StartTime = slot.StartTime,
                EndTime = slot.EndTime,
                SlotAvailability=slot.SlotAvailability
                
            });
            _DbContext.SaveChanges();
            return slot;

        }
        //for getting the timeslot availability in Doctor details
        public List<Slot> GetTimeSlot()
        {

            var result = _DbContext.Slots
                 .Select(f => new Slot
                 {
                     SlotId = f.SlotId,
                     DoctorId=f.DoctorId,
                     SDate = f.SDate,
                     StartTime = f.StartTime,  //DateTime.ParseExact(Eval("aeStart").ToString(), "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).ToShortTimeString()
                     EndTime = f.EndTime,
                     SlotAvailability=f.SlotAvailability
                     
                 }).ToList();

            return result;
        }

        //for getting perticular user booking details to doctor
        public List<Booking> GetBookedPatientDetails()
        {

            var result = _DbContext.Bookings
                 .Select(f => new Booking
                 {
                     BookingId = f.BookingId,
                     UserId = f.UserId,
                     DoctorId = f.DoctorId,
                     PName = f.PName,
                     Gender = f.Gender,
                     Problem = f.Problem,
                     Date = f.Date,
                     StartTime = f.StartTime,
                     EndTime = f.EndTime
                 }).ToList();

            return result;
        }

        //Doctor Add prescription for patient
        public Prescription AddPrescription(Prescription prescription)
        {
            _DbContext.Prescriptions.Add(new Prescription()
            {
                PrescriptionId = prescription.PrescriptionId,
                DoctorId = prescription.DoctorId,
                BookingId=prescription.BookingId,
                UserId = prescription.UserId,
                PrescriptionImage = prescription.PrescriptionImage,
                AdditionalSuggestion = prescription.AdditionalSuggestion
            });
            _DbContext.SaveChanges();
            return prescription;

        }
        //for getting Prescription details 
        public List<Prescription> GetPrescription()
        {

            var result = _DbContext.Prescriptions
                 
                 .Select(f => new Prescription
                 {
                     BookingId=f.BookingId,
                     PrescriptionId = f.PrescriptionId,
                     DoctorId = f.DoctorId,
                     UserId = f.UserId,
                     PrescriptionImage = f.PrescriptionImage,
                     AdditionalSuggestion = f.AdditionalSuggestion

                 }).ToList();

            return result;
        }
        //// for User adding a review to the doctor
        //public Booking AddReview(Booking review)
        //{
        //    _DbContext.Bookings.Add(new Booking()
        //    {
        //        UserId=review.UserId,
        //        DoctorId = review.DoctorId,
        //        DoctorReview=review.DoctorReview

        //    });
        //    _DbContext.SaveChanges();
        //    return review;

        //}

        //Service for Getting all list of Booked patients according to timeslot
        public List<Booking> GetPatientList()
        {
            var patientlist = _DbContext.Bookings
                   .Select(f => new Booking
                   {
                       BookingId = f.BookingId,
                       UserId = f.UserId,
                       DoctorId = f.DoctorId,
                       PName = f.PName,
                       Gender = f.Gender,
                       Age = f.Age,
                       StartTime = f.StartTime,
                       EndTime = f.EndTime

                   }).ToList();
            return patientlist;
        }

        // Service for Getting all Past consultations
        //public List<Booking> GetPatientPastConsulList()
        //{

        //}
    }
}
