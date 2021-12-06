using DoctorConsultApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorConsultApp.Services
{
    public interface IHomeServices
    {
        public List<Doctor> GetAll();
        public Doctor GetDoctor(int id);
    }
}
