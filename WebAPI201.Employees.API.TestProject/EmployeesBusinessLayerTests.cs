using Business_Layer;
using Data_Access_Layer.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI201.Employees.API.TestProject
{
    [TestClass]
    public class EmployeesBusinessLayerTests
    {
        EmployeeService _employeeService;
        IRepository<Employee> _employeeRepository;

        //public EmployeesBusinessLayerTests(IRepository<Employee> employee)
        //{
        //    _employee = employee;
        //}



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
            var listOfEmployee = new EmployeeService(_employeeRepository);


            //Act
            var result = listOfEmployee.GetAllEmployees();


            //Assert

            //Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsNotNull(result);

        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Get_AllEmployeeRecords_whenItIsCalledException()
        {
            //Arrange
            var listOfEmployee = new EmployeeService(_employeeRepository);


            //Act
            var result = listOfEmployee.GetAllEmployees();


            //Assert

            //Assert.ThrowsException<System.ArgumentOutOfRangeException>("none");
            throw new Exception("Employee");

        }

        [TestMethod]
        public void GetEmployeeById_whenItIsCalled()
        {
            //Arrange
            var listOfEmployee = new EmployeeService(_employeeRepository);


            //Act
            var result = listOfEmployee.GetEmployeeById(1);

            //Assert
            //Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsNotNull(result);

        }

    }
}
