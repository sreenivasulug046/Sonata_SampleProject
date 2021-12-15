using DoctorConsultApp.Models;
using DoctorConsultApp.Services;
using DoctorConsultDBContext.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorConsultApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorConsultAppController : ControllerBase
    {
        private IDoctorConsultAppServices _database;
        public DoctorConsultAppController(IDoctorConsultAppServices database)
        {
            _database = database;
        }

        //API for List of Doctors With Specilization
        [HttpGet]
        [Route("ListOfDoctors")]
        public IActionResult GetAllDoctorsList()
        {
            var doctors = _database.GetAll();
            if (doctors.Count == 0)
            {
                return NotFound();
            }
            return Ok(doctors);
        }
        //API for Getting All Details of pertcular doctor
        [HttpGet]
        [Route("Doctor Details")]
        public IActionResult GetDoctorDetails(int id)
        {
            var doctor = _database.GetDoctor(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
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


            var item=_database.AddDoctor(doctor);
            if (item == null)
                return NoContent();

            return Ok(doctor);

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


            _database.AddUser(user);

            return Ok(user);

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


            _database.AddBooking(booking);

            return Ok(booking);

        }
        //API for Adding Time slot for Doctor
        [HttpPost]
        [Route("Add TimeSlots")]
        public IActionResult AddTimeSlot(TimeSlotAddModel slot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }


            _database.AddTimeSlots(slot);

            return Ok(slot);

        }

        //API for Doctors adds a prescription for patient
        [HttpPost]
        [Route("Add Prescripion")]
        public IActionResult AddPrescription(PrescriptionAddModel prescription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }


            _database.AddPrescription(prescription);

            return Ok(prescription);

        }


        //API for Geting Time slot Avilability in Doctor details
        [HttpGet]
        [Route("Slot Availability")]
        public IActionResult GetSlotAvalability(int id)
        {
            var timeslot = _database.GetTimeSlot(id);
            if (timeslot == null)
            {
                return NotFound();
            }
            return Ok(timeslot);
        }


        //API for getting perticular booked detailes
        [HttpGet]
        [Route("Booked Details")]
        public IActionResult GetBookedDetails(int id)
        {
            var bookeddetails = _database.GetBookedPatientDetails(id);
            if (bookeddetails == null)
            {
                return NotFound();
            }
            return Ok(bookeddetails);
        }
        // API for Getting the patient prescription by Booking Id 
        [HttpGet]
        [Route("Patient Prescriptions")]
        public IActionResult GetPrescription(int id)
        {
            var prescrition = _database.GetPrescription(id);
            if (prescrition == null)
            {
                return NotFound();
            }
            return Ok(prescrition);
        }

        //API for Getting List Of Booked Patients by Today Date
        [HttpGet]
        [Route("List of Booked patients")]
        public IActionResult GetBookedPatientList()
        {
            var results = _database.GetBookedPatientList();
            if (results == null)
            {
                return NoContent();
            }
            return Ok(results);
        }

        //API for Getting List of Past consultations by UserId
        [HttpGet]
        [Route("List of Past Consults")]
        public IActionResult GetPastConsultations(int id)
        {
            var pastconsults = _database.GetPatientPastConsults(id);
            if (pastconsults == null)
            {
                return NoContent();
            }
            return Ok(pastconsults);
        }

        //API for Getting Perticulat Consultation by Booking Id
        [HttpGet]
        [Route("Past Consultation")]
        public IActionResult GetPastConsultation(int id)
        {
            var pastconsult = _database.PatientPastConsultation(id);
            if (pastconsult == null)
            {
                return NoContent();
            }
            return Ok(pastconsult);

        }
    }
}
