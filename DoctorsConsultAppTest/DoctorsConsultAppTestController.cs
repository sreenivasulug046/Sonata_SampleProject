using DoctorConsultApp.Controllers;
using DoctorConsultApp.Models;
using DoctorConsultApp.Services;
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
        private readonly DoctorConsultAppController controller;

        public DoctorsConsultAppTestController()
        {
            _services = A.Fake<IDoctorConsultAppServices>();
            controller = new DoctorConsultAppController(_services);
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
        public void GetAll_WhenCalled_ReturnsOkResult()
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
            var items = Assert.IsType<List<DoctorModel>>(okResult.Value);
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
            IActionResult notFoundResult = controller.GetDoctorDetails(109);
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }
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

       
    }
}
