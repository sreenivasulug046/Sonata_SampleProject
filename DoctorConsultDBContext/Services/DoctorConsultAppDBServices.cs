using DoctorConsultDBContext.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorConsultDBContext.Services
{
    public class DoctorConsultAppDBServices : IDoctorConsultAppDBServices
    {
        private readonly ILogger _logger;
        private DoctorConsultationAppDBContext _DbContext;
        public DoctorConsultAppDBServices(DoctorConsultationAppDBContext DbContext , ILogger<DoctorConsultAppDBServices> logger)
        {
            _DbContext = DbContext;
            _logger = logger;
        }
        //for geting list of doctors
        public List<Doctor> GetAll()
        {
            List<Doctor> data = new List<Doctor>();
            try
            {
                 data = _DbContext.Doctors
               .Select(f => new Doctor
               {
                   DoctorId = f.DoctorId,
                   Email=f.Email,
                   Password=f.Password,
                   DoctorName = f.DoctorName,
                   Specilization = f.Specilization
                })
               .ToList();
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an {ex.Message}");
                return data;
            }           
        }
        public List<User> GetUsersAll()
        {
            List<User> data = new List<User>();
            try
            {
              data = _DbContext.Users
                 .Select(f => new User
                     {
                       UserId = f.UserId,
                       Email = f.Email,
                       Password = f.Password,
                       UserName = f.UserName
                   }) .ToList();
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an {ex.Message}");
                return data;
            }
        }
        //for getting perticular doctor detailes
        public List<Doctor> GetDoctor()
        {
            List<Doctor> result = new List<Doctor>();
            try
            {
                result = _DbContext.Doctors
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
            catch (Exception ex)
            {
                _logger.LogError($"There was an {ex.Message}");
                return result;
            }              
        }
        // Service for getting User details
        public List<User> GetUser()
        {
            List<User> result = new List<User>();
            try
            {
                result = _DbContext.Users
                .Select(f => new User
                {
                    UserId = f.UserId,
                    UserName = f.UserName,
                    PhNo = f.PhNo,
                    Email = f.Email
                }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an {ex.Message}");
                return result;
            }               
        }
        public Doctor AddDoctor(Doctor doctor)
        {
            try
            {
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
            catch (Exception ex)
            {
                _logger.LogError($"There was an {ex.Message}");
                return doctor;
            }
        }
        public User AddUser(User user)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError($"There was an {ex.Message}");
                return user;
            }
        }
        // for Booking a doctor 
        public Booking AddBooking(Booking booking)
        {
            try
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
                    BookingDate = booking.BookingDate,
                    StartTime = booking.StartTime,
                    EndTime = booking.EndTime
                });
                _DbContext.SaveChanges();
                return booking;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an {ex.Message}");
                return booking;
            }
        }
        //for add time slots(doctor)
        public Slot AddTimeSlots(Slot slot)
        {
            try
            {
                _DbContext.Slots.Add(new Slot()
                {
                    SlotId = slot.SlotId,
                    DoctorId = slot.DoctorId,
                    SDate = slot.SDate,
                    StartTime = slot.StartTime,
                    EndTime = slot.EndTime,
                    Availability = slot.Availability
                });
                _DbContext.SaveChanges();
                return slot;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an {ex.Message}");
                return slot;
            }            
        }
        //for getting the timeslot availability in Doctor details
        public List<Slot> GetTimeSlot()
        {
            List<Slot> result = new List<Slot>();
            try
            {
                result = _DbContext.Slots
                 .Select(f => new Slot
                 {
                     SlotId = f.SlotId,
                     DoctorId = f.DoctorId,
                     SDate = f.SDate,
                     StartTime = f.StartTime,
                     EndTime = f.EndTime,
                     Availability = f.Availability
                 }).ToList();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an {ex.Message}");
                return result;
            }               
        }
        //for getting perticular user booking details to doctor
        public List<Booking> GetBookedPatientDetails()
        {
            List<Booking> result = new List<Booking>();
            try
            {
                result = _DbContext.Bookings
                 .Select(f => new Booking
                 {
                     BookingId = f.BookingId,
                     UserId = f.UserId,
                     DoctorId = f.DoctorId,
                     PName = f.PName,
                     Gender = f.Gender,
                     Problem = f.Problem,
                     BookingDate = f.BookingDate,
                     StartTime = f.StartTime,
                     EndTime = f.EndTime
                 }).ToList();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an {ex.Message}");
                return result;
            }               
        }
        //Doctor Add prescription for patient
        public Prescription AddPrescription(Prescription prescription)
        {
            try
            {
                _DbContext.Prescriptions.Add(new Prescription()
                {
                    PrescriptionId = prescription.PrescriptionId,
                    DoctorId = prescription.DoctorId,
                    BookingId = prescription.BookingId,
                    UserId = prescription.UserId,
                    PrescriptionImage = prescription.PrescriptionImage,
                    AdditionalSuggestion = prescription.AdditionalSuggestion
                });
                _DbContext.SaveChanges();
                return prescription;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an {ex.Message}");
                return prescription;
            }           
        }
        //for getting Prescription details 
        public List<Prescription> GetPrescription()
        {
            List<Prescription> result = new List<Prescription>();
            try
            {
                result = _DbContext.Prescriptions
                 .Select(f => new Prescription
                 {
                     BookingId = f.BookingId,
                     PrescriptionId = f.PrescriptionId,
                     DoctorId = f.DoctorId,
                     UserId = f.UserId,
                     PrescriptionImage = f.PrescriptionImage,
                     AdditionalSuggestion = f.AdditionalSuggestion

                 }).ToList();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an {ex.Message}");
                return result;
            }              
        }       
        public List<Booking> GetPatientList()
        {
            List<Booking> patientlist = new List<Booking>();
            try
            {
                patientlist = _DbContext.Bookings
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
            catch (Exception ex)
            {
                _logger.LogError($"There was an {ex.Message}");
                return patientlist;
            }              
        }
    }
}
