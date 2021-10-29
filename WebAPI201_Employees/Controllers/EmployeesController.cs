using Business_Layer;
using Data_Access_Layer.Repository;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI201_Employees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly EmployeeService _employeeService;
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeesController(EmployeeService employeeService, IRepository<Employee> employeeRepository)
        {
            _employeeService = employeeService;
            _employeeRepository = employeeRepository;
        }
        // GET api/<Employees>/5
        [HttpGet("GetEmployeeById/{id}")]
        public object GetEmployeeById(int id)
        {
            var data = _employeeService.GetEmployeeById(id);
            return data;
        }

        // GET: api/<Employees>
        [HttpGet("GetEmployees")]
        public object GetAllEmployees()
        {
            return _employeeService.GetAllEmployees();
        }

        // POST api/<Employees>
        [HttpPost("AddEmployee")]
        public async Task<Object> AddEmployee([FromBody] JsonElement value)
        {
            try
            {
                //var serializeOptions = new JsonSerializerOptions();
                //serializeOptions.Converters.Add(new Int32Converter());
                //serializeOptions.Converters.Add(new DecimalConverter());
                string json = System.Text.Json.JsonSerializer.Serialize(value);

                Employee emp = JsonConvert.DeserializeObject<Employee>(json);
                await _employeeService.AddEmployee(emp);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
            
            
        }


        // DELETE api/<Employees>/5
        
        [HttpDelete("DeleteEmployee/{id}")]
        public void DeleteEmployee(int Employeeid)
        {
            try
            {
                Employee emp = new Employee();
                emp.Id = Employeeid;
                _employeeService.DeleteEmployeeById(emp);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //// PUT api/<Employees>/5
        //[HttpPut("{id}")]
        //public void PutEmployee(int id, [FromBody] string value)
        //{
        //    var data=_employeeService.Create
        //}

    }
}
