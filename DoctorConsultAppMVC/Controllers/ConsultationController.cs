using DoctorConsultAppMVC.Models;
using Kendo.Mvc.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
            var log = new DoctorLogin();
            HttpResponseMessage response = client.PostAsJsonAsync("DoctorConsultApp/DoctorLogin", login).Result;
            if (response.IsSuccessStatusCode)
            {
                Session["Doctor"] = login.Email.ToString();
                var data = DoctorbyEmail();
                Session["DoctorId"] = data.DoctorId;
                return RedirectToAction("BookedApointments");

            }
            else
            {
                ViewData["Message"] = "Invalid Credentials.. Login Failed";
            }
            return View();

        }
        public ActionResult BookedApointments()
        {
            if (Session["Doctor"] != null)
            {
                List<BookedModel> doctorlst = new List<BookedModel>();
                HttpResponseMessage response = client.GetAsync("DoctorConsultApp/List of Booked patients?id=" + Session["DoctorId"]).Result;
                if (response.IsSuccessStatusCode)
                {

                    var data = response.Content.ReadAsStringAsync().Result;
                    doctorlst = JsonConvert.DeserializeObject<List<BookedModel>>(data);

                }
                return View(doctorlst);
            }
            else
            {
                return RedirectToAction("DoctorLogin");
            }

        }

        public ActionResult ApointmentDetails(int bookingid)
        {
            if (Session["Doctor"] != null)
            {
                var apointment = new Booking();
                HttpResponseMessage response = client.GetAsync("DoctorConsultApp/Booked Details?id=" + bookingid).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    apointment = JsonConvert.DeserializeObject<Booking>(data);
                }
                return View(apointment);
            }
            else
            {
                return RedirectToAction("DoctorLogin");
            }
        }


        public ActionResult RegisterDoctor()
        {
            return View(new DoctorRegistration());
        }

        [HttpPost]
        public ActionResult RegisterDoctor(DoctorRegistration doctor)
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
                Session["User"] = login.Email;
               var data= response.Content.ReadAsStringAsync().Result;
               

                return RedirectToAction("GetdoctorList");
            }
            else
            {
                ViewData["Message"] = "Invalid Credentials.. Login Failed";
            }

            return View();

        }

        public ActionResult RegisterUser()
        {
            return View(new UserRegistration());
        }

        [HttpPost]
        public ActionResult RegisterUser(UserRegistration doctor)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("DoctorConsultApp/RegisterUser", doctor).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("UserLogin");
            }

            return View();

        }



        public ActionResult GetdoctorList()
        {
            if (Session["User"] != null)
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
            else
            {
                return RedirectToAction("UserLogin");
            }          
        }

        //Get doctor detailes by id
        public ActionResult Search(int id)
        {
            if (Session["User"] != null)
            {
                var doctorlst = new DoctorModel();
                HttpResponseMessage response = client.GetAsync("DoctorConsultApp/DoctorDetails?id=" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    doctorlst = JsonConvert.DeserializeObject<DoctorModel>(data);
                }
                return View(doctorlst);
            }
            else
            {
                return RedirectToAction("UserLogin");
            }

        }

        public DoctorModel DoctorbyEmail()
        {
                var doctorlst = new DoctorModel();
                HttpResponseMessage response = client.GetAsync("DoctorConsultApp/DoctorDetailsbyEmail?Email=" + Session["Doctor"]).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    doctorlst = JsonConvert.DeserializeObject<DoctorModel>(data);
                }
                return doctorlst;
            

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

        public ActionResult UploadPrescription()
        {
            return View(new UploadPrescription());
        }

        [HttpPost]
        public ActionResult UploadPrescription(UploadPrescription prescription)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("DoctorConsultApp/AddPrescripion", prescription).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("UserLogin");
            }

            return View();
        
        }
        public ActionResult Slots(int id)
        {
            List<CheckSlot> slots = new List<CheckSlot>();
            HttpResponseMessage response = client.GetAsync("DoctorConsultApp/Slot Availability?id=" + id).Result;
            if (response.IsSuccessStatusCode)
            {

                var data = response.Content.ReadAsStringAsync().Result;
                slots = JsonConvert.DeserializeObject<List<CheckSlot>>(data);

            }
            return View(slots);

        }

        // Action Method for booking Appointment
        public ActionResult Booking()
        {
            return View(new Booking());
        }

        [HttpPost]
        public ActionResult Booking(Booking bookig)
        {
            bool isMailSent = false;
            HttpResponseMessage response = client.PostAsJsonAsync("DoctorConsultApp/Booking", bookig).Result;

            if (response.IsSuccessStatusCode)
            {
                var DoctorName = bookig.DoctorId;
                var starttime = bookig.StartTime;
                var Endtime = bookig.EndTime;
                string message = "Your Appointment has been confirmed. Please see below." + Environment.NewLine;
                message = message + "DoctorId :" + DoctorName + Environment.NewLine;
                message = message + "Start time :" + starttime.ToString() + "End time :" + Endtime.ToString() + Environment.NewLine;
                isMailSent = SendEMail("sreenivasulu.g046@gmail.com", "Hello User",message);

                return RedirectToAction("GetdoctorList");
            }

            return View();

        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }
        public bool SendEMail(string toAddress,string subject, string mailBody)
        {
            // string senderEmail = System.Configuration.ConfigurationManager.AppSettings["senderEmail"].ToString();
            //string senderPassword = System.Configuration.ConfigurationManager.AppSettings["senderPassword"].ToString();
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("gounolla.s0205@gmail.com");
                    mail.To.Add(toAddress);
                    mail.Subject = subject;
                    mail.Body = mailBody;
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("gounolla.s0205@gmail.com", "Sseenu143@");
                        smtp.UseDefaultCredentials = true;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.EnableSsl = true;
                        smtp.Send(mail);

                        return true;
                    }
                    
                }

            }
            catch(Exception ex)
            {
                var msg=ex.Message;
                return false;

            }
            





            //try
            //{
            //    string senderEmail = System.Configuration.ConfigurationManager.AppSettings["senderEmail"].ToString();
            //    string senderPassword = System.Configuration.ConfigurationManager.AppSettings["senderPassword"].ToString();
            //    //MailMessage mail = new MailMessage();
            //    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587);
            //    SmtpServer.EnableSsl = true;
            //    SmtpServer.Timeout = 20000;
            //    SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            //    SmtpServer.UseDefaultCredentials = false;
            //    SmtpServer.Credentials = new NetworkCredential(senderEmail, senderPassword);

            //    MailMessage mail = new MailMessage(senderEmail, toAddress, subject, mailBody);
            //    mail.IsBodyHtml = true;
            //    mail.BodyEncoding = UTF8Encoding.UTF8;
            //    SmtpServer.Send(mail);
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    //_logger.LogError($"There was an {ex.Message}");
            //    return false;
            //}

        }

        






    }
}