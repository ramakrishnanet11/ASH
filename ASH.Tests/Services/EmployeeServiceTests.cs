using ASH.COMMON.Models;
using ASH.DATA.implementations;
using ASH.DATA.Repos.interfaces;
using ASH.DATA.Services.interfaces;
using Moq;
using DM = ASH.DATA.Models;

namespace ASH.Tests.Services
{
    [TestFixture]
    public class EmployeeServiceTests
    {
        private IEmployeeService _employeeService;
        private Mock<IEmployeeRepository> _employeeRepository;
        [SetUp]
        public void Setup()
        {
            _employeeRepository = new Mock<IEmployeeRepository>();
            _employeeService = new EmployeeService(_employeeRepository.Object);

        }

        [Test]
        public void Save()
        {
            var employee = new Employee() {
                Id = 0,
                FirstName = "Ramla",
                LastName = "Hrishna",
                Address1 = "Texas",
                PayPerHour = 100,
                EmployeeTypeId = 1,
            };
            _employeeRepository.Setup(s => s.Save(It.IsAny<DM.Employee>(), It.IsAny<int>())).Returns(new DM.Employee()
            {
                Id = 1,
                FirstName = "Ramla",
                LastName = "Hrishna",
                Address1 = "Texas",
                PayPerHour = 100,
                EmployeeTypeId = 1,
                EmployeeType = new DM.EmployeeType() { Title = "Employee" }
            });

            CommonResponse<Employee> result =  _employeeService.Save(employee, 1);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual(employee.FirstName, result.Data.FirstName);
            Assert.AreEqual(employee.LastName, result.Data.LastName);
            Assert.AreEqual(employee.Address1, result.Data.Address1);
            Assert.AreEqual(result.Data.Id, 1);
            Assert.AreEqual(result.Data.Type, "Employee");
        }

        [Test]
        public void SaveWithException()
        {
            var employee = new Employee()
            {
                Id = 0,
                FirstName = "Ramla",
                LastName = "Hrishna",
                Address1 = "Texas",
                PayPerHour = 100,
                EmployeeTypeId = 1,
            };
            _employeeRepository.Setup(s => s.Save(It.IsAny<DM.Employee>(), It.IsAny<int>())).Throws(new Exception("Invalid Database"));
            CommonResponse<Employee> result = _employeeService.Save(employee, 1);
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(result.ErrorMessage, "Invalid Database");
        }
    }
}