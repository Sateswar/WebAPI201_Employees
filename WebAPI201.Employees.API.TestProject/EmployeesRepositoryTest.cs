using Business_Layer;
using Data_Access_Layer.Data;
using Data_Access_Layer.Repository;
using Microsoft.EntityFrameworkCore;
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
    public class EmployeesRepositoryTest 
    {
        EmployeeService _employeeService;
        IRepository<Employee> _employeeRepository;
        RepositoryEmployee _repositoryEmployee;
        DbContextOptionsBuilder dbContextOptions =new DbContextOptionsBuilder<EmployeeDBContext>();
        DbContextOptions<EmployeeDBContext> option=new DbContextOptions<EmployeeDBContext>();
        EmployeeDBContext _dbContext;


     public void RepositoryEmployee(EmployeeDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        //DbContextOptions<EmployeeDBContext> _options=new DbContextOptions<EmployeeDBContext>(DbContextId);
        //EmployeeDBContext _dbContext = new EmployeeDBContext(_options);

        [TestInitialize]
        public void Setup()
        {
            var employees = new List<Employee>();
            employees.Add(new Employee { Id = 1, firstName = "Sateswar", lastName = "Sahu", email = "s.sahu@test.com", DepartmentId = 1, JobId = 1, phoneNumber = "234234", salary = 123124 });
            employees.Add(new Employee { Id = 2, firstName = "Sateswar", lastName = "Sahu", email = "s.sahu@test.com", DepartmentId = 1, JobId = 1, phoneNumber = "234234", salary = 123124 });

            var repoMock = new Mock<IRepository<Employee>>();
          

            repoMock.Setup(r => r.GetAll()).Returns(employees);
            repoMock.Setup(r => r.GetById(1)).Returns(employees.FirstOrDefault);
            _employeeRepository = repoMock.Object;
            _employeeService = new EmployeeService(_employeeRepository);
            
           

            
            
            //    object p = context.Employees.Add(new Employee
            //    {
            //        Id = 1,
            //        firstName = "Sateswar",
            //        lastName = "Sahu",
            //        email = "s.sahu@test.com",
            //        DepartmentId = 1,
            //        JobId = 1,
            //        phoneNumber = "234234",
            //        salary = 123124
            //    });

            //    context.Employees.Add(new Employee
            //    {   Id = 2, 
            //        firstName = "Sateswar", 
            //        lastName = "Sahu", 
            //        email = "s.sahu@test.com", 
            //        DepartmentId = 1, 
            //        JobId = 1, 
            //        phoneNumber = "234234", 
            //        salary = 123124 
            //    });
            //    context.SaveChanges();
            
        }


        [TestMethod]
        public void Get_AllEmployeeRecords_whenItIsCalled()
        {

            //Arrange
            
            var _refEmployeeRepository = new RepositoryEmployee(_dbContext);



            //Act
            IEnumerable<Employee> result = _employeeRepository.GetAll();
           

            //Assert

            //Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void GetEmployeeById_whenItIsCalled()
        {
            //Arrange
            var listOfEmployee = new RepositoryEmployee(_dbContext);


            //Act
            var result = _employeeRepository.GetById(1);

            //Assert
            //Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, 1);


        }

        [TestMethod]
        public void DeleteEmployee_whenCalled()
        {
            //Arrange
            Employee _employee = new Employee();
            _employee.Id = 2;
            var listOfEmployee = new RepositoryEmployee(_dbContext);


            //Act
             _employeeRepository.Delete(_employee); 


        }
        [TestMethod]
        public void CreateEmployee_whenCalled()
        {
            //Arrange
            Employee _employee = new Employee{ Id = 3, firstName = "Sateswar", lastName = "Sahu", email = "s.sahu@test.com", DepartmentId = 1, JobId = 1, phoneNumber = "234234", salary = 123124 };
            
            var listOfEmployee = new RepositoryEmployee(_dbContext);


            //Act
           

            
            _employeeRepository.Create(_employee);
        }

    }
}
