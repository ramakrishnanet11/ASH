using ASH.API.Controllers;
using ASH.COMMON.Models;
using ASH.DATA.Services.interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ASH.Tests.Controllers
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        private  Mock<IEmployeeService> _employeeService;
        private  EmployeeController _employeeController;

        [SetUp]
        public void Setup()
        {
            _employeeService = new Mock<IEmployeeService>();
            _employeeController = new EmployeeController(_employeeService.Object);
        }

        [Test]
        public void AddEmployee()
        {
            var employee = new Employee
            {
                Id = 1,
                FirstName = "Rama",
                LastName = "Krishna",
                Address1 = "Texas",
                PayPerHour = 10,
                AnnualSalary = 0
            };

            CommonResponse<Employee> result = new CommonResponse<Employee>() { };
            result.Data = employee;
            _employeeService.Setup(emp => emp.Save(It.IsAny<Employee>(), It.IsAny<int>())).Returns(result);

            var httpResponse =_employeeController.Add(employee);
            var response = (CommonResponse<Employee>)(httpResponse as OkObjectResult).Value;

            _employeeService.Verify(e => e.Save(It.IsAny<Employee>(), employee.Id), Times.Once);
            Assert.IsTrue(httpResponse is OkObjectResult);
            Assert.AreEqual(response.Data.Id, employee.Id);
            Assert.AreEqual(response.Data.FirstName, employee.FirstName);
            Assert.AreEqual(response.Data.LastName, employee.LastName);
            Assert.AreEqual(response.Data.Address1, employee.Address1);

        }
    }
}