using DoctorConsultApp.Controllers;
using DoctorConsultApp.Models;
using DoctorConsultApp.Services;
using DoctorConsultDBContext.Models;
using DoctorsConsultAppTest.Services;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DoctorsConsultAppTest
{
    public class DoctorsConsultAppTestController

    {

        private readonly IDoctorConsultAppServices _services;
        private readonly IDoctorConsultAppServices _service;
        private readonly DoctorConsultationAppDBContext dbcontext;
        private readonly DoctorConsultAppController controller;
        private readonly DoctorConsultAppController _controller;

        public DoctorsConsultAppTestController()
        {
            _service = new ConsultationServicesFake();
            _services = A.Fake<IDoctorConsultAppServices>();
            controller = new DoctorConsultAppController(_services, dbcontext);
            _controller = new DoctorConsultAppController(_service, dbcontext);
        }

        [Fact]
        public void AddNewDoctor_ShouldReturnSuccess()
        {
            //Arrange
            DoctorAddModel testItem = new DoctorAddModel()
            {
                DoctorName = "Raju",
                Gender = "Male",
                PhNo = "9515881237",
                Email = "raju@gmail.com",
                Specilization = "doctor",
                Password = "raju123"
            };
            // Act
            IActionResult createdResponse = controller.AddDoctor(testItem);
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse as OkObjectResult);
        }
        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreated()
        {
            // Arrange
            var testItem = new DoctorAddModel()
            {
                DoctorName = "Raju",
                Gender = "Male",
                PhNo = "9515881237",
                Email = "raju@gmail.com",
                Specilization = "doctor",
                Password = "raju123"
            };
            // Act
            OkObjectResult createdResponse = controller.AddDoctor(testItem) as OkObjectResult;
            DoctorAddModel item = createdResponse.Value as DoctorAddModel;
            // Assert
            Assert.IsType<DoctorAddModel>(item);
            Assert.Equal("Raju", item.DoctorName);
        }

        [Fact]
        public void GetAllDoctorsList_WhenCalled_ReturnsOkResult()
        {
            // Act
            IActionResult okResult = _controller.GetAllDoctorsList();
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            OkObjectResult okResult = _controller.GetAllDoctorsList() as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<DoctorModel>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        //Get Doctordetails

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            IActionResult okResult = controller.GetDoctorDetails(101);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
       
        [Fact]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            int testid = 1;
            // Act
            OkObjectResult okResult = _controller.GetDoctorDetails(testid) as OkObjectResult;
            // Assert
            Assert.IsType<DoctorDetailsModel>(okResult.Value);
            Assert.Equal(testid, (okResult.Value as DoctorDetailsModel).DoctorId);
        }

        //Get Slot
        [Fact]
        public void GetSlot_WhenCalled_ReturnsOkResult()
        {
            // Act
            IActionResult okResult = controller.GetSlotAvalability(101);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        //Get Booked Patient List
        [Fact]
        public void GetBookedPatientList_WhenCalled_ReturnsOkResult()
        {
            // Act
            IActionResult okResult = controller.GetBookedPatientList(101);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        //Get Booked Patient

        [Fact]
        public void GetBookedPatient_WhenCalled_ReturnsOkResult()
        {
            // Act
            IActionResult okResult = controller.GetBookedDetails(10001);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        //Get Prescription

        [Fact]
        public void GetPrescription_WhenCalled_ReturnsOkResult()
        {
            // Act
            IActionResult okResult = controller.GetPrescription(10001);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        //Get Past Consultations
        [Fact]
        public void GetPastConsults_WhenCalled_ReturnsOkResult()
        {
            // Act
            IActionResult okResult = controller.GetPastConsultations(1001);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
        //Get Past Consultation

        [Fact]
        public void GetPastConsultation_WhenCalled_ReturnsOkResult()
        {
            // Act
            IActionResult okResult = controller.GetPastConsultation(10001);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }


        [Fact]
        public void AddNewbooking_ShouldReturnSuccess()
        {
            //Arrange
            BookingModel testItem = new BookingModel()
            {
               DoctorId=1,
               UserId=1,
               PName="Ravi",
               Gender="Male",
               Problem="Feaver",
               Age="25",
               BookingDate="11/01/2022",
               StartTime="08:00AM",
               EndTime="09:00AM"
            };
            // Act
            IActionResult createdResponse = controller.AddBooking(testItem);
            // Assert
            Assert.IsType<OkObjectResult>(createdResponse as OkObjectResult);
        }
        [Fact]
        public void AddBooking_ValidObjectPassed_ReturnedResponseHasCreated()
        {
            // Arrange
            var testItem = new BookingModel()
            {
                DoctorId = 1,
                UserId = 1,
                PName = "Ravi",
                Gender = "Male",
                Problem = "Feaver",
                Age = "25",
                BookingDate = "11/01/2022",
                StartTime = "08:00AM",
                EndTime = "09:00AM"
            };
            // Act
            OkObjectResult createdResponse = controller.AddBooking(testItem) as OkObjectResult;
            BookingModel item = createdResponse.Value as BookingModel;
            // Assert
            Assert.IsType<BookingModel>(item);
            Assert.Equal("Ravi", item.PName);
        }

    }
}
