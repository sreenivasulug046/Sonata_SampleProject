using DoctorConsultApp.Models;
using DoctorConsultApp.Services;
using DoctorConsultDBContext.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DoctorConsultApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorConsultAppController : ControllerBase
    {
        private IDoctorConsultAppServices _database;
        private DoctorConsultationAppDBContext _dbContext;
        public DoctorConsultAppController(IDoctorConsultAppServices database , DoctorConsultationAppDBContext dBContext)
        {
            _database = database;
            _dbContext = dBContext;
        }
       //Doctor Login
        [Route("DoctorLogin")]
        [HttpPost]
        public IActionResult DoctorLogin(DoctorLogin login)
        {
            if (login == null)
            {
                return BadRequest();
            }
            else
            {
                var log = _dbContext.Doctors.Where(x => x.Email == login.Email && x.Password == login.Password).FirstOrDefault();
                if (log != null)
                {
                    return Ok(login);
                }
                else
                    return NotFound(new
                    {
                        StatusCode = "404",
                        message = "Login Failed"
                    }); 
            }            
        }
        /// <summary>
        ///  UserLogin
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [Route("UserLogin")]
        [HttpPost]
        public IActionResult userLogin(UserLogin login)
        {
            if (login == null)
            {
                return BadRequest();
            }
            else
            {
                var log = _dbContext.Users.Where(x => x.Email == login.Email && x.Password == login.Password).FirstOrDefault();
                if (log!= null)
                {
                    return Ok(login);
                }
                else
                    return NotFound(new
                    {
                        StatusCode = "404",
                        message = "Login Failed"
                    });
            }           
        }
        //API for UserProfile
        [HttpGet]
        [Route("UserProfile")]
        public IActionResult UserProfile(int Userid)
        {
            var user = _database.UserProfile(Userid);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }
        //
        [HttpGet]
        [Route("UserProfilebyEmail")]
        public IActionResult UserProfilebyEmail(string Email)
        {
            var user = _database.UserProfilebyEmail(Email);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }
        //API for List of Doctors With Specilization
        [HttpGet]
        [Route("ListOfDoctors")]
        public IActionResult GetAllDoctorsList()
        {
            var doctors = _database.GetAll();
            if (doctors.Count != 0)
            {
                return Ok(doctors);                
            }
            return NotFound();
        }
        //API for Getting All Details of pertcular doctor
        [HttpGet]
        [Route("DoctorDetails")]
        public IActionResult GetDoctorDetails(int id)
        {
            var doctor = _database.GetDoctor(id);
            if (doctor != null)
            {
                return Ok(doctor);
            }
            return NotFound();            
        }
        [HttpGet]
        [Route("DoctorDetailsbyEmail")]
        public IActionResult GetDoctorDetails(string Email)
        {
            var doctor = _database.GetDoctorbyEmail(Email);
            if (doctor != null)
            {
                return Ok(doctor);
            }
            return NotFound();
        }
        //API for Register a doctor
        [HttpPost]
        [Route("RegisterDoctor")]
        public IActionResult AddDoctor(DoctorAddModel doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }
            var item = _database.AddDoctor(doctor);
            if (item != null)
            {
                return Ok(doctor);
            }
            return NoContent();           
        }
        //API for Register user
        [HttpPost]
        [Route("RegisterUser")]
        public IActionResult AddUser(UserAddModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }
            var data=_database.AddUser(user);
            if (data != null)
            {
                return Ok(user);
            }
            return NoContent();
        }
        //API for booking a doctor
        [HttpPost]
        [Route("Booking")]
        public IActionResult AddBooking(BookingModel booking)
        {          

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }
            var data=_database.AddBooking(booking);
            if (data != null)
            {
                return Ok(booking);
            }
            return NoContent();
        }
        //[HttpPost]
        //[Route("Add TimeSlots")]
        //public IActionResult AddTimeSlot(TimeSlotAddModel slot)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest("Invalid data");
        //    }
        //   var data= _database.AddTimeSlots(slot);
        //    if (data != null)
        //    {
        //        return Ok(slot);
        //    }
        //    return NoContent();
        //}
        //API for Doctors adds a prescription for patient
        [HttpPost]
        [Route("AddPrescripion")]
        public IActionResult AddPrescription(PrescriptionAddModel prescription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }
            var data=_database.AddPrescription(prescription);
            if (data != null)
            {
                return Ok(prescription);
            }
            return NoContent();
        }
        //API for Geting Time slot Avilability in Doctor details
        [HttpGet]
        [Route("Slot Availability")]
        public IActionResult GetSlotAvalability(int id)
        {
            var timeslot = _database.GetTimeSlot(id);
            if (timeslot != null)
            {
                return Ok(timeslot);
                
            }
            return NotFound();
        }
        //API for getting perticular booked detailes
        [HttpGet]
        [Route("BookedDetails")]
        public IActionResult GetBookedDetails(int id)
        {
            var bookeddetails = _database.GetBookedPatientDetails(id);
            if (bookeddetails != null)
            {
                return Ok(bookeddetails);          
            }
            return NotFound();
        }
        // API for Getting the patient prescription by Booking Id 
        [HttpGet]
        [Route("Patient Prescriptions")]
        public IActionResult GetPrescription(int id)
        {
            var prescrition = _database.GetPrescription(id);
            if (prescrition != null)
            {
                return Ok(prescrition);              
            }
            return NotFound();
        }
        //API for Getting List Of Booked Patients by Today Date
        [HttpGet]
        [Route("List of Booked patients")]
        public IActionResult GetBookedPatientList(int id)
        {
            var results = _database.GetBookedPatientList(id);
            if (results != null)
            {
                return Ok(results);                
            }
            return NotFound();
        }
        //API for Getting List of Past consultations by UserId
        [HttpGet]
        [Route("ListofPastConsults")]
        public IActionResult GetPastConsultations(int id)
        {
            var pastconsults = _database.GetPatientPastConsults(id);
            if (pastconsults != null)
            {
                return Ok(pastconsults);              
            }
            return NotFound();
        }
        //API for Getting Perticulat Consultation by Booking Id
        [HttpGet]
        [Route("PastConsultation")]
        public IActionResult GetPastConsultation(int id)
        {
            var pastconsult = _database.PatientPastConsultation(id);
            if (pastconsult != null)
            {
                return Ok(pastconsult);               
            }
            return NotFound();
        }      
    }
}
