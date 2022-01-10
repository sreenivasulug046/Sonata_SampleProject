using DoctorConsultApp.Controllers;
using DoctorConsultApp.Models;
using DoctorConsultApp.Services;
using DoctorConsultDBContext.Models;
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
        private readonly DoctorConsultationAppDBContext dbcontext;
        private readonly DoctorConsultAppController controller;

        public DoctorsConsultAppTestController()
        {
            _services = A.Fake<IDoctorConsultAppServices>();
            controller = new DoctorConsultAppController(_services, dbcontext);
        }
        //[Fact]
        //public  void GetDoctors_Returns_the_Correct_number_of_Doctors()
        //{
        //    //Arrange
        //    int count = 5;
        //    var FakeDoctors = A.CollectionOfDummy<DoctorModel>(count).AsEnumerable();
        //    var datasource = A.Fake<IDoctorConsultAppServices>();
        //    A.CallTo(() =>datasource.GetAll(count)).Returns(Task.FromResult(FakeDoctors));
        //    var Controller = new DoctorConsultAppController(datasource);
        //    //Act
        //    var ActionResult= Controller.GetAllDoctorsList();
        //    //Assert
        //    var Result=ActionResult.Result as OkObjectResult;
        //    var ReturnDoctors = Result.Value as IEquatable<DoctorModel>;
        //    Assert.Equal(count, ReturnDoctors.count());

        //}

        //Get All Doctor List
        [Fact]
        public void GetAllDoctorsList_WhenCalled_ReturnsOkResult()
        {
            // Act
            IActionResult okResult = controller.GetAllDoctorsList();
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            OkObjectResult okResult = controller.GetAllDoctorsList() as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<DoctorModel>>(okResult);
            Assert.Equal(5, items.Count);
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
        public void GetById_Passed_ReturnsNotFoundResult()
        {
            // Act
            IActionResult notFoundResult = controller.GetDoctorDetails(1001);
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }
        //[Fact]
        //public void GetDoctorById_DoctorObject_DoctorwithSpecificeIdExists()
        //{
        //    //arrange
        //    var employees = GetSampleEmployee();
        //    var firstEmployee = employees[0];
        //    service.Setup(x => x.GetById((long)1))
        //        .Returns(firstEmployee);
        //    var controller = new EmployeeController(service.Object);

        //    //act
        //    var actionResult = controller.GetEmployeeById((long)1);
        //    var result = actionResult.Result as OkObjectResult;

        //    //Assert
        //    Assert.IsType<OkObjectResult>(result);

        //    result.Value.Should().BeEquivalentTo(firstEmployee);
        //}
        [Fact]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            int testid = 101;
            // Act
            OkObjectResult okResult = controller.GetDoctorDetails(testid) as OkObjectResult;
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

        [Fact]
        public void Getslot_Passed_ReturnsNotFoundResult()
        {
            // Act
            IActionResult notFoundResult = controller.GetSlotAvalability(106);
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
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
        //Add

        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            DoctorAddModel testItem = new DoctorAddModel()
            {
                DoctorName = "Ravi",
                Gender="male",
                Specilization="cardialagist",
                PhNo="9009887881",
                Email="ravi@gmail.com",
                Password="ravi123"

            };
            // Act
            IActionResult createdResponse = controller.AddDoctor(testItem);
            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            var testItem = new DoctorAddModel()
            {
                DoctorName = "Ravi",
                Gender = "male",
                Specilization = "cardialagist",
                PhNo = "9009887881",
                Email = "ravi@gmail.com",
                Password = "ravi123"
            };
            // Act
            CreatedAtActionResult createdResponse = controller.AddDoctor(testItem) as CreatedAtActionResult;
            DoctorAddModel item = createdResponse.Value as DoctorAddModel;
            // Assert
            Assert.IsType<DoctorAddModel>(item);
            Assert.Equal("Ravi", item.DoctorName);
        }


    }
}
