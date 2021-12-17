using DoctorConsultApp.Controllers;
using DoctorConsultApp.Models;
using DoctorConsultApp.Services;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DoctorsConsultAppTest
{
    public class DoctorsConsultAppTestController

    {
        [Fact]
        public  void GetDoctors_Returns_the_Correct_number_of_Doctors()
        {
            //Arrange
            int count = 5;
            var FakeDoctors = A.CollectionOfDummy<DoctorModel>(count).AsEnumerable();
            var datasource = A.Fake<IDoctorConsultAppServices>();
            A.CallTo(() =>datasource.GetAll(count)).Returns(Task.FromResult(FakeDoctors));
            var Controller = new DoctorConsultAppController(datasource);
            //Act
            var ActionResult= Controller.GetAllDoctorsList();
            //Assert
            var Result=ActionResult.Result as OkObjectResult;
            var ReturnDoctors = Result.Value as IEquatable<DoctorModel>;
            Assert.Equal(count, ReturnDoctors.count());

        }
    }
}
