using Business_Layer;
using Data_Access_Layer.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json;
using WebAPI201_Employees.Controllers;

namespace WebAPI201.Employees.API.TestProject
{
    [TestClass]
    public class EmployeesControllerTest
    {

        EmployeeService _employeeService;
        IRepository<Employee> _employeeRepository;

        [TestInitialize]
        public void Setup()
        {
            var employees = new List<Employee>();
            employees.Add(new Employee { Id = 1, firstName = "Sateswar", lastName = "Sahu", email = "s.sahu@test.com", DepartmentId = 1, JobId = 1, phoneNumber = "234234", salary = 123124 });
            employees.Add(new Employee { Id = 2, firstName = "Sateswar", lastName = "Sahu", email = "s.sahu@test.com", DepartmentId = 1, JobId = 1, phoneNumber = "234234", salary = 123124 });

            var repoMock = new Mock<IRepository<Employee>>();
            repoMock.Setup(r => r.GetAll()).Returns(employees);
            _employeeRepository = repoMock.Object;
            _employeeService = new EmployeeService(_employeeRepository);
        }

        [TestMethod]
        public void Get_AllEmployeeRecords_whenItIsCalled()
        {
            //Arrange
            var listOfEmployee = new EmployeesController(_employeeService, _employeeRepository);


            //Act
            var result = listOfEmployee.GetAllEmployees();


            //Assert

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

        }

        [TestMethod]
        public void GetEmployeeById_whenItIsCalled()
        {
            //Arrange
            var listOfEmployee = new EmployeesController(_employeeService, _employeeRepository);


            //Act
            var result = listOfEmployee.GetEmployeeById(1);
            //Act
            var result1 = listOfEmployee.GetEmployeeById(100000000);


            //Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));


            //Assert
            //Assert.IsInstanceOfType(result1, typeof(OkObjectResult));

        }


        [TestMethod]
        public void DeleteEmployeeById_whenItIsCalled()
        {
            //Arrange

            var listOfEmployee = new EmployeesController(_employeeService, _employeeRepository);
            //Act
            var result = listOfEmployee.DeleteEmployeeByEmployeeId(1);

            //Assert

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void DeleteEmployeeById_whenItIsCalled_WithNullValue()
        {
            //Arrange

            var listOfEmployee = new EmployeesController(_employeeService, _employeeRepository);
            //Act
            var result = listOfEmployee.DeleteEmployeeByEmployeeId(300);

            //Assert

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void DeleteEmployeeById_whenItIsCalled_ForException()
        {
            //Arrange

            var listOfEmployee = new EmployeesController(_employeeService, _employeeRepository);
            //Act
            listOfEmployee.DeleteEmployeeByEmployeeId(500);
            var result = listOfEmployee.DeleteEmployeeByEmployeeId(500);

            //Assert

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void AddEmployeeBy_whenItIsCalled()
        {
            //Arrange
            Employee employee = new Employee { Id = 1, firstName = "Sateswar", lastName = "Sahu", email = "s.sahu@test.com", DepartmentId = 1, JobId = 1, phoneNumber = "234234", salary = 123124 };
            var data = JsonConvert.SerializeObject(employee);
            var listOfEmployee = new EmployeesController(_employeeService, _employeeRepository);

            //Act
            var result = listOfEmployee.AddEmployee(JsonDocument.Parse(data));


            //Assert
            Assert.IsInstanceOfType(result, typeof(CreatedResult));

        }
    }

}
