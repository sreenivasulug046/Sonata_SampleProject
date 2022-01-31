using DoctorConsultAppMVC.Models;
using Kendo.Mvc.Extensions;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
            try
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
            catch (Exception ex) { return View(ex); }                      
        }
        public ActionResult DoctorProfile()
        {
            if (Session["Doctor"] != null)
            {
                try
                {
                    var doctorlst = new DoctorModel();
                    HttpResponseMessage response = client.GetAsync("DoctorConsultApp/DoctorDetails?id=" + Session["DoctorId"]).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync().Result;
                        doctorlst = JsonConvert.DeserializeObject<DoctorModel>(data);
                    }
                    return View(doctorlst);
                }
                catch (Exception ex){ return View(ex); }               
            }
            else
            {
                return RedirectToAction("DoctorLogin");
            }
        }
        public ActionResult BookedApointments()
        {
            if (Session["Doctor"] != null)
            {
                try
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
                catch (Exception ex)
                {
                    return View(ex);
                }                
            }
            else
            {
                return RedirectToAction("DoctorLogin");
            }
        }
        public ActionResult ApointmentDetails(int id)
        {       
            if (Session["Doctor"] != null)
            {
                try
                {
                    var apointment = new ApointmentDetails();
                    HttpResponseMessage response = client.GetAsync("DoctorConsultApp/BookedDetails?id=" + id).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync().Result;
                        apointment = JsonConvert.DeserializeObject<ApointmentDetails>(data);
                        Session["UserID"] = apointment.UserId;
                        Session["BookingID"] = apointment.BookingId;
                    }
                    return View(apointment);
                }
                catch (Exception ex)
                {
                    return View(ex);
                }               
            }
            else
            {
                return RedirectToAction("DoctorLogin");
            }
        }
        public ActionResult RegisterDoctor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterDoctor(DoctorRegistration doctor)
        {
            try
            {
                HttpResponseMessage response = client.PostAsJsonAsync("DoctorConsultApp/RegisterDoctor", doctor).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("DoctorLogin");
                }
                return View();
            }
            catch (Exception ex)
            {
                return View(ex);
            }          
        }
        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(UserLogin login)
        {
            try
            {
                HttpResponseMessage response = client.PostAsJsonAsync("DoctorConsultApp/UserLogin", login).Result;
                if (response.IsSuccessStatusCode)
                {
                    Session["User"] = login.Email;
                    var user = UserbyEmail();
                    Session["UserId"] = user.UserId;
                    Session["UserName"] = user.UserName;
                    var data = response.Content.ReadAsStringAsync().Result;
                    return RedirectToAction("UserHome", "Home");
                }
                else
                {
                    ViewData["Message"] = "Invalid Credentials.. Login Failed";
                }
                return View();
            }
            catch (Exception ex)
            {
                return View(ex);
            }          
        }
        public ActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterUser(UserRegistration doctor)
        {
            try
            {
                HttpResponseMessage response = client.PostAsJsonAsync("DoctorConsultApp/RegisterUser", doctor).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("UserLogin");
                }
                return View();
            }
            catch (Exception ex)
            {
                return View(ex);
            }           
        }
        public ActionResult UserProfile()
        {
            if (Session["User"] != null)
            {
                try
                {
                    var user = new UserProfile();
                    HttpResponseMessage response = client.GetAsync("DoctorConsultApp/UserProfile?Userid=" + Session["UserId"]).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync().Result;
                        user = JsonConvert.DeserializeObject<UserProfile>(data);
                    }
                    return View(user);
                }
                catch (Exception ex)
                {

                    return View(ex);
                }
                
            }
            else
            {
                return RedirectToAction("UserLogin");
            }
        }
        public ActionResult GetdoctorList()
        {
            if (Session["User"] != null)
            {
                try
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
                catch (Exception ex)
                {
                    return View(ex);
                }              
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
                try
                {
                    var doctorlst = new DoctorModel();
                    HttpResponseMessage response = client.GetAsync("DoctorConsultApp/DoctorDetails?id=" + id).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync().Result;
                        doctorlst = JsonConvert.DeserializeObject<DoctorModel>(data);
                        Session["DoctorIdforbooking"] = doctorlst.DoctorId;
                    }
                    return View(doctorlst);
                }
                catch (Exception ex)
                {

                    return View(ex);
                }
                
            }
            else
            {
                return RedirectToAction("UserLogin");
            }
        }
        public ActionResult PastConsultList()
        {
            if (Session["User"] != null)
            {
                try
                {
                    var pastconsults = new List<PastConsultList>();
                    HttpResponseMessage response = client.GetAsync("DoctorConsultApp/ListofPastConsults?id=" + Session["UserId"]).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync().Result;
                        pastconsults = JsonConvert.DeserializeObject<List<PastConsultList>>(data);
                    }
                    return View(pastconsults);
                }
                catch (Exception ex)
                {
                    return View(ex);
                }              
            }
            else
            {
                return RedirectToAction("UserLogin");
            }
        }
        public ActionResult PastConsultationDetails(int id)
        {
            if (Session["User"] != null)
            {
                try
                {
                    var pastconsult = new PastConsultationDetails();
                    HttpResponseMessage response = client.GetAsync("DoctorConsultApp/PastConsultation?id=" + id).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync().Result;
                        pastconsult = JsonConvert.DeserializeObject<PastConsultationDetails>(data);
                    }
                    return View(pastconsult);
                }
                catch (Exception ex)
                {
                    return View(ex);
                }                
            }
            else
            {
                return RedirectToAction("UserLogin");
            }
        }
        public DoctorModel DoctorbyEmail()
        {
            var doctorlst = new DoctorModel();
            try
            {            
                HttpResponseMessage response = client.GetAsync("DoctorConsultApp/DoctorDetailsbyEmail?Email=" + Session["Doctor"]).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    doctorlst = JsonConvert.DeserializeObject<DoctorModel>(data);
                }
                return doctorlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
        public ActionResult GetBookedPatient()
        {
            if (Session["Doctor"] != null)
            {
                try
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
                catch (Exception ex)
                {
                    return View(ex);
                }             
            }
            else
            {
                return RedirectToAction("DoctorLogin");
            }          
        }
        //To get Prescription(Not yet Completed)
        public ActionResult GetPrescription(int id)
        {
            if (Session["User"] != null)
            {
                try
                {
                    DownloadPrescription prescription = new DownloadPrescription();
                    HttpResponseMessage response = client.GetAsync("DoctorConsultApp/PatientPrescriptions?id=" + id).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        prescription = JsonConvert.DeserializeObject<DownloadPrescription>(data);
                        return View(prescription);
                    }
                    return RedirectToAction("NoContent", "Home");
                }
                catch (Exception ex)
                {
                    return View(ex);
                }                
            }
            else
            {
                return RedirectToAction("UserLogin");
            }         
        }
        public ActionResult UploadPrescription()
        {
            if (Session["Doctor"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("DoctorLogin");
            }          
        }
        [HttpPost]
        public ActionResult UploadPrescription(UploadPrescription model)
        {
            try
            {
                if (Session["Doctor"] != null)
                {
                    PrescriptionAdd prescrptionadd = new PrescriptionAdd();
                    string filename = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                    string extension = Path.GetExtension(model.ImageFile.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssfff");
                    model.prescription = "~/images/" + filename;
                    filename = Path.Combine(Server.MapPath("~/images/"), filename);
                    model.ImageFile.SaveAs(filename);
                    prescrptionadd.UserId = (int)Session["UserID"];
                    prescrptionadd.BookingId = (int)Session["BookingID"];
                    prescrptionadd.DoctorId = (int)Session["DoctorId"];
                    prescrptionadd.AdditionalSuggestion = model.AdditionalSuggestion;
                    prescrptionadd.prescription = model.prescription;
                    using (HttpResponseMessage response = client.PostAsJsonAsync("DoctorConsultApp/AddPrescription", prescrptionadd).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToAction("BookedApointments");
                        }
                    }
                    return View();
                }
                else
                {
                    return RedirectToAction("DoctorLogin");
                }
            }
            catch (Exception ex)
            {             
                return View(ex);
            }            
        }
        public ActionResult Slots(int id)
        {
            if (Session["User"] != null)
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
            else
            {
                return RedirectToAction("UserLogin");
            }
        }
        public ActionResult SlotDetails(int id)
        {
            if (Session["User"] != null)
            {
                CheckSlot slot = new CheckSlot();
                HttpResponseMessage response = client.GetAsync("DoctorConsultApp/SlotDetails?slotid=" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    slot = JsonConvert.DeserializeObject<CheckSlot>(data);
                    Session["Starttime"] = slot.StartTime;
                    Session["Endtime"] = slot.EndTime;
                    Session["BookingDate"] = slot.SDate;
                }
                return RedirectToAction("Booking");
            }
            else
            {
                return RedirectToAction("UserLogin");
            }
        }
        // Action Method for booking Appointment
        public ActionResult Booking()
        {
            if (Session["User"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("UserLogin");
            }
        }
        [HttpPost]
        public ActionResult Booking(Booking bookig)
        {
            if (Session["User"] != null)
            {
                bool isMailSent = false;
                bookig.DoctorId = (int)Session["DoctorIdforbooking"];
                bookig.UserId = (int)Session["UserID"];
                bookig.StartTime = (string)Session["StartTime"];
                bookig.EndTime = (string)Session["Endtime"];
                bookig.BookingDate = (string)Session["BookingDate"];
                HttpResponseMessage response = client.PostAsJsonAsync("DoctorConsultApp/Booking", bookig).Result;
                if (response.IsSuccessStatusCode)
                {
                    var DoctorName = bookig.DoctorId;
                    var starttime = bookig.StartTime;
                    var Endtime = bookig.EndTime;
                    string message = "Your Appointment has been confirmed. Please see below." + Environment.NewLine;
                    message = message + "DoctorId :" + DoctorName + Environment.NewLine;
                    message = message + "Start time :" + starttime.ToString() + "End time :" + Endtime.ToString() + Environment.NewLine;
                    isMailSent = SendEMail("sreenivasulu.g046@gmail.com", "Hello User", message);
                    return RedirectToAction("GetdoctorList");
                }
                return View();
            }
            else
            {
                return RedirectToAction("UserLogin");
            }         
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        public bool SendEMail(string toAddress, string subject, string mailBody)
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
                        smtp.Credentials = new NetworkCredential("gounolla.s0205@gmail.com", "Gowthu123@");
                        smtp.UseDefaultCredentials = true;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.EnableSsl = true;
                        smtp.Send(mail);

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return false;
            }
        }
        //method for getting UserId
        public UserProfile UserbyEmail()
        {
            var doctorlst = new UserProfile();
            HttpResponseMessage response = client.GetAsync("DoctorConsultApp/UserProfilebyEmail?Email=" + Session["User"]).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                doctorlst = JsonConvert.DeserializeObject<UserProfile>(data);
            }
            return doctorlst;
        }
    }
}