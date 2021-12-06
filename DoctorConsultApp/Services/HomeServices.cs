using DoctorConsultApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorConsultApp.Services
{
    public class HomeServices : IHomeServices
    {
        private DoctorConsultAppDBContext _DbContext;
        public HomeServices(DoctorConsultAppDBContext DbContext)
        {
            _DbContext = DbContext;    
        }

        //for geting list of doctors
        public List<Doctor> GetAll()
        {
            var data = _DbContext.Doctors
                .Select(f => new Doctor
                {
                    DoctorName = f.DoctorName,
                    Specilization = f.Specilization,
                    PhNo = f.PhNo,

                })
                .ToList();
            return data;
        }

        //for getting perticular doctor detailes
        public Doctor GetDoctor(int id)
        {

            var result = _DbContext.Doctors
                 .Where(f => f.DoctorId == id)
                 .Select(f => new Doctor
                 {
                     DoctorId = f.DoctorId,
                     DoctorName = f.DoctorName,
                     Specilization = f.Specilization,
                     PhNo = f.PhNo,
                     Email = f.Email
                 }).FirstOrDefault();

            return result;
        }
    }
}
