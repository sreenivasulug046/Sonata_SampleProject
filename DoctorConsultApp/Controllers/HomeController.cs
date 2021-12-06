using DoctorConsultApp.Services;
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
    public class HomeController : ControllerBase
    {
        private IHomeServices _database;
        public HomeController(IHomeServices database)
        {
            _database = database;
        }

        //API for List of Doctors With Specilization
        [HttpGet]
        [Route("ListOfDoctors")]
        public IActionResult GetAllDoctorsLis()
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
        [Route("id")]
        public IActionResult GetDoctorDetails(int id)
        {
            var doctor = _database.GetDoctor(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }
    }
}
