using Business_Layer;
using Data_Access_Layer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System.Collections.Generic;
using WebAPI201_Employees.Controllers;
using System.Text.Json;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            var listOfEmployee = new EmployeesController(_employeeService,_employeeRepository);


            //Act
            listOfEmployee.GetAllEmployees();
           

            //Assert
            Assert.IsNotNull(listOfEmployee.GetAllEmployees());
            Assert.AreEqual(2, ((List<Employee>)listOfEmployee.GetAllEmployees()).Count);
            

        }

        [TestMethod]
        public void GetEmployeeById_whenItIsCalled()
        {
            //Arrange
            var listOfEmployee = new EmployeesController(_employeeService, _employeeRepository);


            //Act
            listOfEmployee.GetEmployeeById(1);

            //Assert
            Assert.IsNotNull(listOfEmployee.GetEmployeeById(1));
            Assert.AreEqual(1,((Employee)listOfEmployee.GetEmployeeById(1)).Id);
        }


        [TestMethod]
        public void DeleteEmployeeById_whenItIsCalled()
        {
            //Arrange

            var listOfEmployee = new EmployeesController(_employeeService, _employeeRepository);
            //Act
            var result=listOfEmployee.DeleteEmployeeByEmployeeId(1);

            //Assert
                       
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
        [TestMethod]
        public void AddEmployeeBy_whenItIsCalled()
        {
            //Arrange
            Employee employee = new Employee { Id = 1, firstName = "Sateswar", lastName = "Sahu", email = "s.sahu@test.com", DepartmentId = 1, JobId = 1, phoneNumber = "234234", salary = 123124 };
            var data = JsonConvert.SerializeObject(employee);
            var listOfEmployee = new EmployeesController(_employeeService, _employeeRepository);

            //Act
            var result=listOfEmployee.AddEmployee(JsonDocument.Parse(data));


            //Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));

        }
    }

}
