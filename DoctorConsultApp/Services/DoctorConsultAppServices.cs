using DoctorConsultApp.Models;
using DoctorConsultDBContext.Models;
using DoctorConsultDBContext.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
namespace DoctorConsultApp.Services
{
    public class DoctorConsultAppServices : IDoctorConsultAppServices
    {
        private IDoctorConsultAppDBServices _DbContext;
        private readonly ILogger _logger;
        public DoctorConsultAppServices(IDoctorConsultAppDBServices DbContext ,ILogger<DoctorConsultAppServices> logger)
        {
            _DbContext = DbContext;
            _logger = logger;
        }
        //for geting list of doctors
        public List<DoctorModel> GetAll()
        {
            List<DoctorModel> data = new List<DoctorModel>();
            try
            {
                 data = _DbContext.GetAll()
                .Select(f => new DoctorModel
                {
                    DoctorId = f.DoctorId,
                    DoctorName = f.DoctorName,
                    Specilization = f.Specilization,
                    Email = f.Email
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
        public List<UserLogin> UsersLogin()
        {
            List<UserLogin> data = new List<UserLogin>();
            try
            {
                data = _DbContext.GetUsersAll()
               .Select(f => new UserLogin
               {
                   Email = f.Email,
                   Password = f.Password
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
        //for getting perticular doctor detailes
        public DoctorDetailsModel GetDoctor(int id)
        {
            DoctorDetailsModel result = new DoctorDetailsModel();
            try
            {
                result = _DbContext.GetDoctor()
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
            catch (Exception ex)
            {
                _logger.LogError($"There was an {ex.Message}");
                return result;
            }                
        }
        public DoctorAddModel AddDoctor(DoctorAddModel doctor)
        {
            try
            {
                _DbContext.AddDoctor(new Doctor()
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
            catch (Exception ex)
            {
                _logger.LogError($"There was an {ex.Message}");
                return doctor;
            }           
        }
        public UserAddModel AddUser(UserAddModel user)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError($"There was an {ex.Message}");
                return user;
            }
        }
        // for Booking a doctor 
        public BookingModel AddBooking(BookingModel booking)
        {
            try
            {
                _DbContext.AddBooking(new Booking
                {
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
                return booking;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an {ex.Message}");
                return booking;
            }
        }
        //for add time slots(doctor)
        public TimeSlotAddModel AddTimeSlots(TimeSlotAddModel slot)
        {
            try
            {
                _DbContext.AddTimeSlots(new Slot
                {
                    DoctorId = slot.DoctorId,
                    SDate = slot.SDate,
                    StartTime = slot.StartTime,
                    EndTime = slot.EndTime,
                    Availability = slot.Availability

                });
                return slot;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an {ex.Message}");
                return slot;
            }           
        }
        //for getting the timeslot availability in Doctor details
        public List<SlotGetModel> GetTimeSlot(int id)
        {
            List<SlotGetModel> result = new List<SlotGetModel>();
            try
            {
                result = _DbContext.GetTimeSlot()
                 .Where(f => f.DoctorId == id)
                 .Select(f => new SlotGetModel
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
        public BookedPatientDetails GetBookedPatientDetails(int id)
        {
            BookedPatientDetails result = new BookedPatientDetails();
            try
            {
                result = _DbContext.GetBookedPatientDetails()
                 .Where(f => f.BookingId == id)
                 .Select(f => new BookedPatientDetails
                 {
                     BookingId = f.BookingId,
                     UserId = f.UserId,
                     DoctorId = f.DoctorId,
                     PatientName = f.PName,
                     Gender = f.Gender,
                     Problem = f.Problem,
                     BookingDate = f.BookingDate,
                     StartTime = f.StartTime,
                     EndTime = f.EndTime
                 }).FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an {ex.Message}");
                return result;
            }                
        }
        //Doctor Add prescription for patient
        public PrescriptionAddModel AddPrescription(PrescriptionAddModel prescription)
        {
            try
            {
                _DbContext.AddPrescription(new Prescription()
                {
                    PrescriptionId = prescription.PrescriptionId,
                    DoctorId = prescription.DoctorId,
                    UserId = prescription.UserId,
                    PrescriptionImage = prescription.PrescriptionImage,
                    AdditionalSuggestion = prescription.AdditionalSuggestion
                });
                return prescription;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an {ex.Message}");
                return prescription;
            }          
        }
        //for getting Prescription details 
        public PrescriptionModel GetPrescription(int id)
        {
            PrescriptionModel result = new PrescriptionModel();
            try
            {
                result = _DbContext.GetPrescription()
                 .Where(f => f.BookingId == id)
                 .Select(f => new PrescriptionModel
                 {
                     BookingId = f.BookingId,
                     PrescriptionId = f.PrescriptionId,
                     PrescriptionImage = f.PrescriptionImage,
                     AdditionalSuggestion = f.AdditionalSuggestion

                 }).FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an {ex.Message}");
                return result;
            }                
        }
        public List<BookedPatientsList> GetBookedPatientList(int id)
        {
            List<BookedPatientsList> result = new List<BookedPatientsList>();
            try
            {
                result = _DbContext.GetPatientList()
                   .Where(f => f.DoctorId == id)
                   .Select(f => new BookedPatientsList
                   {
                       DoctorId = f.DoctorId,
                       UserId = f.UserId,
                       BookingId = f.BookingId,
                       PName = f.PName,
                       StartTime = f.StartTime,
                       EndTime = f.EndTime
                   })
                   .ToList();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an {ex.Message}");
                return result;
            }            
        }

        //Service List of Past Consultations
        public List<PatientPastConsultList> GetPatientPastConsults(int id)
        {
            List<PatientPastConsultList> result = new List<PatientPastConsultList>();
            try
            {
                result = _DbContext.GetPatientList()
                   .Where(f => f.UserId == id)
                   .Select(f => new PatientPastConsultList
                   {
                       BookingId = f.BookingId,
                       DoctorId = f.DoctorId,
                       PatientName = f.PName,
                       BookingDate = f.BookingDate
                   })
                   .ToList();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an {ex.Message}");
                return result;
            }
        }
        //Service for Perticular Past Consultation
        public PatientPastConsulationModel PatientPastConsultation(int id)
        {
            PatientPastConsulationModel result = new PatientPastConsulationModel();
            try
            {
                result = _DbContext.GetPatientList()
                  .Where(f => f.BookingId == id)
                  .Select(f => new PatientPastConsulationModel
                  {
                      BookingId = f.BookingId,
                      PatientName = f.PName,
                      BookingDate = f.BookingDate,
                      StartTime = f.StartTime,
                      EndTime = f.EndTime
                  })
                  .FirstOrDefault();
                return result;
            }
            catch (Exception ex )
            {
                _logger.LogError($"There was an {ex.Message}");
                return result;
            }
        }
    }
}
