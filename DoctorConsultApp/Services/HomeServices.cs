using DoctorConsultDBContext.Models;
using DoctorConsultDBContext.Services;
using System.Collections.Generic;
using System.Linq;
namespace DoctorConsultApp.Services
{
    public class HomeServices : IHomeServices
    {
        private IDoctorConsultAppDBServices _DbContext;
        public HomeServices(IDoctorConsultAppDBServices DbContext)
        {
            _DbContext = DbContext;    
        }

        //for geting list of doctors
        public List<Doctor> GetAll()
        {
            var data = _DbContext.GetAll();
            return data;
            //var data = _DbContext.Doctors
            //    .Select(f => new Doctor
            //    {
            //        DoctorName = f.DoctorName,
            //        Specilization = f.Specilization,
            //        PhNo = f.PhNo,

            //    })
            //    .ToList();
            //return data;
        }

        //for getting perticular doctor detailes
        public Doctor GetDoctor(int id)
        {

            var result = _DbContext.GetDoctor(id);

            //var result = _DbContext.Doctors
            //     .Where(f => f.DoctorId == id)
            //     .Select(f => new Doctor
            //     {
            //         DoctorId = f.DoctorId,
            //         DoctorName = f.DoctorName,
            //         Gender=f.Gender,
            //         Specilization = f.Specilization,
            //         PhNo = f.PhNo,
            //         Email = f.Email
            //     }).FirstOrDefault();

            return result;
        }

        public Doctor AddDoctor(Doctor doctor)
        {
            //_Dbconext.Doctor.Add(doctor);
            //return doctor;

            _DbContext.AddDoctor(doctor);
            //_DbContext.Doctors.Add(new Doctor()
            //{
            //    DoctorId = doctor.DoctorId,
            //    DoctorName = doctor.DoctorName,
            //    Gender=doctor.Gender,
            //    Specilization=doctor.Specilization,
            //    PhNo = doctor.PhNo,
            //    Email = doctor.Email,
            //    Password = doctor.Password
            //});
            //_DbContext.SaveChanges();
            return doctor;

        }
        public User AddUser(User user)
        {
            _DbContext.AddUser(user);
            //_DbContext.Users.Add(new User()
            //{
            //    UserId = user.UserId,
            //    UserName = user.UserName,
            //    PhNo = user.PhNo,
            //    Email = user.Email,
            //    Password = user.Password
            //});
            //_DbContext.SaveChanges();
            return user;

        }
        // for Booking a doctor 
        public Booking AddBooking(Booking booking)
        {
            _DbContext.AddBooking(booking);
            //_DbContext.Bookings.Add(new Booking()
            //{
            //    BookingId=booking.BookingId,
            //    UserId=booking.UserId,
            //    DoctorId = booking.DoctorId,
            //    PatientName = booking.PatientName,
            //    Gender = booking.Gender,
            //    Height=booking.Height,
            //    Weight=booking.Weight,
            //    Problem=booking.Problem,
            //    Date=booking.Date,
            //    StartTime=booking.StartTime,
            //    EndTime=booking.EndTime

            //});
            //_DbContext.SaveChanges();
            return booking;

        }
        //for add time slots(doctor)
        public Slot AddTimeSlots(Slot slot)
        {
            _DbContext.AddTimeSlots(slot);
            //_DbContext.Slots.Add(new Slot()
            //{
            //    SlotId = slot.SlotId,
            //    DoctorId = slot.DoctorId,
            //    Date = slot.Date,
            //    StartTime = slot.StartTime,
            //    EndTime = slot.EndTime
            //});
            //_DbContext.SaveChanges();
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
        public Booking GetBookedPatientDetails(int Uid, int Did )
        {
            var result = _DbContext.GetBookedPatientDetails(Uid, Did);
            //var result = _DbContext.Bookings
            //     .Where(f => f.DoctorId == Did && f.UserId==Uid)
            //     .Select(f => new Booking
            //     {
            //         BookingId = f.BookingId,
            //         UserId = f.UserId,
            //         DoctorId = f.DoctorId,
            //         PatientName = f.PatientName,
            //         Gender = f.Gender,
            //         Height = f.Height,
            //         Weight = f.Weight,
            //         Problem = f.Problem,
            //         Date = f.Date,
            //         StartTime = f.StartTime,
            //         EndTime = f.EndTime
            //     }).FirstOrDefault();

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
        public Prescription GetPrescription(int Uid, int Did)
        {

            var result = _DbContext.GetPrescription(Uid, Did);

            //var result = _DbContext.Prescriptions
            //     .Where(f => f.DoctorId == Did && f.UserId == Uid)
            //     .Select(f => new Prescription
            //     {
            //         PrescriptionId=f.PrescriptionId,
            //         PrescriptionImage=f.PrescriptionImage,
            //         AdditionalSuggestion=f.AdditionalSuggestion
                    
            //     }).FirstOrDefault();

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

    }
}
