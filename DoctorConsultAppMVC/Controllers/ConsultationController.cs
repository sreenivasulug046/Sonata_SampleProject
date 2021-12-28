﻿using DoctorConsultAppMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace DoctorConsultAppMVC.Controllers
{
    public class ConsultationController : Controller
    {
        Uri baseadress = new Uri("http://localhost:4919/api/");
        HttpClient client;
        public ConsultationController()
        {
            client = new HttpClient();
            client.BaseAddress = baseadress;

        }
        // GET: Consultation
        public ActionResult DoctorLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoctorLogin(DoctorLogin login)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("DoctorConsultApp/DoctorLogin", login).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetdoctorList");
            }
            
            return View();

        }

        public ActionResult RegisterDoctor()
        {
            return View(new DoctorRegistration());
        }

        [HttpPost]
        public ActionResult AddDoctor(DoctorRegistration doctor)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("DoctorConsultApp/RegisterDoctor", doctor).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("DoctorLogin");
            }

            return View();

        }


        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(UserLogin login)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("DoctorConsultApp/UserLogin", login).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetdoctorList");
            }

            return View();

        }



        public ActionResult GetdoctorList()
        {
            List<DoctorModel> doctorlst = new List<DoctorModel>();
            HttpResponseMessage response = client.GetAsync("DoctorConsultApp/ListOfDoctors").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                doctorlst = JsonConvert.DeserializeObject<List<DoctorModel>>(data);

            }
            return View(doctorlst);
        }
        public ActionResult GetBookedPatient()
        {
            List<BookedModel> doctorlst = new List<BookedModel>();
            HttpResponseMessage response = client.GetAsync("DoctorConsultApp/Booked Details").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                doctorlst = JsonConvert.DeserializeObject<List<BookedModel>>(data);

            }
            return View(doctorlst);
        }

        //To get Prescription(Not yet Completed)
        public ActionResult GetPrescription()
        {
            List<BookedModel> doctorlst = new List<BookedModel>();
            HttpResponseMessage response = client.GetAsync("DoctorConsultApp/Booked Details").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                doctorlst = JsonConvert.DeserializeObject<List<BookedModel>>(data);

            }
            return View(doctorlst);
        }






    }
}